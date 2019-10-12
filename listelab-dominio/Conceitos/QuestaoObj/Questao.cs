using listelab_dominio.Abstrato;
using listelab_dominio.Conceitos.UsuarioObj;
using listelab_dominio.CustomAttributes;
using listelab_dominio.Enumeradores;
using System.Collections.Generic;

namespace listelab_dominio.Conceitos.QuestaoObj
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

        /// <summary>
        /// Representa os insumos para resposta.
        /// </summary>
        public T RespostaEsperada { get; set; }
    }
}
