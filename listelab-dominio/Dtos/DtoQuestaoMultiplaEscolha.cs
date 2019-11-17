using System.Collections.Generic;

namespace ListElab.Dominio.Dtos
{
    public class DtoQuestaoMultiplaEscolha : DtoQuestao
    {
        /// <summary>
        /// Representa os insumos para resposta.
        /// </summary>
        public List<DtoEscolha> RespostaEsperada { get; set; }
    }
}
