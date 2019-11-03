using ListElab.Dominio.Enumeradores;
using System.Collections.Generic;

namespace ListElab.Dominio.Dtos
{
    public class DtoListaQuestoes : DtoComId
    {
        /// <summary>
        /// Título da lista.
        /// </summary>
        public string Titulo { get; set; }

        /// <summary>
        /// Representa as áreas de conhecimento disponíveis.
        /// </summary>
        public DtoAreaDoConhecimento AreaDeConhecimento { get; set; }

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
        public DtoDisciplina Disciplina { get; set; }

        /// <summary>
        /// Define se uma lista está pronta para ser aplicada.
        /// </summary>
        public bool ProntaParaAplicacao { get; set; }

        /// <summary>
        /// O email do usuário que criou a lista.
        /// </summary>
        public string Usuario { get; set; }

        /// <summary>
        /// Questões discursivas
        /// </summary>
        public List<DtoQuestaoDiscursiva> Discursivas { get; set; }
    }
}
