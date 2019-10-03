using listelab_dominio.Abstrato;
using listelab_dominio.Conceitos.RespostaObj;
using listelab_dominio.Enumeradores;

namespace listelab_dominio.Conceitos.QuestaoObj
{
    /// <summary>
    /// Representa uma questão genérica.
    /// </summary>
    public abstract class Questao<T> : ObjetoComId where T : Resposta
    {
        /// <summary>
        /// Representa o enunciado de uma questão.
        /// </summary>
        public string Enunciado { get; set; }

        /// <summary>
        /// Representa as áreas de conhecimento disponíveis.
        /// </summary>
        public EnumAreaDeConhecimento AreaDeConhecimento { get; set; }

        /// <summary>
        /// Representa o nível de dificuldade, indo de 1 à 5.
        /// </summary>
        public EnumNivelDificuldade NivelDificuldade { get; set; }

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
