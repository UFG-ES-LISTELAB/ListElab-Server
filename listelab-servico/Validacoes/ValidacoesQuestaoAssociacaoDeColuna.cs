using FluentValidation;
using ListElab.Dominio.Conceitos.QuestaoObj;
using ListElab.Dominio.Conceitos.RespostaObj;
using ListElab.Dominio.Enumeradores;

namespace ListElab.Servico.Validacoes
{
    public class ValidacoesQuestaoAssociacaoDeColuna : ValidadorPadrao<Questao<AssociacaoDeColunas>>
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

        protected override void AssineRegrasDeAtualizacao()
        {
            AssineRegraTipoQuestaAssociacaoDeColunas();
        }

        protected override void AssineRegrasDeCadastro()
        {
            AssineRegraTipoQuestaAssociacaoDeColunas();
        }

        protected override void AssineRegrasDeExclusao()
        {
        }
    }
}
