﻿using listelab_dominio.Conceitos;
using FluentValidation;
using System.Collections.Generic;
using System.Linq;
using listelab_dominio.Conceitos.Resposta;

namespace listelab_servico.Validacoes
{
    public class ValidacoesQuestaoDiscursiva : ValidadorPadrao<Questao<Discursiva>>
    {
        /// <summary>
        /// Número do requisito.
        /// </summary>
        public void AssineRegraDeveTerEnunciado()
        {
            RuleFor(questao => questao.Enunciado)
                .Must(enunciado => !string.IsNullOrWhiteSpace(enunciado))
                .WithMessage("O enunciado da questão deve ser informado");
        }

        /// <summary>
        /// Número do requisito.
        /// </summary>
        public void AssineRegraPalavraChaveInformado()
        {
            RuleFor(questao => questao.RespostaEsperada.PalavrasChaves)
                .Must(ValidePalavrasChaves)
                .WithMessage("Pelo menos uma palavra chave deve ser informada");
        }

        /// <summary>
        /// Assina regras para o cenário de cadastro.
        /// </summary>
        protected override void AssineRegrasDeCadastro()
        {
            AssineRegraPalavraChaveInformado();
            AssineRegraDeveTerEnunciado();
        }

        /// <summary>
        /// Assina regras para o cenário de atualização.
        /// </summary>
        protected override void AssineRegrasDeAtualizacao()
        {
            AssineRegraPalavraChaveInformado();
            AssineRegraDeveTerEnunciado();
        }

        /// <summary>
        /// Assina regras para o cenário de exclusão.
        /// </summary>
        protected override void AssineRegrasDeExclusao()
        {
        }

        private bool ValidePalavrasChaves(IList<PalavraChave> palavras)
        {
            if (palavras == null)
            {
                return false;
            }

            var listaValidada = palavras;

            return listaValidada.All(x => x != null);
        }
    }
}
