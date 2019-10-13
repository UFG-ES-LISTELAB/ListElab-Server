using listelab_dominio.Conceitos.Filtro;
using listelab_dominio.Conceitos.ListaObj;
using listelab_dominio.InterfaceDeServico;
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