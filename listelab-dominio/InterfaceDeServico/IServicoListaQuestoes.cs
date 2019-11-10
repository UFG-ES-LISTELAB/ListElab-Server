using ListElab.Dominio.Conceitos.ListaObj;
using ListElab.Dominio.Dtos;
using ListElab.Dominio.Dtos.Filtro;
using System.Collections.Generic;

namespace ListElab.Dominio.InterfaceDeServico
{
    public interface IServicoListaQuestoes : IServicoCrudCompleto<ListaQuestoes, DtoListaQuestoes>
    {
        /// <summary>
        /// Retorna uma lista de questões de acordo com o filtro passado.
        /// </summary>
        /// <param name="filtro">O filtro passado para pesquisar a lista.</param>
        /// <returns>A lista de lista de questões.</returns>
        IEnumerable<DtoListaQuestoes> Consulte(Filtro filtro);
    }
}
