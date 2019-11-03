using ListElab.Data.Repositorios;
using ListElab.Dominio.Abstrato;
using ListElab.Dominio.InterfaceDeServico;
using System.Collections.Generic;

namespace ListElab.Servico.ServicosImplementados
{
    public class ServicoConsulte<TObjeto> : IServicoConsulte<TObjeto> where TObjeto : ObjetoCodigoDescricao
    {
        private IRepositorio<TObjeto> repositorio;

        /// <summary>
        /// Consulta um conceito por id.
        /// </summary>
        /// <param name="codigo">O código a ser pesquisado.</param>
        /// <returns>Retorna o conceito que possui aquele id.</returns>
        public TObjeto Consulte(string codigo)
        {
            TObjeto resultado = null;

            resultado = Repositorio().ConsulteUm(x => x.Codigo == codigo);

            return resultado;
        }

        /// <summary>
        /// Consulta todos os objetos que obedecem uma condição.
        /// </summary>
        /// <returns>Retorna uma coleção de objetos genéricos.</returns>
        public virtual IList<TObjeto> ConsulteLista()
        {
            return Repositorio().ConsulteLista(x => true);
        }

        private IRepositorio<TObjeto> Repositorio()
        {
            return repositorio ?? (repositorio = new Repositorio<TObjeto>());
        }
    }
}
