using FluentValidation;
using ListElab.Dominio.Conceitos.QuestaoObj;
using ListElab.Dominio.Conceitos.RespostaObj;
using ListElab.Dominio.Enumeradores;

namespace ListElab.Servico.Validacoes
{
    public class ValidacoesQuestaoAssociacaoDeColuna : ValidacoesQuestao<AssociacaoDeColunas>
    {
        /// <summary>
        /// Tipo de questão deve ser múltipla escolha.
        /// </summary>
        public void AssineRegraTipoQuestaAssociacaoDeColunas()
        {
            RuleFor(questao => questao.Tipo)
                .Must(tipo => tipo == TipoQuestao.Associacao)
                .WithMessage("O tipo de questão deve ser 'Associação de colunas'");
        }

        /// <summary>
        /// Coluna principal da resposta esperada possui item.
        /// </summary>
        public void AssineRegraColunaPrincipalPossuiItem()
        {
            RuleFor(questao => questao.RespostaEsperada.Colunas)
                    .Must(coluna => coluna != null && !coluna.Exists(item => string.IsNullOrEmpty(item.ColunaPrincipal.Letra)))
                    .WithMessage("A coluna principal deve possuir pelo menos algum item.");
        }

        /// <summary>
        /// Coluna associada da resposta esperada possui item.
        /// </summary>
        public void AssineRegraColunaAssociadaPossuiItem()
        {
            RuleFor(questao => questao.RespostaEsperada.Colunas)
                        .Must(coluna => coluna != null && !coluna.Exists(item => string.IsNullOrEmpty(item.ColunaAssociada.Letra)))
                        .WithMessage("A coluna associada deve possuir pelo menos algum item.");
        }

        /// <summary>
        /// Coluna principal da resposta esperada possui item correspondente na coluna associada.
        /// </summary>
        public void AssineRegraItemColunaPrincipalPossuiColunaAssociada()
        {
            RuleFor(questao => questao.RespostaEsperada.Colunas)
                        .Must(coluna => coluna != null && !coluna.Exists(item =>
                                            (!string.IsNullOrEmpty(item.ColunaPrincipal.Letra) &&
                                            string.IsNullOrEmpty(item.ColunaAssociada.Letra)) ||
                                            (!string.IsNullOrEmpty(item.ColunaAssociada.Letra) &&
                                            string.IsNullOrEmpty(item.ColunaPrincipal.Letra))
                                        )
                        )
                        .WithMessage("A coluna principal deve possuir algum item na coluna associada.");
        }

        protected override void AssineRegrasPersonalizadasDeAtualizacao()
        {
            AssineRegraTipoQuestaAssociacaoDeColunas();
            AssineRegraColunaPrincipalPossuiItem();
            AssineRegraColunaAssociadaPossuiItem();
            AssineRegraItemColunaPrincipalPossuiColunaAssociada();
            AssineRegraDeveTerEnunciado();
            AssineRegraAutorDaQuestaoInformadoEValido();
            AssineRegraAutorDaQuestaoExiste();
            AssineRegraAutorDaQuestaoNaoPodeSerAtualizado();
            AssineRegraDificuldadeFoiInformadaEValida();
            AssineRegraDisciplinaFoiInformada();
            AssineRegraAreaDeConhecimentoFoiInformada();
        }

        protected override void AssineRegrasPersonalizadasDeCadastro()
        {
            AssineRegraTipoQuestaAssociacaoDeColunas();
            AssineRegraColunaPrincipalPossuiItem();
            AssineRegraColunaAssociadaPossuiItem();
            AssineRegraItemColunaPrincipalPossuiColunaAssociada();
            AssineRegraDeveTerEnunciado();
            AssineRegraAutorDaQuestaoInformadoEValido();
            AssineRegraAutorDaQuestaoExiste();
            AssineRegraAutorDaQuestaoNaoPodeSerAtualizado();
            AssineRegraDificuldadeFoiInformadaEValida();
            AssineRegraDisciplinaFoiInformada();
            AssineRegraAreaDeConhecimentoFoiInformada();
        }

        protected override void AssineRegrasPersonalizadasDeExclusao()
        {
        }
    }
}
