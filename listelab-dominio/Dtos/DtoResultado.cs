using System;

namespace ListElab.Dominio.Dtos
{
    /// <summary>
    /// Representa um objeto para transferência de dados.
    /// </summary>
    /// <typeparam name="T">O tipo de objeto de transferência de dados.</typeparam>
    public class DtoResultado<T>
    {
        /// <summary>
        /// Mensagem retornada ao usuário.
        /// </summary>
        public string Mensagem { get; set; }
        /// <summary>
        /// Se houve sucesso ou não.
        /// </summary>
        public bool Sucesso { get; set; }
        /// <summary>
        /// Objeto retornado como resposta.
        /// </summary>
        public object Resultado { get; set; }

        /// <summary>
        /// Campo validado.
        /// </summary>
        public string Campo { get; set; }

        /// <summary>
        /// Retorna um objeto de exceção.
        /// </summary>
        /// <param name="e">A mensagem da exception gerada.</param>
        /// <returns>Retorna o objeto com o erro.</returns>
        public static DtoResultado<T> ObtenhaResultado(Exception e)
        {
            return new DtoResultado<T>
            {
                Mensagem = e.Message,
                Resultado = null,
                Sucesso = false
            };
        }

        /// <summary>
        /// Retorna um objeto de exceção.
        /// </summary>
        /// <param name="e">A mensagem da exception gerada.</param>
        /// <returns>Retorna o objeto com o erro.</returns>
        public static DtoResultado<T> ObtenhaResultado(Exception e, string campo)
        {
            return new DtoResultado<T>
            {
                Mensagem = e.Message,
                Resultado = null,
                Campo = campo,
                Sucesso = false
            };
        }

        /// <summary>
        /// Cria um objeto sem retorno.
        /// </summary>
        /// <param name="menssagem">Mensagem a ser apresentada.</param>
        /// <returns>Retorna objeto sem retorno.</returns>
        public static DtoResultado<T> ObtenhaResultado(string menssagem)
        {
            return new DtoResultado<T>
            {
                Mensagem = menssagem,
                Resultado = null,
                Sucesso = true
            };
        }

        /// <summary>
        /// Cria um objeto com retorno.
        /// </summary>
        /// <param name="value">Valor de retorno.</param>
        /// <param name="menssagem">Mensagem de retorno.</param>
        /// <returns></returns>
        public static DtoResultado<T> ObtenhaResultado(object value, string menssagem)
        {
            return new DtoResultado<T>
            {
                Mensagem = menssagem,
                Resultado = value,
                Sucesso = true
            };
        }
    }
}
