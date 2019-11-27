namespace ListElab.Servico.Conversores.Interfaces
{
    public interface IConversor<TDto, TObjeto>
    {
        /// <summary>
        /// Converte de objeto para dto.
        /// </summary>
        /// <param name="objeto">Objeto a ser convertido.</param>
        /// <returns>Retorna o objeto convertido.</returns>
        TDto Converta(TObjeto objeto);

        /// <summary>
        /// Converte de dto para objeto.
        /// </summary>
        /// <param name="dto">O dto a ser convertido.</param>
        /// <returns>O dto convertido.</returns>
        TObjeto Converta(TDto dto);
    }
}
