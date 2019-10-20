using listelab_data.Repositorios;
using listelab_dominio.Abstrato;
using listelab_dominio.InterfaceDeServico;
using listelab_servico.Validacoes;
using System;
using System.Collections.Generic;

namespace listelab_servico.Servico
{
    public abstract class ServicoPadrao<T> : IServicoPadrao<T> where T : ObjetoComId
    {
        /// <summary>
        /// Atualiza um objeto genérico no banco.
        /// </summary>
        /// <param name="objeto">Objeto a ser atualizado.</param>
        public T Atualize(T objeto)
        {
            Validador().AssineRegrasAtualizacao();

            Validador().Valide(objeto);

            Repositorio().Atualize(x => x.Id == objeto.Id, objeto);
            
            return objeto;
        }

        /// <summary>
        /// Cadastra um objeto de tipo genérico.
        /// </summary>
        /// <param name="objeto">Objeto a ser cadastrado.</param>
        public virtual T Cadastre(T objeto)
        {
            Validador().AssineRegrasCadastro();

            Validador().Valide(objeto);

            Repositorio().Cadastre(objeto);

            return objeto;
        }

        /// <summary>
        /// Consulta um conceito por id.
        /// </summary>
        /// <param name="id">O id a ser pesquisado.</param>
        /// <returns>Retorna o conceito que possui aquele id.</returns>
        public T Consulte(string id)
        {
            T resultado = null;

            try
            {
                if (Guid.TryParse(id, out Guid idConvertido))
                {
                    resultado = Repositorio().ConsulteUm(x => x.Id == idConvertido);
                }
            } catch(Exception e)
            {
                throw new Exception("Id passado não é valido ou não está cadastrado.");
            }

            return resultado;
        }

        /// <summary>
        /// Consulta todos os objetos que obedecem uma condição.
        /// </summary>
        /// <returns>Retorna uma coleção de objetos genéricos.</returns>
        public virtual IList<T> ConsulteLista()
        {
            return Repositorio().ConsulteLista(x => true);
        }

        /// <summary>
        /// Exclua todos os objetos que atendem determinada condição.
        /// </summary>
        /// <param name="id">O id que será usado como filtro.</param>
        public virtual void Exclua(string id)
        {
            Guid idConvertido = Guid.Empty;

            if(Guid.TryParse(id, out idConvertido))
            {
                Repositorio().Exclua(x => x.Id == idConvertido);
            } else
            {
                throw new Exception("Id inválido.");
            }
        }

        protected abstract IRepositorio<T> Repositorio();

        protected abstract ValidadorPadrao<T> Validador();
    }
}
