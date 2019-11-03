﻿using ListElab.Dominio.Conceitos.ListaObj;
using ListElab.Dominio.Dtos;
using ListElab.Dominio.Dtos.Filtro;

namespace ListElab.Dominio.InterfaceDeServico
{
    public interface IServicoListaQuestoes : IServicoCrudCompleto<ListaQuestoes, DtoListaQuestoes>
    {
        ListaQuestoes ConsulteQuestoes(FiltroQuestao filtro);
    }
}
