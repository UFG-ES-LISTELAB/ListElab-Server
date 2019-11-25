using System.Collections.Generic;

namespace ListElab.Dominio.Dtos
{
    /// <summary>
    /// Representa uma questão do tipo verdadeirou ou falso.
    /// </summary>
    public class DtoQuestaoVerdadeiroOuFalso : DtoQuestao
    {
        /// <summary>
        /// Representa os insumos para resposta.
        /// </summary>
        public List<DtoEscolha> RespostaEsperada { get; set; }
    }
}
