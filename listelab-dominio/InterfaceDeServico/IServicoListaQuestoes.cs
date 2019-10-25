using ListElab.Dominio.Conceitos.Filtro;
using ListElab.Dominio.Conceitos.ListaObj;

namespace ListElab.Dominio.InterfaceDeServico
{
    public interface IServicoListaQuestoes : IServicoPadrao<ListaQuestoes>
    {
        ListaQuestoes ConsulteQuestoes(FiltroQuestao filtro);
    }
}
