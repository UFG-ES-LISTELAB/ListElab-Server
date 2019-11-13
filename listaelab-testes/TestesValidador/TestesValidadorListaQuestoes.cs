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
        private ValidacoesListaQuestoes _validador;

        [SetUp]
        public void AntesDoTeste()
        {
            _validador = new ValidacoesListaQuestoes();
        }

        [Test, Sequential]
        public void TesteRegraListaDeveTerTitulo(
            [Values(null, "", "Titulo.", " ")] string titulo,
            [Values(true, true, false, true)] bool cenarioInvalido)
        {
            _validador.AssineRegraListaDeveTerTitulo();

            var listaQuestoes = new ListaQuestoes { Titulo = titulo };

            ValideTeste(cenarioInvalido, listaQuestoes, _validador, "O título da lista de questões deve ser informado");
        }

        [Test, Sequential]
        public void TesteRegraListaDeveTerUsuario(
            [Values(null, "", "Titulo.", " ")] string usuario,
            [Values(true, true, false, true)] bool cenarioInvalido)
        {
            _validador.AssineRegraListaDeveTerUsuario();

            var listaQuestoes = new ListaQuestoes { Usuario = usuario };

            ValideTeste(cenarioInvalido, listaQuestoes, _validador, "O autor da lista de questões deve ser informado");
        }

        [Test, Theory]
        public void TesteRegraListaDeveTerQuestoes(bool temQuestoes)
        {
            _validador.AssineRegraListaDeveTerQuestoes();

            var listaQuestoes = new ListaQuestoes();

            listaQuestoes.Questoes = temQuestoes ? new List<QuestaoDaLista> { new QuestaoDaLista() } : null;

            ValideTeste(!temQuestoes, listaQuestoes, _validador, "É preciso informar as questões que compõe uma lista, certifique-se de que os ids das questões foram repassados à requisição");
        }
    }
}
