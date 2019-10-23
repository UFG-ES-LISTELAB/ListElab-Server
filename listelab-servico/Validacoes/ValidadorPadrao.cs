using FluentValidation;
using listelab_data.Repositorios;
using listelab_dominio.Abstrato;
using System;

namespace listelab_servico.Validacoes
{
    public abstract class ValidadorPadrao<T> : AbstractValidator<T> where T : ObjetoComId
    {
        private IRepositorio<T> _repositorio;

        public void Valide(T objeto)
        {
            var resultado = Validate(objeto);

            if(!resultado.IsValid)
            {
                throw new ValidationException(resultado.Errors[0].ErrorMessage);
            }
        }

        /// <summary>
        /// Número do requisito.
        /// </summary>
        public void AssineRegraIdDeveSerInformado()
        {
            RuleFor(objeto => objeto.Id)
                .Must(id => id != Guid.Empty)
                .WithMessage("O id deve ser informado na atualização.");
        }

        /// <summary>
        /// Número do requisito.
        /// </summary>
        public void AssineRegraConceitoExiste()
        {
            RuleFor(objeto => objeto.Id)
                .Must(id => Repositorio().ItemExiste(x => x.Id == id))
                .WithMessage("O id passado é inválido ou não representa um conceito cadastrado.");
        }

        protected abstract void AssineRegrasDeCadastro();

        protected abstract void AssineRegrasDeAtualizacao();

        protected abstract void AssineRegrasDeExclusao();

        public void AssineRegrasCadastro()
        {
            AssineRegrasDeCadastro();
        }

        public void AssineRegrasAtualizacao()
        {
            AssineRegraIdDeveSerInformado();
            AssineRegraConceitoExiste();
            AssineRegrasDeAtualizacao();
        }

        public void AssineRegrasExclusao()
        {
            AssineRegraConceitoExiste();
            AssineRegrasDeAtualizacao();
        }

        protected IRepositorio<T> Repositorio()
        {
            return _repositorio ?? (new Repositorio<T>());
        }
    }
}
