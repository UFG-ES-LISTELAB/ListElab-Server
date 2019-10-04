using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace listelab_data.Repositorios
{
    public interface IRepositorio<T>
    {
        /// <summary>
        /// Retorna a coleção do conceito genérico.
        /// </summary>
        /// <returns>Retorna a coleção do conceito.</returns>
        IMongoCollection<T> Collection();

        /// <summary>
        /// Cadastra um objeto de tipo genérico.
        /// </summary>
        /// <param name="objeto">Objeto a ser cadastrado.</param>
        void Cadastre(T objeto);

        /// <summary>
        /// Atualiza um objeto genérico no banco.
        /// </summary>
        /// <param name="condicao">Condição para atualização.</param>
        /// <param name="objeto">Objeto a ser atualizado.</param>
        void Atualize(Expression<Func<T, bool>> condicao, T objeto);

        /// <summary>
        /// Exclua todos os objetos que atendem determinada condição.
        /// </summary>
        /// <param name="condicao">Filtro que indica qual será excluído.</param>
        void Exclua(Expression<Func<T, bool>> condicao);

        /// <summary>
        /// Consulta o primeiro objeto genérico que atende uma condição.
        /// </summary>
        /// <param name="condicao">Filtro que indica qual será excluído.</param>
        /// <returns></returns>
        T Consulte(Expression<Func<T, bool>> condicao);

        /// <summary>
        /// Verifica se um item está cadastrado.
        /// </summary>
        /// <param name="condicao">Condição para se achar o item.</param>
        /// <returns>Retorna se o item está cadastrado.</returns>
        bool ItemExiste(Expression<Func<T, bool>> condicao);

        /// <summary>
        /// Consulta todos os objetos que obedecem uma condição.
        /// </summary>
        /// <param name="condicao">Filtro que indica qual será excluído.</param>
        /// <returns>Retorna uma coleção de objetos genéricos.</returns>
        IList<T> ConsulteLista(Expression<Func<T, bool>> condicao);
    }
}
