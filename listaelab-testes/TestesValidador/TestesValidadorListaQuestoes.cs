using ListElab.Dominio.Conceitos.ListaObj;
using ListElab.Dominio.Conceitos.QuestaoObj;
using ListElab.Dominio.Conceitos.RespostaObj;
using ListElab.Servico.Validacoes;
using ListElab.Testes;
using NUnit.Framework;
using System.Collections.Generic;

namespace ListaElab.Testes.TestesValidador
{
    /// <summary>
    /// Testes referente à lista de questões.
    /// </summary>
    public class TestesValidadorListaQuestoes : TesteBase<ListaQuestoes>
    {
        private ValidacoesListaQuestoes validador;

        [SetUp]
        public void AntesDoTeste()
        {
            validador = new ValidacoesListaQuestoes();
        }

        [Test, Sequential]
        public void TesteRegraListaDeveTerTitulo(
            [Values(null, "", "Titulo.", " ")] string titulo,
            [Values(true, true, false, true)] bool cenarioInvalido)
        {
            validador.AssineRegraListaDeveTerTitulo();

            var listaQuestoes = new ListaQuestoes { Titulo = titulo };

            ValideTeste(cenarioInvalido, listaQuestoes, validador, "O título da lista de questões deve ser informado");
        }

        [Test, Sequential]
        public void TesteRegraListaDeveTerUsuario(
            [Values(null, "", "Titulo.", " ")] string usuario,
            [Values(true, true, false, true)] bool cenarioInvalido)
        {
            validador.AssineRegraListaDeveTerUsuario();

            var listaQuestoes = new ListaQuestoes { Usuario = usuario };

            ValideTeste(cenarioInvalido, listaQuestoes, validador, "O autor da lista de questões deve ser informado");
        }

        [Test, Theory]
        public void TesteRegraListaDeveTerQuestoes(bool temQuestoes)
        {
            validador.AssineRegraListaDeveTerQuestoes();

            var listaQuestoes = new ListaQuestoes();

            listaQuestoes.QuestoesDiscursivas = temQuestoes ? new List<QuestaoDaLista<Discursiva>> { new QuestaoDaLista<Discursiva>() } : null;

            ValideTeste(!temQuestoes, listaQuestoes, validador, "É preciso informar as questões que compõe uma lista, certifique-se de que os iBds das questões foram repassados à requisição");
        }
    }
}
