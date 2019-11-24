using ListElab.Dominio.Conceitos.QuestaoObj;
using ListElab.Dominio.Conceitos.RespostaObj;
using ListElab.Dominio.Dtos;
using ListElab.Dominio.InterfaceDeServico;

namespace ListElab.Contrato.Controllers
{
    /// <summary>
    /// Api para o conceito de questão discursiva.
    /// </summary>
    public class QuestaoDiscursivaController : ControladorPadrao<Questao<Discursiva>, IServicoQuestao<Discursiva, DtoQuestaoDiscursiva>, DtoQuestaoDiscursiva>
    {
    }
}
