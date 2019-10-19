using listelab_dominio.Conceitos;
using listelab_dominio.Conceitos.Filtro;
using listelab_dominio.Conceitos.QuestaoObj;
using listelab_dominio.Conceitos.RespostaObj;
using System.Collections.Generic;

namespace listelab_dominio.InterfaceDeServico
{
    public interface IServicoQuestaoDiscursiva : IServicoPadrao<Questao<Discursiva>>
    {
        /// <summary>
        /// Consulta o primeiro objeto genérico que atende uma condição.
        /// </summary>
        /// <param name="filtro">O filtro para trazer as questões.</param>
        /// <returns>A lista de questões que se adequam ao filtro.</returns>
        List<Questao<Discursiva>> Consulte(FiltroQuestao filtro);
    }
}
