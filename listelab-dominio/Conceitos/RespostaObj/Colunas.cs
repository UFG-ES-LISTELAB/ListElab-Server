namespace ListElab.Dominio.Conceitos.RespostaObj
{
    /// <summary>
    /// Representa as colunas de uma resposta de associação de colunas.
    /// </summary>
    public class Colunas
    {
        /// <summary>
        /// Representa a coluna principal.
        /// </summary>
        public Coluna ColunaPrincipal { get; set; }

        /// <summary>
        /// Representa a coluna que se associa a principal.
        /// </summary>
        public Coluna ColunaAssociada { get; set; }
    }
}
