using listelab_dominio.Conceitos;
using listelab_dominio.Conceitos.Filtro;
using listelab_dominio.Conceitos.ListaObj;
using listelab_dominio.Conceitos.QuestaoObj;
using listelab_dominio.Conceitos.RespostaObj;
using System;
using System.Collections.Generic;
using System.Text;

namespace listelab_dominio.InterfaceDeServico
{
    public interface IServicoListaQuestoes : IServicoPadrao<ListaQuestoes>
    {
        ListaQuestoes ConsulteQuestoes(FiltroQuestao filtro);
    }
}
