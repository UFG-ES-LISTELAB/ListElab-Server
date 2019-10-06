using listelab_dominio.Enumeradores;
using System;
using System.Collections.Generic;
using System.Text;

namespace listelab_dominio.Conceitos.Filtro
{
    /// <summary>
    /// Representa filtro de questão.
    /// </summary>
    public class FiltroQuestao
    {
        /// <summary>
        /// Representa as áreas de conhecimento disponíveis.
        /// </summary>
        public EnumAreaDeConhecimento AreaDeConhecimento { get; set; }

        /// <summary>
        /// Representa o nível de dificuldade, indo de 1 à 5.
        /// </summary>
        public EnumNivelDificuldade NivelDificuldade { get; set; }

        /// <summary>
        /// Tags para pesquisa da questão
        /// </summary>
        public List<string> Tags { get; set; }

        /// <summary>
        /// Tipo de questão.
        /// </summary>
        public EnumTipoQuestao Tipo { get; set; }

        /// <summary>
        /// Representa o tempo máximo para responder a questão em minutos.
        /// </summary>
        public int TempoMaximoDeResposta { get; set; }
    }
}
