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
    public class TestesValidadorMultiplaEscolha : TesteBase<Questao<MultiplaEscolha>>
    {
        private ValidacoesQuestaoMultiplaEscolha validador;

        [SetUp]
        public void AntesDoTeste()
        {
            validador = new ValidacoesQuestaoMultiplaEscolha();
        }

        [Test, Sequential]
        public void TesteRegraDeveTerEnunciado(
            [Values(null, "", "Enunciado.", " ")] string enunciado,
            [Values(true, true, false, true)] bool cenarioInvalido)
        {
            validador.AssineRegraDeveTerEnunciado();

            var questaoMultiplaEscolha = new Questao<MultiplaEscolha> { Enunciado = enunciado };

            ValideTeste(cenarioInvalido, questaoMultiplaEscolha, validador, "O enunciado da questão deve ser informado");
        }

        [Test, Theory]
        public void TesteRegraQuestaoMultiplaEscolhaPossuiDuasOuMaisAlternativas(bool palavraChaveInformado)
        {
            validador.AssineRegraQuestaoMultiplaEscolhaPossuiDuasOuMaisAlternativas();

            var questaoMultiplaEscolha = palavraChaveInformado ? new Questao<MultiplaEscolha>()
            {
                RespostaEsperada = new MultiplaEscolha
                {
                    Alternativas = new List<Escolha>
                    {
                        new Escolha
                        {
                            Descricao = "Pergunta de multipla escolha",
                            Correta = true
                        },
                        new Escolha
                        {
                            Descricao = "Pergunta de multipla escolha",
                            Correta = false
                        },
                        new Escolha
                        {
                            Descricao = "Pergunta de multipla escolha",
                            Correta = false
                        }
                    }
                }
            } : new Questao<MultiplaEscolha> { RespostaEsperada = new MultiplaEscolha() };

            ValideTeste(!palavraChaveInformado, questaoMultiplaEscolha, validador, "O tipo de questão 'Múltipla Escolha' deve possuir duas ou mais escolhas.");
        }

        [Test, Theory]
        public void TesteRegraEscolhasNaoDevemSerVazias(bool palavraChaveInformado)
        {
            validador.AssineRegraEscolhasNaoDevemSerVazias();

            var questaoMultiplaEscolha = palavraChaveInformado ? new Questao<MultiplaEscolha>()
            {
                RespostaEsperada = new MultiplaEscolha
                {
                    Alternativas = new List<Escolha>
                    {
                        new Escolha
                        {
                            Descricao = "Pergunta de multipla escolha",
                            Correta = true
                        },
                        new Escolha
                        {
                            Descricao = "Pergunta de multipla escolha",
                            Correta = false
                        },
                        new Escolha
                        {
                            Descricao = "Pergunta de multipla escolha",
                            Correta = false
                        }
                    }
                }
            } : new Questao<MultiplaEscolha> { RespostaEsperada = new MultiplaEscolha() };

            ValideTeste(!palavraChaveInformado, questaoMultiplaEscolha, validador, "As escolhas da questão não podem ser vazias.");
        }

        [Test, Theory]
        public void TesteRegraEscolhaDevePossuirAlternativaCorreta(bool palavraChaveInformado)
        {
            validador.AssineRegraEscolhaDevePossuirAlternativaCorreta();

            var questaoMultiplaEscolha = palavraChaveInformado ? new Questao<MultiplaEscolha>()
            {
                RespostaEsperada = new MultiplaEscolha
                {
                    Alternativas = new List<Escolha>
                    {
                        new Escolha
                        {
                            Descricao = "Pergunta de multipla escolha",
                            Correta = true
                        },
                        new Escolha
                        {
                            Descricao = "Pergunta de multipla escolha",
                            Correta = false
                        },
                        new Escolha
                        {
                            Descricao = "Pergunta de multipla escolha",
                            Correta = false
                        }
                    }
                }
            } : new Questao<MultiplaEscolha> { RespostaEsperada = new MultiplaEscolha() };

            ValideTeste(!palavraChaveInformado, questaoMultiplaEscolha, validador, "Ao menos uma questão deve ser a alternativa correta.");
        }

        [Test, Sequential]
        public void TesteRegraAutorDaQuestaoInformadoEValido([Values("", " ", null, "saulo@gmail.com", "saulo@ufg.br")] string autor,
                                                             [Values(true, true, true, true, false)] bool cenarioInvalido)
        {
            validador.AssineRegraAutorDaQuestaoInformadoEValido();

            var questaoMultiplaEscolha = new Questao<MultiplaEscolha> { Usuario = autor };

            ValideTeste(cenarioInvalido, questaoMultiplaEscolha, validador, "O autor da questão deve ser um usuário válido");
        }

        [Test, Sequential]
        public void TesteRegraTipoQuestaoMultiplaEscolha([Values(TipoQuestao.MultiplaEscolha, TipoQuestao.Discursiva)] TipoQuestao tipoQuestao,
                                                    [Values(false, true)] bool cenarioInvalido)
        {
            validador.AssineRegraTipoQuestaoMultiplaEscolha();

            var questaoMultiplaEscolha = new Questao<MultiplaEscolha> { Tipo = tipoQuestao };

            ValideTeste(cenarioInvalido, questaoMultiplaEscolha, validador, "O tipo de questão deve ser 'Múltipla Escolha'");
        }

        [Test, Sequential]
        public void TesteRegraDificuldadeFoiInformadaEValida([Values(1, 5, 6)] int dificuldade,
                                                             [Values(false, false, true)] bool cenarioInvalido)
        {
            validador.AssineRegraDificuldadeFoiInformadaEValida();

            var questaoMultiplaEscolha = new Questao<MultiplaEscolha> { NivelDificuldade = (NivelDificuldade)dificuldade };

            ValideTeste(cenarioInvalido, questaoMultiplaEscolha, validador, "Informe um valor válido para nível de dificuldade");
        }

        [Test, Theory]
        public void TesteRegraAreaDeConhecimentoFoiInformada(bool areaDoConhecimentoInformada, bool codigoInformado)
        {
            validador.AssineRegraAreaDeConhecimentoFoiInformada();

            var questaoMultiplaEscolha = new Questao<MultiplaEscolha>();

            if (areaDoConhecimentoInformada)
            {
                questaoMultiplaEscolha.AreaDeConhecimento = new AreaDeConhecimento();
            }

            if (areaDoConhecimentoInformada && codigoInformado)
            {
                questaoMultiplaEscolha.AreaDeConhecimento.Codigo = "100";
            }

            ValideTeste(!areaDoConhecimentoInformada || !codigoInformado, questaoMultiplaEscolha, validador, "Área de conhecimento não informada ou inválida.");
        }

        [Test, Theory]
        public void TesteRegraDisciplinaFoiInformada(bool discipinaInformada, bool codigoInformado)
        {
            validador.AssineRegraDisciplinaFoiInformada();

            var questaoMultiplaEscolha = new Questao<MultiplaEscolha>();

            if (discipinaInformada)
            {
                questaoMultiplaEscolha.Disciplina = new Disciplina();
            }

            if (discipinaInformada && codigoInformado)
            {
                questaoMultiplaEscolha.Disciplina.Codigo = "100";
            }

            ValideTeste(!discipinaInformada || !codigoInformado, questaoMultiplaEscolha, validador, "Disciplina não informada ou inválida.");
        }
    }
}
