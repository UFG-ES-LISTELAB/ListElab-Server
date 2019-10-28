using ListElab.Dominio.Conceitos.ListaObj;
using ListElab.Dominio.Dtos;
using ListElab.Dominio.Dtos.Filtro;
using ListElab.Dominio.InterfaceDeServico;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ListElab.Contrato.Controllers
{
    /// <summary>
    /// Api para Lista
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ListaController : ControladorPadrao<ListaQuestoes, IServicoListaQuestoes, DtoListaQuestoes>
    {
        /// <summary>
        /// Retorna uma lista de questoes discursivas
        /// </summary>
        /// <param name="filtro">O filtro de questão.</param>
        /// <returns>Retorna objeto de resposta de sucesso ou falha, contendo o objeto desejado, caso sucesso.</returns>
        [HttpPost]
        [Route("filtro")]
        [Authorize]
        public ActionResult<DtoResultado<DtoListaQuestoes>> ConsulteDiscursivasComFiltro([FromBody] FiltroQuestao filtro)
        {
            return ExecuteAcaoAutorizada(() =>
            {
                var resultado = Servico().ConsulteQuestoes(filtro);
                return DtoResultado<DtoListaQuestoes>.ObtenhaResultado(resultado, "Consulta realizada sem erros");
            });
        }
    }
}