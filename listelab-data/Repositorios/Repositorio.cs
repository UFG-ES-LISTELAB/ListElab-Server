using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using listelab_dominio.CustomAttributes;
using MongoDB.Driver;

namespace listelab_data.Repositorios
{
    public class Repositorio<T> : IRepositorio<T>
    {
        private ConexaoDb _conexao;

        public IMongoCollection<T> Collection()
        {
            T objeto = Activator.CreateInstance<T>();

            var colecao = objeto.GetType().GetCustomAttributes(true)[0] as Colecao;

            var conexao = Conexao();

            return conexao.ConexaoMongoDB().GetCollection<T>(colecao.Nome);
        }

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

        public List<T> Consulte(Expression<Func<T, bool>> condicao)
        {
            return Collection().Find(condicao).ToList();
        }

        public bool ItemExiste(Expression<Func<T, bool>> condicao)
        {
            return Collection().CountDocuments(condicao) > 0;
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
                Console.WriteLine("Erro ao salvar no banco: " + e.Message);
                Conexao().Sessao.AbortTransaction();
            }
        }

        private ConexaoDb Conexao()
        {
            return _conexao ?? (_conexao = new ConexaoDb());
        }
    }
}
