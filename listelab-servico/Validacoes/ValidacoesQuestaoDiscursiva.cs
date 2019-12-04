using FluentValidation;
using ListElab.Dominio.Conceitos.RespostaObj;
using ListElab.Dominio.Enumeradores;
using System.Collections.Generic;
using System.Linq;

namespace ListElab.Servico.Validacoes
{
    /// <summary>
    /// Validador de questões discursivas.
    /// </summary>
    public class ValidacoesQuestaoDiscursiva : ValidacoesQuestao<Discursiva>
    {
        /// <summary>
        /// Valida regra que o tipo de questão deve ser 'Discursiva'.
        /// </summary>
        public void AssineRegraTipoQuestaoDiscursiva()
        {
            RuleFor(questao => questao.Tipo)
                .Must(tipo => tipo == TipoQuestao.Discursiva)
                .WithMessage("O tipo de questão deve ser 'Discursiva'");
        }

        /// <summary>
        /// Valida regra que pelo menos uma palavra chave deve ser informada.
        /// </summary>
        public void AssineRegraPalavraChaveInformada()
        {
            RuleFor(questao => questao.RespostaEsperada.PalavrasChaves)
                .Must(ValidePalavrasChaves)
                .WithMessage("Pelo menos uma palavra chave deve ser informada");
        }

        /// <summary>
        /// Assina regras para o cenário de cadastro.
        /// </summary>
        protected override void AssineRegrasPersonalizadasDeCadastro()
        {
            AssineRegraPalavraChaveInformada();
            AssineRegraDeveTerEnunciado();
            AssineRegraAutorDaQuestaoInformadoEValido();
            AssineRegraAutorDaQuestaoExiste();
            AssineRegraTipoQuestaoDiscursiva();
            AssineRegraDificuldadeFoiInformadaEValida();
            AssineRegraDisciplinaFoiInformada();
            AssineRegraAreaDeConhecimentoFoiInformada();
        }

        /// <summary>
        /// Assina regras para o cenário de atualização.
        /// </summary>
        protected override void AssineRegrasPersonalizadasDeAtualizacao()
        {
            AssineRegraPalavraChaveInformada();
            AssineRegraDeveTerEnunciado();
            AssineRegraAutorDaQuestaoInformadoEValido();
            AssineRegraAutorDaQuestaoExiste();
            AssineRegraAutorDaQuestaoNaoPodeSerAtualizado();
            AssineRegraTipoQuestaoDiscursiva();
            AssineRegraDificuldadeFoiInformadaEValida();
            AssineRegraDisciplinaFoiInformada();
            AssineRegraAreaDeConhecimentoFoiInformada();
        }

        /// <summary>
        /// Assina regras para o cenário de exclusão.
        /// </summary>
        protected override void AssineRegrasPersonalizadasDeExclusao()
        {
        }

        private bool ValidePalavrasChaves(IList<PalavraChave> palavras)
        {
            if (palavras == null)
            {
                return false;
            }

            var listaValidada = palavras;

            return listaValidada.All(x => x != null) && listaValidada.Any(x => !string.IsNullOrEmpty(x.Descricao));
        }
    }
}
