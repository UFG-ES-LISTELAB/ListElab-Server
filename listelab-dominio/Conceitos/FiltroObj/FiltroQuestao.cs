using listelab_dominio.Enumeradores;
using System;
using System.Collections.Generic;
using System.Text;

namespace listelab_dominio.Conceitos.Filtro
{
    /// <summary>
    /// Representa filtro de questão.
    /// </summary>
    public class FiltroQuestao : Filtro
    {
        /// <summary>
        /// Representa as áreas de conhecimento disponíveis.
        /// </summary>
        public AreaDeConhecimento? AreaDeConhecimento { get; set; }

        /// <summary>
        /// Representa o nível de dificuldade, indo de 1 à 5.
        /// </summary>
        public NivelDificuldade? NivelDificuldade { get; set; }

        /// <summary>
        /// Tipo de questão.
        /// </summary>
        public TipoQuestao? Tipo { get; set; }

        /// <summary>
        /// Representa o tempo máximo para responder a questão em minutos.
        /// </summary>
        public int? TempoMaximoDeResposta { get; set; }
    }
}
