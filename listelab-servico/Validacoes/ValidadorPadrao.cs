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
        /// Valida regra que o id deve ser informado na atualização.
        /// </summary>
        public void AssineRegraIdDeveSerInformado()
        {
            RuleFor(objeto => objeto.Id)
                .Must(id => id != Guid.Empty)
                .WithMessage("O id deve ser informado na atualização");
        }

        /// <summary>
        /// Valida regra que o id passado não pode ser inválido e deve representar um conceito cadastrado.
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
        public void AssineRegrasPadraoDeCadastro()
        {
            AssineRegrasPersonalizadasDeCadastro();
        }

        /// <summary>
        /// Agrupamento de regras de atualização.
        /// </summary>
        public void AssineRegrasPadraoDeAtualizacao()
        {
            AssineRegraIdDeveSerInformado();
            AssineRegraConceitoExiste();
            AssineRegrasPersonalizadasDeAtualizacao();
        }

        /// <summary>
        /// Agrupamento de regras de exclusão.
        /// </summary>
        public void AssineRegrasPadraoDeExclusao()
        {
            AssineRegraConceitoExiste();
            AssineRegrasPersonalizadasDeExclusao();
        }

        protected abstract void AssineRegrasPersonalizadasDeCadastro();

        protected abstract void AssineRegrasPersonalizadasDeAtualizacao();

        protected abstract void AssineRegrasPersonalizadasDeExclusao();

        protected IRepositorio<T> Repositorio()
        {
            return repositorio ?? (repositorio = new Repositorio<T>());
        }
    }
}
