using ListElab.Dominio.Conceitos.QuestaoObj;
using ListElab.Dominio.Conceitos.RespostaObj;

namespace ListElab.Dominio.Conceitos.ListaObj
{
    /// <summary>
    /// Representa questões que compõe uma lista.
    /// </summary>
    public class QuestaoDaLista<TResposta>
    {
        /// <summary>
        /// Número da questão dentro da lista.
        /// </summary>
        public int Numero { get; set; }

        /// <summary>
        /// Peso da questão dentro da lista.
        /// </summary>
        public int Peso { get; set; }

        /// <summary>
        /// Questão da lista.
        /// </summary>
        public Questao<TResposta> Questao { get; set; }
    }
}
