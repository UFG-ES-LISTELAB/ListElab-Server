using ListElab.Dominio.Conceitos.QuestaoObj;
using ListElab.Dominio.Conceitos.RespostaObj;
using ListElab.Dominio.Dtos;
using ListElab.Dominio.Dtos.Filtro;
using System.Collections.Generic;

namespace ListElab.Dominio.InterfaceDeServico
{
    public interface IServicoQuestaoDiscursiva : IServicoPadrao<Questao<Discursiva>, DtoQuestaoDiscursiva>
    {
        /// <summary>
        /// Consulta o primeiro objeto genérico que atende uma condição.
        /// </summary>
        /// <param name="filtro">O filtro para trazer as questões.</param>
        /// <returns>A lista de questões que se adequam ao filtro.</returns>
        List<Questao<Discursiva>> Consulte(FiltroQuestao filtro);
    }
}
