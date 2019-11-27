using FluentValidation;
using ListElab.Dominio.Conceitos.RespostaObj;
using ListElab.Dominio.Enumeradores;

namespace ListElab.Servico.Validacoes
{
    /// <summary>
    /// Validador de questões de múltipla escolha.
    /// </summary>
    public class ValidacoesQuestaoMultiplaEscolha : ValidacoesQuestao<MultiplaEscolha>
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
            AssineRegraDeveTerEnunciado();
            AssineRegraAutorDaQuestaoInformadoEValido();
            AssineRegraAutorDaQuestaoExiste();
            AssineRegraAutorDaQuestaoNaoPodeSerAtualizado();
            AssineRegraDificuldadeFoiInformadaEValida();
            AssineRegraDisciplinaFoiInformada();
            AssineRegraAreaDeConhecimentoFoiInformada();
        }

        protected override void AssineRegrasDeCadastro()
        {
            AssineRegraTipoQuestaoMultiplaEscolha();
            AssineRegraDeveTerEnunciado();
            AssineRegraAutorDaQuestaoInformadoEValido();
            AssineRegraAutorDaQuestaoExiste();
            AssineRegraDificuldadeFoiInformadaEValida();
            AssineRegraDisciplinaFoiInformada();
            AssineRegraAreaDeConhecimentoFoiInformada();
        }

        protected override void AssineRegrasDeExclusao()
        {
        }
    }
}
