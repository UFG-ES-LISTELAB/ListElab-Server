namespace ListElab.Dominio.Dtos
{
    public class DtoQuestaoDaLista<TDtoQuestao>
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
        public TDtoQuestao Questao { get; set; }
    }
}
