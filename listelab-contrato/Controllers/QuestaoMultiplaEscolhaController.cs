using ListElab.Dominio.Conceitos.QuestaoObj;
using ListElab.Dominio.Conceitos.RespostaObj;
using ListElab.Dominio.Dtos;
using ListElab.Dominio.InterfaceDeServico;
using Microsoft.AspNetCore.Mvc;

namespace ListElab.Contrato.Controllers
{
    /// <summary>
    /// Api para conceito de questão multiplha escolha. 
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class QuestaoMultiplaEscolhaController : ControladorPadrao<Questao<MultiplaEscolha>, IServicoQuestao<MultiplaEscolha, DtoQuestaoMultiplaEscolha>, DtoQuestaoMultiplaEscolha>
    {
    }
}