using System.Collections.Generic;

namespace ListElab.Dominio.Dtos
{
    public class DtoQuestaoAssociacaoDeColunas : DtoQuestao
    {
        /// <summary>
        /// Representa os insumos para resposta.
        /// </summary>
        public List<DtoColunas> RespostaEsperada { get; set; }
    }
}
