namespace ListElab.Servico.Conversores.Interfaces
{
    public interface IConversor<D, T>
    {
        /// <summary>
        /// Converte de objeto para dto.
        /// </summary>
        /// <param name="objeto">Objeto a ser convertido.</param>
        /// <returns>Retorna o objeto convertido.</returns>
        D Converta(T objeto);

        /// <summary>
        /// Converte de dto para objeto.
        /// </summary>
        /// <param name="dto">O dto a ser convertido.</param>
        /// <returns>O dto convertido.</returns>
        T Converta(D dto);
    }
}
