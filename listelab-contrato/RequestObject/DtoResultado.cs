using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace listelab_contrato.RequestObject
{
    public class DtoResultado<T>
    {
        public string Mensagem { get; set; }
        public bool Sucesso { get; set; }
        public object Resultado { get; set; }

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
