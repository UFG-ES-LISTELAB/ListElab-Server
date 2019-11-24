using System.Collections.Generic;

namespace ListElab.Dominio.Conceitos.RespostaObj
{
    /// <summary>
    /// Representa a reposta de associação de colunas.
    /// </summary>
    public class AssociacaoDeColunas
    {
        /// <summary>
        /// As colunas da resposta.
        /// </summary>
        public List<Colunas> Colunas { get; set; }
    }
}
