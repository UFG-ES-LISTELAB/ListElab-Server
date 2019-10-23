using listelab_contrato.RequestObject;
using listelab_dominio.Conceitos.Filtro;
using listelab_dominio.Conceitos.ListaObj;
using listelab_dominio.Conceitos.QuestaoObj;
using listelab_dominio.Conceitos.RespostaObj;
using listelab_dominio.InterfaceDeServico;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace listelab_contrato.Controllers
{
    /// <summary>
    /// Api para Lista
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ListaController : ControladorPadrao<ListaQuestoes, IServicoListaQuestoes>
    {
        /// <summary>
        /// Retorna uma lista de questoes discursivas
        /// </summary>
        /// <param name="filtro">O filtro de questão.</param>
        /// <returns>Retorna objeto de resposta de sucesso ou falha, contendo o objeto desejado, caso sucesso.</returns>
        [HttpPost]
        [Route("filtro")]
        [Authorize]
        public ActionResult<DtoResultado<ListaQuestoes>> ConsulteDiscursivasComFiltro([FromBody] FiltroQuestao filtro)
        {
            return ExecuteAcaoAutorizada(() =>
            {
                var resultado = Servico().ConsulteQuestoes(filtro);
                return DtoResultado<ListaQuestoes>.ObtenhaResultado(resultado, "Consulta realizada sem erros");
            });
        }
    }
}