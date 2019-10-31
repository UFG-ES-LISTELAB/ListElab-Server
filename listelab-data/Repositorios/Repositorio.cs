using ListElab.Dominio.AtributosCustomizados;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
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
