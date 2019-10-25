using ListElab.Dominio.Conceitos.QuestaoObj;
using ListElab.Dominio.Conceitos.RespostaObj;
using ListElab.Dominio.InterfaceDeServico;

namespace ListElab.Contrato.Controllers
{
    /// <summary>
    /// Api para pesquisa de questão objetiva
    /// </summary>
    public class QuestaoObjetivaController : ControladorPadrao<Questao<Objetiva>, IServicoQuestaoObjetiva>
    {
    }
}