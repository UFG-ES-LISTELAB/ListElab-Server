using listelab_dominio.Conceitos;
using listelab_dominio.Conceitos.Questao;
using listelab_dominio.Conceitos.Resposta;
using listelab_servico.Validacoes;
using NUnit.Framework;
using System.Collections.Generic;

namespace listaelab_testes.TestesValidador
{
    [TestFixture]
    public class TestesValidadorQuestaoDiscursiva : TesteBase<Questao<Discursiva>>
    {
        private ValidacoesQuestaoDiscursiva _validador;

        [SetUp]
        public void AntesDoTeste()
        {
            _validador = new ValidacoesQuestaoDiscursiva();
        }

        [Test, Sequential]
        public void TesteRegraCodigoValido(
            [Values(-1, 0, 1, 10000)] int codigo,
            [Values(true, true, false, true)] bool ehParaDarErro)
        {
            //_validador.AssineRegraCodigoValido();

            //var questaoDiscursiva = new QuestaoDiscursiva { Codigo = codigo };

            //EfetueChecagem(ehParaDarErro, questaoDiscursiva, _validador, "O código da questão deve ser superior à 0 e menor ou igual à 9999");
        }

        [Test, Sequential]
        public void TesteRegraDeveTerEnunciado(
            [Values(null, "", "Enunciado.", " ")] string enunciado,
            [Values(true, true, false, true)] bool ehParaDarErro)
        {
            //_validador.AssineRegraDeveTerEnunciado();

            //var questaoDiscursiva = new QuestaoDiscursiva { Enunciado = enunciado };

            //EfetueChecagem(ehParaDarErro, questaoDiscursiva, _validador, "O enunciado da questão deve ser informado");
        }

        [Test, Theory]
        public void TesteRegraPalavraChaveInformado(bool palavraChaveInformado)
        {
            _validador.AssineRegraPalavraChaveInformado();

            //var questaoDiscursiva = palavraChaveInformado ? new Questao<Discursiva>()
            //{
            //    RespostaEsperada = new Discursiva
            //    {
            //        PalavrasChaves = new List<PalavraChave>
            //        {
            //            new PalavrasChaves
            //            {
            //                PalavraChave = "Dilma",
            //                Peso = 10
            //            }
            //        }
            //    }
            //} : new QuestaoDiscursiva { RespostaEsperada = new RespostaDiscursiva() };

            //EfetueChecagem(!palavraChaveInformado, questaoDiscursiva, _validador, "Pelo menos uma palavra chave deve ser informada");
        }
    }
}
