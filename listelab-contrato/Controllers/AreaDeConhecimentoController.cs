using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ListElab.Dominio.Conceitos.AreaDeConhecimentoObj;
using ListElab.Dominio.Dtos;
using ListElab.Servico.ServicosImplementados;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ListElab.Contrato.Controllers
{
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