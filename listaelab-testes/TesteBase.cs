using ListElab.Dominio.Abstrato;
using ListElab.Servico.Validacoes;
using NUnit.Framework;

namespace ListElab.Testes
{
    public abstract class TesteBase<T> where T : ObjetoComId
    {
        /// <summary>
        /// Verifica se a validação foi acionada ou não.
        /// </summary>
        /// <param name="cenarioInvalido">True caso o cenário testado retorne uma inconsistência, False, caso não.</param>
        /// <param name="objetoValidado">O objeto a ser validado.</param>
        /// <param name="validador">O validador do cenário.</param>
        /// <param name="mensagemDeValidacao">A mensagem a ser retornada caso o cenário seja inválido.</param>
        public void ValideTeste(bool cenarioInvalido, T objetoValidado, ValidadorPadrao<T> validador, string mensagemDeValidacao)
        {
            var resultado = validador.Validate(objetoValidado);

            if (cenarioInvalido)
            {
                Assert.IsFalse(resultado.IsValid);
                Assert.AreEqual(resultado.Errors[0].ErrorMessage, mensagemDeValidacao);
            }
            else
            {
                Assert.IsTrue(resultado.IsValid);
            }
        }
    }
}
