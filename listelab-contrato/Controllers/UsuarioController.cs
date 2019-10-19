using System;
using listelab_contrato.RequestObject;
using listelab_dominio.Conceitos.UsuarioObj;
using listelab_servico.Servico;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace listelab_contrato.Controllers
{

    /// <summary>
    /// Api de usuário para efetuar login.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        /// <summary>
        /// Realiza login.
        /// </summary>
        /// <param name="login">O usuário buscando autenticação.</param>
        /// <returns>Retorna objeto com resultado da requisição.</returns>
        [HttpPost]
        [Route("login")]
        [EnableCors("SiteCorsPolicy")]
        public ActionResult<DtoResultado<Usuario>> Cadastre([FromBody] Login login)
        {
            try
            {
                var servico = new ServicoBearerAuthentication();
                var token = servico.EfetueLogin(login.Email, login.Password);
                return DtoResultado<Usuario>.ObtenhaResultado(token, "Usuário logado");
            }
            catch (Exception e)
            {
                return DtoResultado<Usuario>.ObtenhaResultado(e);
            }
        }
    }
}