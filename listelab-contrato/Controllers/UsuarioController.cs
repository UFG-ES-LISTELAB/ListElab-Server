using ListElab.Dominio.Conceitos.UsuarioObj;
using ListElab.Dominio.Dtos;
using ListElab.Servico.ServicosImplementados;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ListElab.Contrato.Controllers
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
                var usuario = servico.EfetueLogin(login.Email, login.Password);
                return Ok(DtoResultado<Usuario>.ObtenhaResultado(usuario, "Usuário logado"));
            }
            catch (Exception e)
            {
                return BadRequest(DtoResultado<Usuario>.ObtenhaResultado(e));
            }
        }
    }
}