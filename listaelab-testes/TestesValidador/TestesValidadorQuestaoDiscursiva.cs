using ListElab.Dominio.Conceitos.AreaDeConhecimentoObj;
using ListElab.Dominio.Conceitos.DisciplinaObj;
using ListElab.Dominio.Conceitos.QuestaoObj;
using ListElab.Dominio.Conceitos.RespostaObj;
using ListElab.Dominio.Enumeradores;
using ListElab.Servico.Validacoes;
using NUnit.Framework;
using System.Collections.Generic;

namespace ListElab.Testes.TestesValidador
{
    [TestFixture]
    public class TestesValidadorQuestaoDiscursiva : TesteBase<Questao<Discursiva>>
    {
        private ValidacoesQuestaoDiscursiva validador;

        [SetUp]
        public void AntesDoTeste()
        {
            validador = new ValidacoesQuestaoDiscursiva();
        }

        [Test, Sequential]
        public void TesteRegraDeveTerEnunciado(
            [Values(null, "", "Enunciado.", " ")] string enunciado,
            [Values(true, true, false, true)] bool cenarioInvalido)
        {
            validador.AssineRegraDeveTerEnunciado();

            var questaoDiscursiva = new Questao<Discursiva> { Enunciado = enunciado };

            ValideTeste(cenarioInvalido, questaoDiscursiva, validador, "O enunciado da questão deve ser informado");
        }

        [Test, Theory]
        public void TesteRegraPalavraChaveInformado(bool palavraChaveInformado)
        {
            validador.AssineRegraPalavraChaveInformada();

            var questaoDiscursiva = palavraChaveInformado ? new Questao<Discursiva>()
            {
                RespostaEsperada = new Discursiva
                {
                    PalavrasChaves = new List<PalavraChave>
                    {
                        new PalavraChave
                        {
                            Descricao = "Dilma",
                            Peso = 10
                        }
                    }
                }
            } : new Questao<Discursiva> { RespostaEsperada = new Discursiva() };

            ValideTeste(!palavraChaveInformado, questaoDiscursiva, validador, "Pelo menos uma palavra chave deve ser informada");
        }

        [Test, Sequential]
        public void TesteRegraAutorDaQuestaoInformadoEValido([Values("", " ", null, "saulo@gmail.com", "saulo@ufg.br")] string autor,
                                                             [Values(true, true, true, true, false)] bool cenarioInvalido)
        {
            validador.AssineRegraAutorDaQuestaoInformadoEValido();

            var questaoDiscursiva = new Questao<Discursiva> { Usuario = autor };

            ValideTeste(cenarioInvalido, questaoDiscursiva, validador, "O autor da questão deve ser um usuário válido");
        }

        [Test, Sequential]
        public void TesteRegraTipoQuestaoDiscursiva([Values(TipoQuestao.Discursiva, TipoQuestao.Objetiva)] TipoQuestao tipoQuestao,
                                                    [Values(false, true)] bool cenarioInvalido)
        {
            validador.AssineRegraTipoQuestaoDiscursiva();

            var questaoDiscursiva = new Questao<Discursiva> { Tipo = tipoQuestao };

            ValideTeste(cenarioInvalido, questaoDiscursiva, validador, "O tipo de questão deve ser 'Discursiva'");
        }

        [Test, Sequential]
        public void TesteRegraDificuldadeFoiInformadaEValida([Values(1, 5, 6)] int dificuldade,
                                                             [Values(false, false, true)] bool cenarioInvalido)
        {
            validador.AssineRegraDificuldadeFoiInformadaEValida();

            var questaoDiscursiva = new Questao<Discursiva> { NivelDificuldade = (NivelDificuldade)dificuldade };

            ValideTeste(cenarioInvalido, questaoDiscursiva, validador, "Informe um valor válido para nível de dificuldade");
        }

        [Test, Theory]
        public void TesteRegraAreaDeConhecimentoFoiInformada(bool areaDoConhecimentoInformada, bool codigoInformado)
        {
            validador.AssineRegraAreaDeConhecimentoFoiInformada();

            var questaoDiscursiva = new Questao<Discursiva>();

            if (areaDoConhecimentoInformada)
            {
                questaoDiscursiva.AreaDeConhecimento = new AreaDeConhecimento();
            }

            if (areaDoConhecimentoInformada && codigoInformado)
            {
                questaoDiscursiva.AreaDeConhecimento.Codigo = "100";
            }

            ValideTeste(!areaDoConhecimentoInformada || !codigoInformado, questaoDiscursiva, validador, "Área de conhecimento não informada ou inválida.");
        }

        [Test, Theory]
        public void TesteRegraDisciplinaFoiInformada(bool discipinaInformada, bool codigoInformado)
        {
            validador.AssineRegraDisciplinaFoiInformada();

            var questaoDiscursiva = new Questao<Discursiva>();

            if (discipinaInformada)
            {
                questaoDiscursiva.Disciplina = new Disciplina();
            }

            if (discipinaInformada && codigoInformado)
            {
                questaoDiscursiva.Disciplina.Codigo = "100";
            }

            ValideTeste(!discipinaInformada || !codigoInformado, questaoDiscursiva, validador, "Disciplina não informada ou inválida.");
        }
    }
}
