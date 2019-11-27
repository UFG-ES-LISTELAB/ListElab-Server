namespace ListElab.Dominio.Dtos
{
    /// <summary>
    /// Dto de escolha.
    /// </summary>
    public class DtoEscolha
    {
        /// <summary>
        /// Descrição da escolha.
        /// </summary>
        public string Descricao { get; set; }

        /// <summary>
        /// Define se questão é correta.
        /// </summary>
        public bool Correta { get; set; }
    }
}
