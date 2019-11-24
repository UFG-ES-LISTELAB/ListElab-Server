using ListElab.Dominio.Conceitos.QuestaoObj;
using ListElab.Dominio.Conceitos.RespostaObj;
using ListElab.Dominio.Dtos;
using ListElab.Dominio.InterfaceDeServico;

namespace ListElab.Contrato.Controllers
{
    /// <summary>
    /// Api que representa questões de associação de coluna.
    /// </summary>
    public class QuestaoAssociacaoDeColunasController : ControladorPadrao<Questao<AssociacaoDeColunas>, IServicoQuestao<AssociacaoDeColunas, DtoQuestaoAssociacaoDeColunas>, DtoQuestaoAssociacaoDeColunas>
    {
    }
}
