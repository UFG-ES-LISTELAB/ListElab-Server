using FluentValidation;
using FluentValidation.Results;
using ListElab.Data.Repositorios;
using ListElab.Dominio.Abstrato;
using System;

namespace ListElab.Servico.Validacoes
{
    /// <summary>
    /// Validador padrão.
    /// </summary>
    /// <typeparam name="T">Conceito que será validado.</typeparam>
    public abstract class ValidadorPadrao<T> : AbstractValidator<T> where T : ObjetoComId
    {
        protected T objetoPersistido;
        private IRepositorio<T> repositorio;

        public ValidationResult Valide(T objeto)
        {
            objetoPersistido = Repositorio().ConsulteUm(x => x.Id == objeto.Id);

            return Validate(objeto);
        }

        /// <summary>
        /// Número do requisito.
        /// </summary>
        public void AssineRegraIdDeveSerInformado()
        {
            RuleFor(objeto => objeto.Id)
                .Must(id => id != Guid.Empty)
                .WithMessage("O id deve ser informado na atualização");
        }

        /// <summary>
        /// Número do requisito.
        /// </summary>
        public void AssineRegraConceitoExiste()
        {
            RuleFor(objeto => objeto.Id)
                .Must(id => Repositorio().ItemExiste(x => x.Id == id))
                .WithMessage("O id passado é inválido ou não representa um conceito cadastrado");
        }

        /// <summary>
        /// Agrupamento de regras para cadastro.
        /// </summary>
        public void AssineRegrasCadastro()
        {
            AssineRegrasDeCadastro();
        }

        /// <summary>
        /// Agrupamento de regras de atualização.
        /// </summary>
        public void AssineRegrasAtualizacao()
        {
            AssineRegraIdDeveSerInformado();
            AssineRegraConceitoExiste();
            AssineRegrasDeAtualizacao();
        }

        /// <summary>
        /// Agrupamento de regras de exclusão.
        /// </summary>
        public void AssineRegrasExclusao()
        {
            AssineRegraConceitoExiste();
            AssineRegrasDeExclusao();
        }

        protected abstract void AssineRegrasDeCadastro();

        protected abstract void AssineRegrasDeAtualizacao();

        protected abstract void AssineRegrasDeExclusao();

        protected IRepositorio<T> Repositorio()
        {
            return repositorio ?? (repositorio = new Repositorio<T>());
        }
    }
}
