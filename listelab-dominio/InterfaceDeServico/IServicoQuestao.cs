using ListElab.Dominio.Conceitos.QuestaoObj;
using ListElab.Dominio.Dtos.Filtro;
using System.Collections.Generic;

namespace ListElab.Dominio.InterfaceDeServico
{
    /// <summary>
    /// Interface de serviço de questão.
    /// </summary>
    /// <typeparam name="TObjetoResposta">Representa uma resposta de questão.</typeparam>
    /// <typeparam name="TDtoQuestao">Representa um dto de questão.</typeparam>
    public interface IServicoQuestao<TObjetoResposta, TDtoQuestao> : IServicoCrudCompleto<Questao<TObjetoResposta>, TDtoQuestao>
    {
        /// <summary>
        /// Consulta o primeiro objeto genérico que atende uma condição.
        /// </summary>
        /// <param name="filtro">O filtro para trazer as questões.</param>
        /// <returns>A lista de questões que se adequam ao filtro.</returns>
        IEnumerable<TDtoQuestao> Consulte(Filtro filtro);
    }
}
