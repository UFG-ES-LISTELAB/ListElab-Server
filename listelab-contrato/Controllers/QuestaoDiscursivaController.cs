using ListElab.Contrato.RequestObject;
using ListElab.Dominio.Conceitos.Filtro;
using ListElab.Dominio.Conceitos.QuestaoObj;
using ListElab.Dominio.Conceitos.RespostaObj;
using ListElab.Dominio.InterfaceDeServico;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ListElab.Contrato.Controllers
{
    /// <summary>
    /// Api para o conceito de questão discursiva.
    /// </summary>
    public class QuestaoDiscursivaController : ControladorPadrao<Questao<Discursiva>, IServicoQuestaoDiscursiva>
    {
        /// <summary>
        /// Retorna a questão discursiva do código informado.
        /// </summary>
        /// <param name="filtro">O filtro de questão.</param>
        /// <returns>Retorna objeto de resposta de sucesso ou falha, contendo o objeto desejado, caso sucesso.</returns>
        [HttpPost]
        [Route("consulte")]
        [Authorize]
        public ActionResult<DtoResultado<Questao<Discursiva>>> ConsulteComFiltro([FromBody] FiltroQuestao filtro)
        {
            return ExecuteAcaoAutorizada(() =>
            {
                var resultado = Servico().Consulte(filtro);
                return DtoResultado<Questao<Discursiva>>.ObtenhaResultado(resultado, "Consulta realizada sem erros");
            });
        }
    }
}
