using ListElab.Dominio.Enumeradores;
using System.Collections.Generic;

namespace ListElab.Dominio.Dtos
{
    /// <summary>
    /// Representa um dto de questão discursiva.
    /// </summary>
    public class DtoQuestaoDiscursiva : DtoQuestao
    {
        /// <summary>
        /// Representa os insumos para resposta.
        /// </summary>
        public List<DtoPalavraChave> RespostaEsperada { get; set; }
    }
}
