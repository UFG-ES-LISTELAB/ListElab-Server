using listelab_dominio.Conceitos.Filtro;
using listelab_dominio.Conceitos.Questao;
using listelab_dominio.Conceitos.Resposta;
using listelab_dominio.InterfaceDeServico;

namespace listelab_contrato.Controllers
{
    public class QuestaoObjetivaController : ControladorPadrao<Questao<Objetiva>, IServicoDeQuestaoObjetiva, FiltroQuestao>
    {
    }
}