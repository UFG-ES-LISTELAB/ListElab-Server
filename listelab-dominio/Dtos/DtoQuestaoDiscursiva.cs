using ListElab.Dominio.Enumeradores;
using System.Collections.Generic;

namespace ListElab.Dominio.Dtos
{
    /// <summary>
    /// Representa um dto de questão discursiva.
    /// </summary>
    public class DtoQuestaoDiscursiva : DtoComId
    {
        /// <summary>
        /// Representa o enunciado de uma questão.
        /// </summary>
        public string Enunciado { get; set; }

        /// <summary>
        /// O email do usuário que criou a questão.
        /// </summary>
        public string Usuario { get; set; }

        /// <summary>
        /// Representa as áreas de conhecimento disponíveis.
        /// </summary>
        public DtoAreaDoConhecimento AreaDeConhecimento { get; set; }

        /// <summary>
        /// Representa o nível de dificuldade, indo de 1 à 5.
        /// </summary>
        public NivelDificuldade NivelDificuldade { get; set; }

        /// <summary>
        /// Disciplina da questão.
        /// </summary>
        public DtoDisciplina Disciplina { get; set; }

        /// <summary>
        /// Tags para pesquisa da questão
        /// </summary>
        public List<string> Tags { get; set; }

        /// <summary>
        /// Tipo de questão.
        /// </summary>
        public TipoQuestao Tipo { get; set; }

        /// <summary>
        /// Representa o tempo máximo para responder a questão em minutos.
        /// </summary>
        public int TempoMaximoDeResposta { get; set; }

        /// <summary>
        /// Representa os insumos para resposta.
        /// </summary>
        public List<DtoPalavraChave> RespostaEsperada { get; set; }
    }
}
