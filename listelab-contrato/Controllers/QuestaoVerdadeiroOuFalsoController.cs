using ListElab.Dominio.Conceitos.QuestaoObj;
using ListElab.Dominio.Conceitos.RespostaObj;
using ListElab.Dominio.Dtos;
using ListElab.Dominio.InterfaceDeServico;

namespace ListElab.Contrato.Controllers
{
    /// <summary>
    /// Api para conceito de questão verdadeiro ou falso.
    /// </summary>
    public class QuestaoVerdadeiroOuFalsoController : ControladorPadrao<Questao<VerdadeiroOuFalso>, IServicoQuestao<VerdadeiroOuFalso, DtoQuestaoVerdadeiroOuFalso>, DtoQuestaoVerdadeiroOuFalso>
    {
    }
}