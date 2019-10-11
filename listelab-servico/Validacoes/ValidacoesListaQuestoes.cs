using FluentValidation;
using listelab_dominio.Conceitos.ListaObj;

namespace listelab_servico.Validacoes
{
    public class ValidacoesListaQuestoes : ValidadorPadrao<ListaQuestoes>
    {
        protected override void AssineRegrasDeAtualizacao()
        {
            AssineRegraListaDeveTerTitulo();
        }

        protected override void AssineRegrasDeCadastro()
        {
            AssineRegraListaDeveTerTitulo();
        }

        private void AssineRegraListaDeveTerTitulo()
        {
            RuleFor(x => x)
                .Must(lista => !string.IsNullOrWhiteSpace(lista.Titulo))
                .WithMessage("O título da lista de questões não pode ser nulo ou vazio!");
        }

        protected override void AssineRegrasDeExclusao()
        {
            //TODO: Elaborar uma regra para exclusão
            //No momento não consegui pensar em nada a respeito
        }
    }
}
