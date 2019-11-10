namespace ListElab.Dominio.Dtos
{
    public class DtoErro
    {
        /// <summary>
        /// Mensagem retornada ao usuário.
        /// </summary>
        public string Mensagem { get; set; }

        /// <summary>
        /// Campo validado.
        /// </summary>
        public string Campo { get; set; }
    }
}
