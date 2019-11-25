namespace ListElab.Dominio.Conceitos.RespostaObj
{
    /// <summary>
    /// Representa uma escolha de uma questão.
    /// </summary>
    public class Escolha
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
