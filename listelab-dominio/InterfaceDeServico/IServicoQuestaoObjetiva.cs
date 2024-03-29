﻿using ListElab.Dominio.Conceitos.QuestaoObj;
using ListElab.Dominio.Conceitos.RespostaObj;
using ListElab.Dominio.Dtos;

namespace ListElab.Dominio.InterfaceDeServico
{
    public interface IServicoQuestaoObjetiva : IServicoCrudCompleto<Questao<Objetiva>, DtoQuestaoDiscursiva>
    {
    }
}
