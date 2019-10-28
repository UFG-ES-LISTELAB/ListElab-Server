using ListElab.Dominio.Abstrato;
using ListElab.Dominio.AtributosCustomizados;
using ListElab.Dominio.Conceitos.QuestaoObj;
using ListElab.Dominio.Conceitos.RespostaObj;
using ListElab.Dominio.Enumeradores;
using System.Collections.Generic;

namespace ListElab.Dominio.Conceitos.ListaObj
{
    [Colecao(Nome = "listas")]
    public class ListaQuestoes : ObjetoComId
    {
        /// <summary>
        /// Título da lista.
        /// </summary>
        public string Titulo { get; set; }

        /// <summary>
        /// Representa as áreas de conhecimento disponíveis.
        /// </summary>
        public AreaDeConhecimento AreaDeConhecimento { get; set; }

        /// <summary>
        /// Representa o nível de dificuldade, indo de 1 à 5.
        /// </summary>
        public NivelDificuldade NivelDificuldade { get; set; }

        /// <summary>
        /// Tags para busca da lista
        /// </summary>
        public List<string> Tags { get; set; }

        /// <summary>
        /// Disciplina da questão.
        /// </summary>
        public Disciplina Disciplina { get; set; }

        /// <summary>
        /// O email do usuário que criou a lista.
        /// </summary>
        public string Usuario { get; set; }

        /// <summary>
        /// Questões discursivas
        /// </summary>
        public List<Questao<Discursiva>> Discursivas { get; set; }

        /// <summary>
        /// Questões objetivas
        /// </summary>
        public List<Questao<Objetiva>> Objetivas { get; set; }
    }
}
