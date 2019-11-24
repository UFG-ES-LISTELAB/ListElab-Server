namespace ListElab.Dominio.Dtos
{
    /// <summary>
    /// Representa as colunas da associação de colunas.
    /// </summary>
    public class DtoColunas
    {
        /// <summary>
        /// Representa a coluna principal.
        /// </summary>
        public DtoColuna ColunaPrincipal { get; set; }

        /// <summary>
        /// Representa a coluna que se associa a principal.
        /// </summary>
        public DtoColuna ColunaAssociada { get; set; }
    }
}
