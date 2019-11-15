using ListElab.Dominio.Conceitos.AreaDeConhecimentoObj;
using ListElab.Dominio.Dtos;
using ListElab.Servico.ServicosImplementados;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ListElab.Contrato.Controllers
{
    /// <summary>
    /// Controlador de área de conhecimento.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("SiteCorsPolicy")]
    public class AreaDeConhecimentoController : ControllerBase
    {
        /// <summary>
        /// Lista todas os registros cadastrados.
        /// </summary>
        /// <returns>Retorna um objeto de sucesso ou falha e os registros cadastrados, caso sucesso.</returns>
        [HttpGet]
        [Authorize]
        public ActionResult<DtoResultado<AreaDeConhecimento>> ConsulteLista()
        {
            return ExecuteAcaoAutorizada(() =>
            {
                var resultado = new ServicoConsulte<AreaDeConhecimento>().ConsulteLista();
                return Ok(DtoResultado<AreaDeConhecimento>.ObtenhaResultado(resultado, "Consulta realizada sem erros"));
            });
        }

        /// <summary>
        /// Executa o método para a requisição da api e retorna o resultado da requisição.
        /// </summary>
        /// <param name="sucesso">Método quando a requisição aconteceu com sucesso.</param>
        /// <returns></returns>
        private ActionResult<DtoResultado<AreaDeConhecimento>> ExecuteAcaoAutorizada(Func<ActionResult<DtoResultado<AreaDeConhecimento>>> sucesso)
        {
            try
            {
                return sucesso();
            }
            catch (Exception e)
            {
                return BadRequest(DtoResultado<AreaDeConhecimento>.ObtenhaResultado(e));
            }
        }
    }
}