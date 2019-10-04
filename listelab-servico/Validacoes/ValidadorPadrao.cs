using FluentValidation;
using listelab_data.Repositorios;
using listelab_dominio.Abstrato;

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

        public void AssineRegraItemNaoDuplicado()
        {
            RuleFor(x => x.Codigo)
                .Must(codigo => !Repositorio().ItemExiste(x => x.Codigo == codigo))
                .WithMessage("Esse item já foi cadastrado");
        }

        protected abstract void AssineRegrasDeCadastro();

        protected abstract void AssineRegrasDeAtualizacao();

        protected abstract void AssineRegrasDeExclusao();

        public void AssineRegrasCadastro()
        {
            AssineRegrasDeCadastro();
            AssineRegraItemNaoDuplicado();
        }

        public void AssineRegrasAtualizacao()
        {
            AssineRegrasDeAtualizacao();
        }

        public void AssineRegrasExclusao()
        {
            AssineRegrasDeAtualizacao();
        }

        protected IRepositorio<T> Repositorio()
        {
            return _repositorio ?? (new Repositorio<T>());
        }
    }
}
