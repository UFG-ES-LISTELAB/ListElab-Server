using System.Collections.Generic;

namespace ListElab.Dominio.InterfaceDeServico
{
    public interface IServicoCrudCompleto<TObjeto, TDto>
    {
        /// <summary>
        /// Cadastra um objeto de tipo genérico.
        /// </summary>
        /// <param name="objeto">Objeto a ser cadastrado.</param>
        TDto Cadastre(TDto objeto);

        /// <summary>
        /// Atualiza um objeto genérico no banco.
        /// </summary>
        /// <param name="objeto">Objeto a ser atualizado.</param>
        TDto Atualize(TDto objeto);

        /// <summary>
        /// Exclua todos os objetos que atendem determinada condição.
        /// </summary>
        /// <param name="id">O Id que será usado como filtro.</param>
        void Exclua(string id);

        /// <summary>
        /// Consulta o primeiro objeto genérico que atende uma condição.
        /// </summary>
        /// <param name="id">Id para pesquisar o objeto.</param>
        /// <returns></returns>
        TDto Consulte(string id);

        /// <summary>
        /// Consulta todos os objetos que obedecem uma condição.
        /// </summary>
        /// <returns>Retorna uma coleção de objetos genéricos.</returns>
        IList<TDto> ConsulteLista();
    }
}
