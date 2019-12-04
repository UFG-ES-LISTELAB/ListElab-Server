using FluentValidation;
using ListElab.Dominio.Conceitos.RespostaObj;
using ListElab.Dominio.Enumeradores;

namespace ListElab.Servico.Validacoes
{
    /// <summary>
    /// Classe que agrupa todas as validações de negócio de questões verdadeiras ou falsas.
    /// </summary>
    public class ValidacoesQuestaoVerdadeiroOuFalso : ValidacoesQuestao<VerdadeiroOuFalso>
    {
        /// <summary>
        /// Tipo de questão deve ser múltipla escolha.
        /// </summary>
        public void AssineRegraTipoQuestaoVerdadeiroOuFalso()
        {
            RuleFor(questao => questao.Tipo)
                .Must(tipo => tipo == TipoQuestao.VerdadeiroOuFalso)
                .WithMessage("O tipo de questão deve ser 'Verdadeiro ou Falso'");
        }

        protected override void AssineRegrasPersonalizadasDeAtualizacao()
        {
            AssineRegraTipoQuestaoVerdadeiroOuFalso();
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
            AssineRegraTipoQuestaoVerdadeiroOuFalso();
            AssineRegraDeveTerEnunciado();
            AssineRegraAutorDaQuestaoInformadoEValido();
            AssineRegraAutorDaQuestaoExiste();
            AssineRegraDificuldadeFoiInformadaEValida();
            AssineRegraDisciplinaFoiInformada();
            AssineRegraAreaDeConhecimentoFoiInformada();
        }

        protected override void AssineRegrasPersonalizadasDeExclusao()
        {
        }
    }
}
