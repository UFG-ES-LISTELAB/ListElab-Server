namespace ListElab.Dominio.Dtos
{
    /// <summary>
    /// Dto de objeto com código e descrição.
    /// </summary>
    public abstract class DtoCodigoDescricao
    {
        /// <summary>
        /// Código do conceito.
        /// </summary>
        public string Codigo { get; set; }

        /// <summary>
        /// Descrição do conceito.
        /// </summary>
        public string Descricao { get; set; }
    }
}
