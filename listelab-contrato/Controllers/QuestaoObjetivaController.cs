using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using listelab_dominio.Conceitos.Filtro;
using listelab_dominio.Conceitos.Questao;
using listelab_dominio.Conceitos.Resposta;
using listelab_dominio.InterfaceDeServico;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace listelab_contrato.Controllers
{
    public class QuestaoObjetivaController : ControladorPadrao<Questao<Objetiva>, IServicoDeQuestaoObjetiva, FiltroQuestao>
    {
    }
}