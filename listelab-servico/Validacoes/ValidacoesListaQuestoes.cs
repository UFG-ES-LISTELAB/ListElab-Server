using FluentValidation;
using ListElab.Dominio.Conceitos.ListaObj;

namespace ListElab.Servico.Validacoes
{
    public class ValidacoesListaQuestoes : ValidadorPadrao<ListaQuestoes>
    {
        protected override void AssineRegrasDeAtualizacao()
        {
            AssineRegraListaDeveTerTitulo();
            AssineRegraListaDeveTerTags();
            AssineRegraListaDeveTerUsuario();
            AssineRegraListaDeveTerQuestoes();
        }

        protected override void AssineRegrasDeCadastro()
        {
            AssineRegraListaDeveTerTitulo();
            AssineRegraListaDeveTerTags();
            AssineRegraListaDeveTerUsuario();
            AssineRegraListaDeveTerQuestoes();
        }

        private void AssineRegraListaDeveTerTitulo()
        {
            RuleFor(x => x)
                .Must(lista => !string.IsNullOrWhiteSpace(lista.Titulo))
                .WithMessage("O título da lista de questões não pode ser nulo ou vazio!");
        }

        private void AssineRegraListaDeveTerTags()
        {
            RuleFor(x => x)
                .Must(lista => lista.Tags.Count > 0 && lista.Tags != null)
                .WithMessage("As tags da lista de questões não pode ser nulo ou vazio!");
        }

        private void AssineRegraListaDeveTerUsuario()
        {
            RuleFor(x => x)
                .Must(lista => !string.IsNullOrWhiteSpace(lista.Usuario))
                .WithMessage("O autor da lista de questões não pode ser nulo ou vazio!");
        }

        private void AssineRegraListaDeveTerQuestoes()
        {
            RuleFor(x => x)
                .Must(lista => lista.Discursivas.Count > 0 && lista.Discursivas != null)
                .WithMessage("A lista precisa conter ao menos uma questão!");
        }

        protected override void AssineRegrasDeExclusao()
        {
            //TODO: Elaborar uma regra para exclusão
            //No momento não consegui pensar em nada a respeito
        }
    }
}
