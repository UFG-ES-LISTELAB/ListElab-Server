using System.Collections.Generic;

namespace ListElab.Dominio.Dtos
{
    /// <summary>
    /// Dto de questão de associação de colunas.
    /// </summary>
    public class DtoAssociacaoDeColunas
    {
        /// <summary>
        /// As colunas da resposta.
        /// </summary>
        public List<DtoColunas> Colunas { get; set; }
    }
}
