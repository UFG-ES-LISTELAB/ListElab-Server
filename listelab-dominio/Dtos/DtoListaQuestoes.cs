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
        /// Define se uma lista está pronta para ser aplicada.
        /// </summary>
        public bool ProntaParaAplicacao { get; set; }

        /// <summary>
        /// O email do usuário que criou a lista.
        /// </summary>
        public string Usuario { get; set; }

        /// <summary>
        /// Nível de dificuldade da lista, média das questões.
        /// </summary>
        public int NivelDeDificuldade { get; set; }

        /// <summary>
        /// Os tipos de questões que a lista possui.
        /// </summary>
        public List<TipoQuestao> TiposDeQuestao { get; set; }

        /// <summary>
        /// Questões discursivas
        /// </summary>
        public List<DtoQuestaoDaLista<DtoQuestaoDiscursiva>> QuestoesDiscursiva { get; set; }

        /// <summary>
        /// Questões de múltipla escolha.
        /// </summary>
        public List<DtoQuestaoDaLista<DtoQuestaoMultiplaEscolha>> QuestoesMultiplaEscolha { get; set; }

        /// <summary>
        /// Questões de associação de colunas.
        /// </summary>
        public List<DtoQuestaoDaLista<DtoQuestaoAssociacaoDeColunas>> QuestoesAssociacaoDeColunas { get; set; }

        /// <summary>
        /// Questões de Verdadeiro ou falso.
        /// </summary>
        public List<DtoQuestaoDaLista<DtoQuestaoVerdadeiroOuFalso>> QuestoesVerdadeiroOuFalso { get; set; }
    }
}
