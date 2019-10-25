using ListElab.Dominio.Abstrato;
using ListElab.Dominio.CustomAttributes;
using ListElab.Dominio.Enumeradores;
using System.Collections.Generic;

namespace ListElab.Dominio.Conceitos.QuestaoObj
{
    /// <summary>
    /// Representa uma questão genérica.
    /// </summary>
    [Colecao(Nome = "questoes")]
    public class Questao<T> : ObjetoComId
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
        public AreaDeConhecimento AreaDeConhecimento { get; set; }

        /// <summary>
        /// Representa o nível de dificuldade, indo de 1 à 5.
        /// </summary>
        public NivelDificuldade NivelDificuldade { get; set; }

        /// <summary>
        /// Disciplina da questão.
        /// </summary>
        public Disciplina Disciplina { get; set; }

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
        public T RespostaEsperada { get; set; }
    }
}
