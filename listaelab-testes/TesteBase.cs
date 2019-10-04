using listelab_dominio.Abstrato;
using listelab_servico.Validacoes;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace listaelab_testes
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
