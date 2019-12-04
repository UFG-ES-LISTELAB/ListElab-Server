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
    public class TestesValidadorAssociacaoDeColunas : TesteBase<Questao<AssociacaoDeColunas>>
    {
        private ValidacoesQuestaoAssociacaoDeColuna validador;

        [SetUp]
        public void AntesDoTeste()
        {
            validador = new ValidacoesQuestaoAssociacaoDeColuna();
        }

        [Test, Sequential]
        public void TesteRegraDeveTerEnunciado(
            [Values(null, "", "Enunciado.", " ")] string enunciado,
            [Values(true, true, false, true)] bool cenarioInvalido)
        {
            validador.AssineRegraDeveTerEnunciado();

            var questaoAssociacaoDeColunas = new Questao<AssociacaoDeColunas> { Enunciado = enunciado };

            ValideTeste(cenarioInvalido, questaoAssociacaoDeColunas, validador, "O enunciado da questão deve ser informado");
        }

        [Test, Theory]
        public void TesteRegraColunaPrincipalPossuiItem(bool palavraChaveInformado)
        {
            validador.AssineRegraColunaPrincipalPossuiItem();

            var questaoAssociacaoDeColunas = palavraChaveInformado ? new Questao<AssociacaoDeColunas>()
            {
                RespostaEsperada = new AssociacaoDeColunas
                {
                    Colunas = new List<Colunas>
                    {
                        new Colunas
                        {
                            ColunaPrincipal = new Coluna
                            {
                                Letra = "a",
                                Descricao = "Pergunta A"
                            },
                            ColunaAssociada = new Coluna
                            {
                                Letra = "i",
                                Descricao = "Resposta da A"
                            }
                        },
                        new Colunas
                        {
                            ColunaPrincipal = new Coluna
                            {
                                Letra = "b",
                                Descricao = "Pergunta B"
                            },
                            ColunaAssociada = new Coluna
                            {
                                Letra = "ii",
                                Descricao = "Resposta da B"
                            }
                        }
                    }
                }
            } : new Questao<AssociacaoDeColunas> { RespostaEsperada = new AssociacaoDeColunas() };

            ValideTeste(!palavraChaveInformado, questaoAssociacaoDeColunas, validador, "A coluna principal deve possuir pelo menos algum item.");
        }

        [Test, Theory]
        public void TesteRegraColunaAssociadaPossuiItem(bool palavraChaveInformado)
        {
            validador.AssineRegraColunaAssociadaPossuiItem();

            var questaoAssociacaoDeColunas = palavraChaveInformado ? new Questao<AssociacaoDeColunas>()
            {
                RespostaEsperada = new AssociacaoDeColunas
                {
                    Colunas = new List<Colunas>
                    {
                        new Colunas
                        {
                            ColunaPrincipal = new Coluna
                            {
                                Letra = "a",
                                Descricao = "Pergunta A"
                            },
                            ColunaAssociada = new Coluna
                            {
                                Letra = "i",
                                Descricao = "Resposta da A"
                            }
                        },
                        new Colunas
                        {
                            ColunaPrincipal = new Coluna
                            {
                                Letra = "b",
                                Descricao = "Pergunta B"
                            },
                            ColunaAssociada = new Coluna
                            {
                                Letra = "ii",
                                Descricao = "Resposta da B"
                            }
                        }
                    }
                }
            } : new Questao<AssociacaoDeColunas> { RespostaEsperada = new AssociacaoDeColunas() };

            ValideTeste(!palavraChaveInformado, questaoAssociacaoDeColunas, validador, "A coluna associada deve possuir pelo menos algum item.");
        }

        [Test, Theory]
        public void TesteRegraColunaPossuiColunaAssociada(bool palavraChaveInformado)
        {
            validador.AssineRegraItemColunaPrincipalPossuiColunaAssociada();

            var questaoAssociacaoDeColunas = palavraChaveInformado ? new Questao<AssociacaoDeColunas>()
            {
                RespostaEsperada = new AssociacaoDeColunas
                {
                    Colunas = new List<Colunas>
                    {
                        new Colunas
                        {
                            ColunaPrincipal = new Coluna
                            {
                                Letra = "a",
                                Descricao = "Pergunta A"
                            },
                            ColunaAssociada = new Coluna
                            {
                                Letra = "i",
                                Descricao = "Resposta da A"
                            }
                        },
                        new Colunas
                        {
                            ColunaPrincipal = new Coluna
                            {
                                Letra = "b",
                                Descricao = "Pergunta B"
                            },
                            ColunaAssociada = new Coluna
                            {
                                Letra = "ii",
                                Descricao = "Resposta da B"
                            }
                        }
                    }
                }
            } : new Questao<AssociacaoDeColunas> { RespostaEsperada = new AssociacaoDeColunas() };

            ValideTeste(!palavraChaveInformado, questaoAssociacaoDeColunas, validador, "A coluna principal deve possuir algum item na coluna associada.");
        }

        [Test, Sequential]
        public void TesteRegraAutorDaQuestaoInformadoEValido([Values("", " ", null, "saulo@gmail.com", "saulo@ufg.br")] string autor,
                                                             [Values(true, true, true, true, false)] bool cenarioInvalido)
        {
            validador.AssineRegraAutorDaQuestaoInformadoEValido();

            var questaoAssociacaoDeColunas = new Questao<AssociacaoDeColunas> { Usuario = autor };

            ValideTeste(cenarioInvalido, questaoAssociacaoDeColunas, validador, "O autor da questão deve ser um usuário válido");
        }

        [Test, Sequential]
        public void TesteRegraTipoQuestaoAssociacaoDeColunas([Values(TipoQuestao.Associacao, TipoQuestao.Discursiva)] TipoQuestao tipoQuestao,
                                                    [Values(false, true)] bool cenarioInvalido)
        {
            validador.AssineRegraTipoQuestaAssociacaoDeColunas();

            var questaoAssociacaoDeColunas = new Questao<AssociacaoDeColunas> { Tipo = tipoQuestao };

            ValideTeste(cenarioInvalido, questaoAssociacaoDeColunas, validador, "O tipo de questão deve ser 'Associação de colunas'");
        }

        [Test, Sequential]
        public void TesteRegraDificuldadeFoiInformadaEValida([Values(1, 5, 6)] int dificuldade,
                                                             [Values(false, false, true)] bool cenarioInvalido)
        {
            validador.AssineRegraDificuldadeFoiInformadaEValida();

            var questaoAssociacaoDeColunas = new Questao<AssociacaoDeColunas> { NivelDificuldade = (NivelDificuldade)dificuldade };

            ValideTeste(cenarioInvalido, questaoAssociacaoDeColunas, validador, "Informe um valor válido para nível de dificuldade");
        }

        [Test, Theory]
        public void TesteRegraAreaDeConhecimentoFoiInformada(bool areaDoConhecimentoInformada, bool codigoInformado)
        {
            validador.AssineRegraAreaDeConhecimentoFoiInformada();

            var questaoAssociacaoDeColunas = new Questao<AssociacaoDeColunas>();

            if (areaDoConhecimentoInformada)
            {
                questaoAssociacaoDeColunas.AreaDeConhecimento = new AreaDeConhecimento();
            }

            if (areaDoConhecimentoInformada && codigoInformado)
            {
                questaoAssociacaoDeColunas.AreaDeConhecimento.Codigo = "100";
            }

            ValideTeste(!areaDoConhecimentoInformada || !codigoInformado, questaoAssociacaoDeColunas, validador, "Área de conhecimento não informada ou inválida.");
        }

        [Test, Theory]
        public void TesteRegraDisciplinaFoiInformada(bool discipinaInformada, bool codigoInformado)
        {
            validador.AssineRegraDisciplinaFoiInformada();

            var questaoAssociacaoDeColunas = new Questao<AssociacaoDeColunas>();

            if (discipinaInformada)
            {
                questaoAssociacaoDeColunas.Disciplina = new Disciplina();
            }

            if (discipinaInformada && codigoInformado)
            {
                questaoAssociacaoDeColunas.Disciplina.Codigo = "100";
            }

            ValideTeste(!discipinaInformada || !codigoInformado, questaoAssociacaoDeColunas, validador, "Disciplina não informada ou inválida.");
        }
    }
}
