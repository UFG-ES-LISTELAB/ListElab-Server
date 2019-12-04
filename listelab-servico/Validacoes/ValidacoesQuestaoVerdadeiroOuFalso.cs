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

        /// <summary>
        /// A questão deve possuir uma ou mais alternativas.
        /// </summary>
        public void AssineRegraQuestaoVerdadeiroOuFalsoPossuiDuasOuMaisAlternativas()
        {
            RuleFor(questao => questao.RespostaEsperada)
                .Must(resposta => resposta.Afirmacao != null && resposta.Afirmacao.Count >= 1)
                .WithMessage("O tipo de questão 'Verdadeiro ou Falso' deve possuir uma ou mais alternativas.");
        }

        /// <summary>
        /// A questão deve possuir duas ou mais alternativas.
        /// </summary>
        public void AssineRegraEscolhasNaoDevemSerVazias()
        {
            RuleFor(questao => questao.RespostaEsperada)
                .Must(resposta => resposta.Afirmacao != null && !resposta.Afirmacao.Exists(escolha => string.IsNullOrEmpty(escolha.Descricao)))
                .WithMessage("As escolhas da questão não podem ser vazias.");
        }

        /// <summary>
        /// Ao menos uma questão deve ser a alternativa correta.
        /// </summary>
        public void AssineRegraEscolhaDevePossuirAlternativaCorreta()
        {
            RuleFor(questao => questao.RespostaEsperada)
                .Must(resposta => resposta.Afirmacao != null && resposta.Afirmacao.Exists(escolha => escolha.Correta))
                .WithMessage("Ao menos uma questão deve ser a alternativa correta.");
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
            AssineRegraQuestaoVerdadeiroOuFalsoPossuiDuasOuMaisAlternativas();
            AssineRegraEscolhasNaoDevemSerVazias();
            AssineRegraEscolhaDevePossuirAlternativaCorreta();
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
            AssineRegraQuestaoVerdadeiroOuFalsoPossuiDuasOuMaisAlternativas();
            AssineRegraEscolhasNaoDevemSerVazias();
            AssineRegraEscolhaDevePossuirAlternativaCorreta();
        }

        protected override void AssineRegrasPersonalizadasDeExclusao()
        {
        }
    }
}
