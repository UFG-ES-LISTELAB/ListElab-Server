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
        public List<DtoQuestaoDaLista> Questoes { get; set; }
    }
}
