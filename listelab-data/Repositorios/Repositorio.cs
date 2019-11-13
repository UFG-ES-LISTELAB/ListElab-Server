using ListElab.Dominio.AtributosCustomizados;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ListElab.Data.Repositorios
{
    public class Repositorio<T> : IRepositorio<T>
    {
        private ConexaoDb _conexao;

        /// <summary>
        /// Acessa a coleção do objeto passado no tipo genérico.
        /// </summary>
        /// <returns>Retorna uma conexão com o banco com a coleção do tipo passado.</returns>
        public IMongoCollection<T> Collection()
        {
            T objeto = Activator.CreateInstance<T>();

            var colecao = objeto.GetType().GetCustomAttributes(true)[0] as Colecao;

            var conexao = Conexao();

            return conexao.ConexaoMongoDB().GetCollection<T>(colecao.Nome);
        }

        /// <summary>
        /// Atualiza um objeto no banco.
        /// </summary>
        /// <param name="condicao">Condição para verificar qual objeto será atualizado.</param>
        /// <param name="objeto">Objeto atualizado para ser persistido.</param>
        public void Atualize(Expression<Func<T, bool>> condicao, T objeto)
        {
            ExecuteAcaoNoBanco(() =>
            {
                Collection().ReplaceOne(condicao, objeto);
            });
        }

        public void Cadastre(T objeto)
        {
            ExecuteAcaoNoBanco(() =>
            {
                Collection().InsertOne(objeto);
            });
        }

        public T ConsulteUm(Expression<Func<T, bool>> condicao)
        {
            return Collection().Find(condicao).FirstOrDefault();
        }

        public List<T> Filtre(Expression<Func<T, bool>>[] condicao)
        {
            var builder = Builders<T>.Filter;

            var listaFiltro = condicao.ToList().Select(x => builder.Where(x));

            var filtro = builder.And(listaFiltro);

            return Collection().Find(filtro).ToList();
        }

        /// <summary>
        /// Consulte uma lista de conceitos que correspondem a um id.
        /// </summary>
        /// <param name="campo">O campo a ser pesquisado.</param>
        /// <param name="ids">Os ids de a serem pesquisados.</param>
        /// <returns></returns>
        public List<T> ConsulteListaDeIds(Expression<Func<T, Guid>> campo, Guid[] ids)
        {
            var definicaoDeFiltro = new FilterDefinitionBuilder<T>();
            var filtro = definicaoDeFiltro.In(campo, ids);

            return Collection().Find(filtro).ToList();
        }

        public bool ItemExiste(Expression<Func<T, bool>> condicao)
        {
            return Collection().CountDocuments(condicao) > 0;
        }

        public List<T> Consulte(Expression<Func<T, bool>> condicao)
        {
            return Collection().Find(condicao).ToList();
        }

        public IList<T> ConsulteLista(Expression<Func<T, bool>> condicao)
        {

            return Collection().Find(condicao).ToList();
        }

        public void Exclua(Expression<Func<T, bool>> condicao)
        {
            ExecuteAcaoNoBanco(() =>
            {
                Collection().DeleteOne(condicao);
            });
        }

        private void ExecuteAcaoNoBanco(Action execute)
        {
            Conexao().Sessao.StartTransaction();

            try
            {
                execute.Invoke();
                Conexao().Sessao.CommitTransaction();
            }
            catch (Exception e)
            {
                Conexao().Sessao.AbortTransaction();
                throw new Exception("Ocorreu um erro ao manipular o banco de dados: " + e.Message);
            }
        }

        private ConexaoDb Conexao()
        {
            return _conexao ?? (_conexao = new ConexaoDb());
        }
    }
}
