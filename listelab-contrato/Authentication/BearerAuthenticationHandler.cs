using listelab_servico.Servico;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace listelab_contrato.Authentication
{ 
    public class BearerAuthenticationHandler : AuthenticationHandler<BearerAuthenticationOptions>
    {
        private ServicoBearerAuthentication authenticationService;
        private AuthenticateResult resultado = null;

        public BearerAuthenticationHandler(
            IOptionsMonitor<BearerAuthenticationOptions> options,
            ILoggerFactory logger,
            UrlEncoder encoder,
            ISystemClock clock) : base(options, logger, encoder, clock)
        {
            authenticationService = new ServicoBearerAuthentication();
        }

        /// <summary>
        /// Aplica regras de autenticação.
        /// </summary>
        /// <returns>Retorna resultado de autenticação.</returns>
        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            VerifiqueAutenticacao(!Request.Headers.ContainsKey("Authorization"), () => AuthenticateResult.Fail(new Exception("O Token não foi passado.")), ref resultado);

            VerifiqueAutenticacao(!AuthenticationHeaderValue.TryParse(Request.Headers["Authorization"], out AuthenticationHeaderValue headerValue), () => AuthenticateResult.NoResult(), ref resultado);

            VerifiqueAutenticacao(!AuthenticationDefaults.BearerAuthenticationScheme.Equals(headerValue.Scheme, StringComparison.OrdinalIgnoreCase), () => AuthenticateResult.Fail("Wrong scheme"), ref resultado);

            string token = headerValue.Parameter;
            bool isValidUser = await authenticationService.IsValidUserAsync(token);

            VerifiqueAutenticacao(!isValidUser, () => AuthenticateResult.Fail("Token inválido"), ref resultado);

            VerifiqueAutenticacao(resultado == null, () =>
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Authentication, token),
                    new Claim(ClaimTypes.Role, authenticationService.GetRole(token)),
                };

                var identity = new ClaimsIdentity(claims, Scheme.Name);
                var principal = new ClaimsPrincipal(identity);
                var ticket = new AuthenticationTicket(principal, Scheme.Name);
                return AuthenticateResult.Success(ticket);

            }, ref resultado);

            return resultado;
        }

        private void VerifiqueAutenticacao(bool condicao, Func<AuthenticateResult> acaoResultado, ref AuthenticateResult resultado)
        {
            if(condicao && resultado == null)
            {
                resultado = acaoResultado();
            }
        }
    }
}