using ListElab.Dominio.Conceitos.DisciplinaObj;
using ListElab.Dominio.Dtos;
using ListElab.Servico.ServicosImplementados;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ListElab.Contrato.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("SiteCorsPolicy")]
    public class DisciplinaController : ControllerBase
    {
        /// <summary>
        /// Lista todas os registros cadastrados.
        /// </summary>
        /// <returns>Retorna um objeto de sucesso ou falha e os registros cadastrados, caso sucesso.</returns>
        [HttpGet]
        [Authorize]
        public ActionResult<DtoResultado<Disciplina>> ConsulteLista()
        {
            return ExecuteAcaoAutorizada(() =>
            {
                var resultado = new ServicoConsulte<Disciplina>().ConsulteLista();
                return Ok(DtoResultado<Disciplina>.ObtenhaResultado(resultado, "Consulta realizada sem erros"));
            });
        }

        /// <summary>
        /// Executa o método para a requisição da api e retorna o resultado da requisição.
        /// </summary>
        /// <param name="sucesso">Método quando a requisição aconteceu com sucesso.</param>
        /// <returns></returns>
        private ActionResult<DtoResultado<Disciplina>> ExecuteAcaoAutorizada(Func<ActionResult<DtoResultado<Disciplina>>> sucesso)
        {
            try
            {
                return sucesso();
            }
            catch (Exception e)
            {
                return BadRequest(DtoResultado<Disciplina>.ObtenhaResultado(e));
            }
        }
    }
}