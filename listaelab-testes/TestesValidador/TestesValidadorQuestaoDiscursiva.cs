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
        private ValidacoesQuestaoDiscursiva _validador;

        [SetUp]
        public void AntesDoTeste()
        {
            _validador = new ValidacoesQuestaoDiscursiva();
        }

        [Test, Sequential]
        public void TesteRegraDeveTerEnunciado(
            [Values(null, "", "Enunciado.", " ")] string enunciado,
            [Values(true, true, false, true)] bool cenarioInvalido)
        {
            _validador.AssineRegraDeveTerEnunciado();

            var questaoDiscursiva = new Questao<Discursiva> { Enunciado = enunciado };

            ValideTeste(cenarioInvalido, questaoDiscursiva, _validador, "O enunciado da questão deve ser informado");
        }

        [Test, Theory]
        public void TesteRegraPalavraChaveInformado(bool palavraChaveInformado)
        {
            _validador.AssineRegraPalavraChaveInformada();

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

            ValideTeste(!palavraChaveInformado, questaoDiscursiva, _validador, "Pelo menos uma palavra chave deve ser informada");
        }

        [Test, Sequential]
        public void TesteRegraAutorDaQuestaoInformadoEValido([Values("", " ", null, "saulo@gmail.com", "saulo@ufg.br")] string autor,
                                                             [Values(true, true, true, true, false)] bool cenarioInvalido)
        {
            _validador.AssineRegraAutorDaQuestaoInformadoEValido();

            var questaoDiscursiva = new Questao<Discursiva> { Usuario = autor };

            ValideTeste(cenarioInvalido, questaoDiscursiva, _validador, "O autor da questão deve ser um usuário válido");
        }

        [Test, Sequential]
        public void TesteRegraTipoQuestaoDiscursiva([Values(TipoQuestao.Discursiva, TipoQuestao.Objetiva)] TipoQuestao tipoQuestao,
                                                    [Values(false, true)] bool cenarioInvalido)
        {
            _validador.AssineRegraTipoQuestaoDiscursiva();

            var questaoDiscursiva = new Questao<Discursiva> { Tipo = tipoQuestao };

            ValideTeste(cenarioInvalido, questaoDiscursiva, _validador, "O tipo de questão deve ser 'Discursiva'");
        }

        [Test, Sequential]
        public void TesteRegraDificuldadeFoiInformadaEValida([Values(1, 5, 6)] int dificuldade,
                                                             [Values(false, false, true)] bool cenarioInvalido)
        {
            _validador.AssineRegraDificuldadeFoiInformadaEValida();

            var questaoDiscursiva = new Questao<Discursiva> { NivelDificuldade = (NivelDificuldade)dificuldade };

            ValideTeste(cenarioInvalido, questaoDiscursiva, _validador, "Informe um valor válido para nível de dificuldade");
        }

        [Test, Theory]
        public void TesteRegraAreaDeConhecimentoFoiInformada(bool areaDoConhecimentoInformada, bool codigoInformado)
        {
            _validador.AssineRegraAreaDeConhecimentoFoiInformada();

            var questaoDiscursiva = new Questao<Discursiva>();

            if (areaDoConhecimentoInformada)
            {
                questaoDiscursiva.AreaDeConhecimento = new AreaDeConhecimento();
            }

            if (areaDoConhecimentoInformada && codigoInformado)
            {
                questaoDiscursiva.AreaDeConhecimento.Codigo = "100";
            }

            ValideTeste(!areaDoConhecimentoInformada || !codigoInformado, questaoDiscursiva, _validador, "Área de conhecimento não informada ou inválida.");
        }

        [Test, Theory]
        public void TesteRegraDisciplinaFoiInformada(bool discipinaInformada, bool codigoInformado)
        {
            _validador.AssineRegraDisciplinaFoiInformada();

            var questaoDiscursiva = new Questao<Discursiva>();

            if (discipinaInformada)
            {
                questaoDiscursiva.Disciplina = new Disciplina();
            }

            if (discipinaInformada && codigoInformado)
            {
                questaoDiscursiva.Disciplina.Codigo = "100";
            }

            ValideTeste(!discipinaInformada || !codigoInformado, questaoDiscursiva, _validador, "Disciplina não informada ou inválida.");
        }
    }
}
