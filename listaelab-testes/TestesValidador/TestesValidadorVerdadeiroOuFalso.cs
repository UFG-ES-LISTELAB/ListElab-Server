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
    public class TestesValidadorVerdadeiroOuFalso : TesteBase<Questao<VerdadeiroOuFalso>>
    {
        private ValidacoesQuestaoVerdadeiroOuFalso validador;

        [SetUp]
        public void AntesDoTeste()
        {
            validador = new ValidacoesQuestaoVerdadeiroOuFalso();
        }

        [Test, Sequential]
        public void TesteRegraDeveTerEnunciado(
            [Values(null, "", "Enunciado.", " ")] string enunciado,
            [Values(true, true, false, true)] bool cenarioInvalido)
        {
            validador.AssineRegraDeveTerEnunciado();

            var questaoVerdadeiroOuFalso = new Questao<VerdadeiroOuFalso> { Enunciado = enunciado };

            ValideTeste(cenarioInvalido, questaoVerdadeiroOuFalso, validador, "O enunciado da questão deve ser informado");
        }

        [Test, Theory]
        public void TesteRegraQuestaoVerdadeiroOuFalsoPossuiDuasOuMaisAlternativas(bool palavraChaveInformado)
        {
            validador.AssineRegraQuestaoVerdadeiroOuFalsoPossuiDuasOuMaisAlternativas();

            var questaoVerdadeiroOuFalso = palavraChaveInformado ? new Questao<VerdadeiroOuFalso>()
            {
                RespostaEsperada = new VerdadeiroOuFalso
                {
                    Afirmacao = new List<Escolha>
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
            } : new Questao<VerdadeiroOuFalso> { RespostaEsperada = new VerdadeiroOuFalso() };

            ValideTeste(!palavraChaveInformado, questaoVerdadeiroOuFalso, validador, "O tipo de questão 'Verdadeiro ou Falso' deve possuir uma ou mais alternativas.");
        }

        [Test, Theory]
        public void TesteRegraEscolhasNaoDevemSerVazias(bool palavraChaveInformado)
        {
            validador.AssineRegraEscolhasNaoDevemSerVazias();

            var questaoVerdadeiroOuFalso = palavraChaveInformado ? new Questao<VerdadeiroOuFalso>()
            {
                RespostaEsperada = new VerdadeiroOuFalso
                {
                    Afirmacao = new List<Escolha>
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
            } : new Questao<VerdadeiroOuFalso> { RespostaEsperada = new VerdadeiroOuFalso() };

            ValideTeste(!palavraChaveInformado, questaoVerdadeiroOuFalso, validador, "As escolhas da questão não podem ser vazias.");
        }

        [Test, Theory]
        public void TesteRegraEscolhaDevePossuirAlternativaCorreta(bool palavraChaveInformado)
        {
            validador.AssineRegraEscolhaDevePossuirAlternativaCorreta();

            var questaoVerdadeiroOuFalso = palavraChaveInformado ? new Questao<VerdadeiroOuFalso>()
            {
                RespostaEsperada = new VerdadeiroOuFalso
                {
                    Afirmacao = new List<Escolha>
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
            } : new Questao<VerdadeiroOuFalso> { RespostaEsperada = new VerdadeiroOuFalso() };

            ValideTeste(!palavraChaveInformado, questaoVerdadeiroOuFalso, validador, "Ao menos uma questão deve ser a alternativa correta.");
        }

        [Test, Sequential]
        public void TesteRegraAutorDaQuestaoInformadoEValido([Values("", " ", null, "saulo@gmail.com", "saulo@ufg.br")] string autor,
                                                             [Values(true, true, true, true, false)] bool cenarioInvalido)
        {
            validador.AssineRegraAutorDaQuestaoInformadoEValido();

            var questaoVerdadeiroOuFalso = new Questao<VerdadeiroOuFalso> { Usuario = autor };

            ValideTeste(cenarioInvalido, questaoVerdadeiroOuFalso, validador, "O autor da questão deve ser um usuário válido");
        }

        [Test, Sequential]
        public void TesteRegraTipoQuestaoVerdadeiroOuFalso([Values(TipoQuestao.VerdadeiroOuFalso, TipoQuestao.Discursiva)] TipoQuestao tipoQuestao,
                                                    [Values(false, true)] bool cenarioInvalido)
        {
            validador.AssineRegraTipoQuestaoVerdadeiroOuFalso();

            var questaoVerdadeiroOuFalso = new Questao<VerdadeiroOuFalso> { Tipo = tipoQuestao };

            ValideTeste(cenarioInvalido, questaoVerdadeiroOuFalso, validador, "O tipo de questão deve ser 'Verdadeiro ou Falso'");
        }

        [Test, Sequential]
        public void TesteRegraDificuldadeFoiInformadaEValida([Values(1, 5, 6)] int dificuldade,
                                                             [Values(false, false, true)] bool cenarioInvalido)
        {
            validador.AssineRegraDificuldadeFoiInformadaEValida();

            var questaoVerdadeiroOuFalso = new Questao<VerdadeiroOuFalso> { NivelDificuldade = (NivelDificuldade)dificuldade };

            ValideTeste(cenarioInvalido, questaoVerdadeiroOuFalso, validador, "Informe um valor válido para nível de dificuldade");
        }

        [Test, Theory]
        public void TesteRegraAreaDeConhecimentoFoiInformada(bool areaDoConhecimentoInformada, bool codigoInformado)
        {
            validador.AssineRegraAreaDeConhecimentoFoiInformada();

            var questaoVerdadeiroOuFalso = new Questao<VerdadeiroOuFalso>();

            if (areaDoConhecimentoInformada)
            {
                questaoVerdadeiroOuFalso.AreaDeConhecimento = new AreaDeConhecimento();
            }

            if (areaDoConhecimentoInformada && codigoInformado)
            {
                questaoVerdadeiroOuFalso.AreaDeConhecimento.Codigo = "100";
            }

            ValideTeste(!areaDoConhecimentoInformada || !codigoInformado, questaoVerdadeiroOuFalso, validador, "Área de conhecimento não informada ou inválida.");
        }

        [Test, Theory]
        public void TesteRegraDisciplinaFoiInformada(bool discipinaInformada, bool codigoInformado)
        {
            validador.AssineRegraDisciplinaFoiInformada();

            var questaoVerdadeiroOuFalso = new Questao<VerdadeiroOuFalso>();

            if (discipinaInformada)
            {
                questaoVerdadeiroOuFalso.Disciplina = new Disciplina();
            }

            if (discipinaInformada && codigoInformado)
            {
                questaoVerdadeiroOuFalso.Disciplina.Codigo = "100";
            }

            ValideTeste(!discipinaInformada || !codigoInformado, questaoVerdadeiroOuFalso, validador, "Disciplina não informada ou inválida.");
        }
    }
}
