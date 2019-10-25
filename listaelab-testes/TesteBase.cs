using ListElab.Dominio.Abstrato;
using ListElab.Servico.Validacoes;
using NUnit.Framework;

namespace ListElab.Testes
{
    public abstract class TesteBase<T> where T : ObjetoComId
    {
        public void EfetueChecagem(bool ehParaDarErro, T objetoValidado, ValidadorPadrao<T> validador, string mensagem)
        {
            var resultado = validador.Validate(objetoValidado);

            if (ehParaDarErro)
            {
                Assert.IsFalse(resultado.IsValid);
                Assert.AreEqual(resultado.Errors[0].ErrorMessage, mensagem);
            }
            else
            {
                Assert.IsTrue(resultado.IsValid);
            }
        }
    }
}
