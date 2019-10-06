using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using listelab_dominio.InterfaceDeServico;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace listelab_contrato.Controllers
{
    [Route("api/questao_objetiva")]
    [ApiController]
    public class QuestaoObjetivaController : ControladorPadrao<IServicoDeQuestaoObjetiva>
    {
    }
}