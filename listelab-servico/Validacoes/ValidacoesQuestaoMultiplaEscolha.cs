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

        /// <summary>
        /// A questão deve possuir duas ou mais alternativas.
        /// </summary>
        public void AssineRegraQuestaoMultiplaEscolhaPossuiDuasOuMaisAlternativas()
        {
            RuleFor(questao => questao.RespostaEsperada)
                .Must(resposta => resposta.Alternativas != null && resposta.Alternativas.Count >= 2)
                .WithMessage("O tipo de questão 'Múltipla Escolha' deve possuir duas ou mais escolhas.");
        }

        /// <summary>
        /// A questão deve possuir duas ou mais alternativas.
        /// </summary>
        public void AssineRegraEscolhasNaoDevemSerVazias()
        {
            RuleFor(questao => questao.RespostaEsperada)
                .Must(resposta => resposta.Alternativas != null && !resposta.Alternativas.Exists(escolha => string.IsNullOrEmpty(escolha.Descricao)))
                .WithMessage("As escolhas da questão não podem ser vazias.");
        }

        /// <summary>
        /// Ao menos uma questão deve ser a alternativa correta.
        /// </summary>
        public void AssineRegraEscolhaDevePossuirAlternativaCorreta()
        {
            RuleFor(questao => questao.RespostaEsperada)
                .Must(resposta => resposta.Alternativas != null && resposta.Alternativas.Exists(escolha => escolha.Correta))
                .WithMessage("Ao menos uma questão deve ser a alternativa correta.");
        }

        protected override void AssineRegrasPersonalizadasDeAtualizacao()
        {
            AssineRegraTipoQuestaoMultiplaEscolha();
            AssineRegraDeveTerEnunciado();
            AssineRegraAutorDaQuestaoInformadoEValido();
            AssineRegraAutorDaQuestaoExiste();
            AssineRegraAutorDaQuestaoNaoPodeSerAtualizado();
            AssineRegraDificuldadeFoiInformadaEValida();
            AssineRegraDisciplinaFoiInformada();
            AssineRegraAreaDeConhecimentoFoiInformada();
            AssineRegraQuestaoMultiplaEscolhaPossuiDuasOuMaisAlternativas();
            AssineRegraEscolhasNaoDevemSerVazias();
            AssineRegraEscolhaDevePossuirAlternativaCorreta();
        }

        protected override void AssineRegrasPersonalizadasDeCadastro()
        {
            AssineRegraTipoQuestaoMultiplaEscolha();
            AssineRegraDeveTerEnunciado();
            AssineRegraAutorDaQuestaoInformadoEValido();
            AssineRegraAutorDaQuestaoExiste();
            AssineRegraDificuldadeFoiInformadaEValida();
            AssineRegraDisciplinaFoiInformada();
            AssineRegraAreaDeConhecimentoFoiInformada();
            AssineRegraQuestaoMultiplaEscolhaPossuiDuasOuMaisAlternativas();
            AssineRegraEscolhasNaoDevemSerVazias();
            AssineRegraEscolhaDevePossuirAlternativaCorreta();
        }

        protected override void AssineRegrasPersonalizadasDeExclusao()
        {
        }
    }
}
