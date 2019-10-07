using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using listelab_contrato.RequestObject;
using listelab_dominio.Conceitos.UsuarioObj;
using listelab_servico.Servico;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace listelab_contrato.Controllers
{

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
        public ActionResult<ObjetoResult<Usuario>> Cadastre([FromBody] Login login)
        {
            try
            {
                var servico = new ServicoBearerAuthentication();
                var token = servico.EfetueLogin(login.Email, login.Password);
                return ObjetoResult<Usuario>.ReturnResult(token, "Usuário logado");
            }
            catch (Exception e)
            {
                return ObjetoResult<Usuario>.ReturnResultError(e);
            }
        }
    }
}