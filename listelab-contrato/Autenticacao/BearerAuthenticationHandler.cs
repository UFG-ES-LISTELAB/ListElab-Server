using ListElab.Servico.ServicosImplementados;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace ListElab.Contrato.Autenticacao
{
    /// <summary>
    /// Define as regras para autenticação.
    /// </summary>
    public class BearerAuthenticationHandler : AuthenticationHandler<BearerAuthenticationOptions>
    {
        private ServicoBearerAuthentication authenticationService;

        /// <summary>
        /// Construtor da classe que define as regras para autenticação.
        /// </summary>
        /// <param name="options">Opções para autenticação.</param>
        /// <param name="logger">Arquivo de log para auteneticação.</param>
        /// <param name="encoder">Tipo de encode para arquivo.</param>
        /// <param name="clock">Tempo de autenticação.</param>
        public BearerAuthenticationHandler(
            IOptionsMonitor<BearerAuthenticationOptions> options,
            ILoggerFactory logger,
            UrlEncoder encoder,
            ISystemClock clock) : base(options, logger, encoder, clock)
        {
            authenticationService = new ServicoBearerAuthentication();
        }
        private void autenticacaoParaSwagger(HttpRequest requisicao)
        {
            StringValues urlAtual = string.Empty;
            Context.Request.Headers.TryGetValue("Referer", out urlAtual);
            if (urlAtual.ToString().Contains("swagger"))
            {
                var tokenAutenticado = authenticationService.EfetueLogin("professor@ufg.br", "123456");
                requisicao.Headers.Add("Authorization", new StringValues(string.Format("Bearer {0}", tokenAutenticado.Token)));
            }
        }
        /// <summary>
        /// Método para aplicar regras de autenticação.
        /// </summary>
        /// <returns>Se a autenticação aconteceu ou não.</returns>
        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            autenticacaoParaSwagger(Request);

            if (!Request.Headers.ContainsKey("Authorization"))
            {
                //Authorization header not in request
                return AuthenticateResult.Fail(new Exception("O Token não foi passado."));
            }

            if (!AuthenticationHeaderValue.TryParse(Request.Headers["Authorization"], out AuthenticationHeaderValue headerValue))
            {
                //Invalid Authorization header
                return AuthenticateResult.NoResult();
            }

            if (!AuthenticationDefaults.BearerAuthenticationScheme.Equals(headerValue.Scheme, StringComparison.OrdinalIgnoreCase))
            {
                return AuthenticateResult.Fail("Wrong scheme");
            }

            string token = headerValue.Parameter;

            bool isValidUser = await authenticationService.IsValidUserAsync(token);

            if (!isValidUser)
            {
                return AuthenticateResult.Fail("Token inválido");
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Authentication, token),
                new Claim(ClaimTypes.Role, authenticationService.GetRole(token)),
            };

            var identity = new ClaimsIdentity(claims, Scheme.Name);
            var principal = new ClaimsPrincipal(identity);
            var ticket = new AuthenticationTicket(principal, Scheme.Name);
            return AuthenticateResult.Success(ticket);
        }
    }
}