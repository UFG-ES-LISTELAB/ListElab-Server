﻿using FluentValidation;
using ListElab.Data.Repositorios;
using ListElab.Dominio.Conceitos.QuestaoObj;
using ListElab.Dominio.Conceitos.RespostaObj;
using ListElab.Dominio.Conceitos.UsuarioObj;
using ListElab.Dominio.Enumeradores;
using System.Collections.Generic;
using System.Linq;

namespace ListElab.Servico.Validacoes
{
    /// <summary>
    /// Validador de questões discursivas.
    /// </summary>
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
        public void AssineRegraDificuldadeFoiInformadaEValida()
        {
            RuleFor(questao => questao.NivelDificuldade)
                .Must(dificuldade => (int)dificuldade >= 1 && (int)dificuldade <= 5)
                .WithMessage("Informe um valor válido para nível de dificuldade");
        }

        /// <summary>
        /// Número do requisito.
        /// </summary>
        public void AssineRegraTipoQuestaoDiscursiva()
        {
            RuleFor(questao => questao.Tipo)
                .Must(tipo => tipo == TipoQuestao.Discursiva)
                .WithMessage("O tipo de questão deve ser 'Discursiva'");
        }

        /// <summary>
        /// Número do requisito.
        /// </summary>
        public void AssineRegraPalavraChaveInformada()
        {
            RuleFor(questao => questao.RespostaEsperada.PalavrasChaves)
                .Must(ValidePalavrasChaves)
                .WithMessage("Pelo menos uma palavra chave deve ser informada");
        }

        #region VALIDAÇÕES USUARIO

        /// <summary>
        /// Valida regra que o autor da quesetão deve ser informado e válido.
        /// </summary>
        public void AssineRegraAutorDaQuestaoInformadoEValido()
        {
            RuleFor(questao => questao.Usuario)
                .Must(usuario => !string.IsNullOrEmpty(usuario) && usuario.EndsWith("@ufg.br"))
                .WithMessage("O autor da questão deve ser um usuário válido");
        }

        /// <summary>
        /// Valida regra que o autor da questão precisa estar cadastrado no sistema.
        /// </summary>
        public void AssineRegraAutorDaQuestaoExiste()
        {
            RuleFor(questao => questao.Usuario)
                .Must(usuario => new Repositorio<Usuario>().ItemExiste(x => x.Email == usuario))
                .WithMessage("O autor da questão não é um usuário válido");
        }

        /// <summary>
        /// Valida regra que o autor da questão não pode ser atualizado.
        /// </summary>
        public void AssineRegraAutorDaQuestaoNaoPodeSerAtualizado()
        {
            RuleFor(questao => questao.Usuario)
                .Must(AutorDaQuestaoNaoFoiAtualizado)
                .When(x => objetoPersistido != null)
                .WithMessage("O autor da questão não pode ser atualizado");
        }

        #endregion

        /// <summary>
        /// Assina regras para o cenário de cadastro.
        /// </summary>
        protected override void AssineRegrasDeCadastro()
        {
            AssineRegraPalavraChaveInformada();
            AssineRegraDeveTerEnunciado();
            AssineRegraAutorDaQuestaoInformadoEValido();
            AssineRegraAutorDaQuestaoExiste();
            AssineRegraTipoQuestaoDiscursiva();
            AssineRegraDificuldadeFoiInformadaEValida();
        }

        /// <summary>
        /// Assina regras para o cenário de atualização.
        /// </summary>
        protected override void AssineRegrasDeAtualizacao()
        {
            AssineRegraPalavraChaveInformada();
            AssineRegraDeveTerEnunciado();
            AssineRegraAutorDaQuestaoInformadoEValido();
            AssineRegraAutorDaQuestaoExiste();
            AssineRegraAutorDaQuestaoNaoPodeSerAtualizado();
            AssineRegraTipoQuestaoDiscursiva();
            AssineRegraDificuldadeFoiInformadaEValida();
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

            return listaValidada.All(x => x != null) && listaValidada.Any(x => !string.IsNullOrEmpty(x.Descricao));
        }

        private bool AutorDaQuestaoNaoFoiAtualizado(string usuario)
        {
            return objetoPersistido.Usuario == usuario;
        }
    }
}
