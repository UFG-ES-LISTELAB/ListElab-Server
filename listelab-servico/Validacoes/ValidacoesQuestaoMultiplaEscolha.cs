using FluentValidation;
using ListElab.Dominio.Conceitos.QuestaoObj;
using ListElab.Dominio.Conceitos.RespostaObj;
using ListElab.Dominio.Enumeradores;
using System;

namespace ListElab.Servico.Validacoes
{
    /// <summary>
    /// Validador de questões de múltipla escolha.
    /// </summary>
    public class ValidacoesQuestaoMultiplaEscolha : ValidadorPadrao<Questao<MultiplaEscolha>>
    {
        /// <summary>
        /// Tipo de questão deve ser múltipla escolha.
        /// </summary>
        public void AssineRegraTipoQuestaoMultiplaEscolha()
        {
            RuleFor(questao => questao.Tipo)
                .Must(tipo => tipo == TipoQuestao.MultiplaEscolha)
                .WithMessage("O tipo de questão deve ser 'Múltipla Escolha'");
        }

        protected override void AssineRegrasDeAtualizacao()
        {
            AssineRegraTipoQuestaoMultiplaEscolha();
        }

        protected override void AssineRegrasDeCadastro()
        {
            AssineRegraTipoQuestaoMultiplaEscolha();
        }

        protected override void AssineRegrasDeExclusao()
        {
        }
    }
}
