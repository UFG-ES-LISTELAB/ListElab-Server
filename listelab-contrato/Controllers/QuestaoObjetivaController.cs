using listelab_dominio.Conceitos;
using listelab_dominio.Conceitos.Filtro;
using listelab_dominio.Conceitos.Resposta;
using listelab_dominio.InterfaceDeServico;

namespace listelab_contrato.Controllers
{
    /// <summary>
    /// Api para pesquisa de questão objetiva
    /// </summary>
    public class QuestaoObjetivaController : ControladorPadrao<Questao<Objetiva>, IServicoQuestaoObjetiva, FiltroQuestao>
    {
    }
}