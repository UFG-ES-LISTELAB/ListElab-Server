using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using listelab_dominio.Conceitos;
using listelab_dominio.Conceitos.Filtro;
using listelab_dominio.InterfaceDeServico;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace listelab_contrato.Controllers
{
    /// <summary>
    /// Api para Lista
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ListaController : ControladorPadrao<ListaQuestoes, IServicoListaQuestoes, FiltroLista>
    {
    }
}