using System.Collections.Generic;

namespace ListElab.Dominio.Conceitos.RespostaObj
{
    /// <summary>
    /// Representa uma resposta verdadeira ou falsa.
    /// </summary>
    public class VerdadeiroOuFalso
    {
        /// <summary>
        /// Uma lista com todas as afirmações que podem ser verdadeiras ou falsas.
        /// </summary>
        public List<Escolha> Afirmacao { get; set; }

    }
}
