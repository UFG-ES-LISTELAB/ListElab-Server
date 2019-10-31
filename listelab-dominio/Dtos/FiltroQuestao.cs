using ListElab.Dominio.Enumeradores;

namespace ListElab.Dominio.Dtos.Filtro
{
    /// <summary>
    /// Representa filtro de questão.
    /// </summary>
    public class FiltroQuestao : Filtro
    {
        /// <summary>
        /// Representa as áreas de conhecimento disponíveis.
        /// </summary>
        public DtoAreaDoConhecimento AreaDeConhecimento { get; set; }

        /// <summary>
        /// Representa o nível de dificuldade, indo de 1 à 5.
        /// </summary>
        public NivelDificuldade NivelDificuldade { get; set; }

        /// <summary>
        /// Tipo de questão.
        /// </summary>
        public TipoQuestao? Tipo { get; set; }

        /// <summary>
        /// Disciplina da questão.
        /// </summary>
        public DtoDisciplina Disciplina { get; set; }

        /// <summary>
        /// Representa o tempo máximo para responder a questão em minutos.
        /// </summary>
        public int? TempoMaximoDeResposta { get; set; }

        /// <summary>
        /// Email do usuário que fez a questão.
        /// </summary>
        public string Usuario { get; set; }
    }
}
