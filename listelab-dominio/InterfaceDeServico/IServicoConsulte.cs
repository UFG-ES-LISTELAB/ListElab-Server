using System.Collections.Generic;

namespace ListElab.Dominio.InterfaceDeServico
{
    public interface IServicoConsulte<TObjeto>
    {
        /// <summary>
        /// Consulta um conceito por id.
        /// </summary>
        /// <param name="codigo">O código a ser pesquisado.</param>
        /// <returns>Retorna o conceito que possui aquele id.</returns>
        TObjeto Consulte(string codigo);

        /// <summary>
        /// Consulta todos os objetos que obedecem uma condição.
        /// </summary>
        /// <returns>Retorna uma coleção de objetos genéricos.</returns>
        IList<TObjeto> ConsulteLista();
    }
}
