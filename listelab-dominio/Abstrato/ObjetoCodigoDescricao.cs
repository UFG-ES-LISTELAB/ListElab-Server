namespace ListElab.Dominio.Abstrato
{
    public abstract class ObjetoCodigoDescricao : ObjetoComId
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
