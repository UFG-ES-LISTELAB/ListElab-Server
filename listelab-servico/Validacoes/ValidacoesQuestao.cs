﻿using FluentValidation;
using ListElab.Data.Repositorios;
using ListElab.Dominio.Conceitos.AreaDeConhecimentoObj;
using ListElab.Dominio.Conceitos.DisciplinaObj;
using ListElab.Dominio.Conceitos.QuestaoObj;
using ListElab.Dominio.Conceitos.UsuarioObj;

namespace ListElab.Servico.Validacoes
{
    public abstract class ValidacoesQuestao<TResposta> : ValidadorPadrao<Questao<TResposta>>
    {
        private IRepositorio<Disciplina> repositorioDisciplina;
        private IRepositorio<AreaDeConhecimento> repositorioAreaConhecimento;

        /// <summary>
        /// Valida regra que o enunciado da questão deve ser informado.
        /// </summary>
        public void AssineRegraDeveTerEnunciado()
        {
            RuleFor(questao => questao.Enunciado)
                .Must(enunciado => !string.IsNullOrWhiteSpace(enunciado))
                .WithMessage("O enunciado da questão deve ser informado");
        }

        /// <summary>
        /// Valida regra que deve ser informado um valor válido para nível de dificuldade.
        /// </summary>
        public void AssineRegraDificuldadeFoiInformadaEValida()
        {
            RuleFor(questao => questao.NivelDificuldade)
                .Must(dificuldade => (int)dificuldade >= 1 && (int)dificuldade <= 5)
                .WithMessage("Informe um valor válido para nível de dificuldade");
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
                .Must(usuario => RepositorioUsuario().ItemExiste(x => x.Email == usuario))
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

        #region VALIDAÇÕES ÁREA DE CONHECIMENTO

        /// <summary>
        /// Valida se a área de conhecimento foi informada.
        /// </summary>
        public void AssineRegraAreaDeConhecimentoFoiInformada()
        {
            RuleFor(questao => questao.AreaDeConhecimento)
                .Must(x => x != null && !string.IsNullOrEmpty(x.Codigo))
                .WithMessage("Área de conhecimento não informada ou inválida.");
        }

        #endregion

        #region VALIDAÇÕES DISCIPLINA

        /// <summary>
        /// Verifica se a disciplina foi informada.
        /// </summary>
        public void AssineRegraDisciplinaFoiInformada()
        {
            RuleFor(questao => questao.Disciplina)
                .Must(x => x != null && !string.IsNullOrEmpty(x.Codigo))
                .WithMessage("Disciplina não informada ou inválida.");
        }

        #endregion

        private bool AutorDaQuestaoNaoFoiAtualizado(string usuario)
        {
            return objetoPersistido.Usuario == usuario;
        }

        private IRepositorio<Usuario> RepositorioUsuario()
        {
            return new Repositorio<Usuario>();
        }

        private IRepositorio<Disciplina> RepositorioDisciplina()
        {
            return repositorioDisciplina ?? (repositorioDisciplina = new Repositorio<Disciplina>());
        }

        private IRepositorio<AreaDeConhecimento> RepositorioAreaDeConhecimento()
        {
            return repositorioAreaConhecimento ?? (repositorioAreaConhecimento = new Repositorio<AreaDeConhecimento>());
        }
    }
}
