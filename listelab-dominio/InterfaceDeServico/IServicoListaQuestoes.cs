using ListElab.Dominio.Conceitos.Filtro;
using ListElab.Dominio.Conceitos.ListaObj;
using ListElab.Dominio.Dtos;

namespace ListElab.Dominio.InterfaceDeServico
{
    public interface IServicoListaQuestoes : IServicoPadrao<ListaQuestoes, DtoListaQuestoes>
    {
        ListaQuestoes ConsulteQuestoes(FiltroQuestao filtro);
    }
}
