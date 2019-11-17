using FluentValidation;
using ListElab.Dominio.Conceitos.ListaObj;

namespace ListElab.Servico.Validacoes
{
    public class ValidacoesListaQuestoes : ValidadorPadrao<ListaQuestoes>
    {
        protected override void AssineRegrasDeAtualizacao()
        {
            AssineRegraListaDeveTerTitulo();
            AssineRegraListaDeveTerUsuario();
            AssineRegraListaDeveTerQuestoes();
        }

        protected override void AssineRegrasDeCadastro()
        {
            AssineRegraListaDeveTerTitulo();
            AssineRegraListaDeveTerUsuario();
            AssineRegraListaDeveTerQuestoes();
        }

        public void AssineRegraListaDeveTerTitulo()
        {
            RuleFor(x => x.Titulo)
                .Must(titulo => !string.IsNullOrWhiteSpace(titulo))
                .WithMessage("O título da lista de questões deve ser informado");
        }

        public void AssineRegraListaDeveTerUsuario()
        {
            RuleFor(x => x.Usuario)
                .Must(usuario => !string.IsNullOrWhiteSpace(usuario))
                .WithMessage("O autor da lista de questões deve ser informado");
        }

        public void AssineRegraListaDeveTerQuestoes()
        {
            RuleFor(x => x.Id)
                .Must((lista, id) => lista.QuestoesDiscursivas != null && lista.QuestoesDiscursivas.Count > 0)
                .WithMessage("É preciso informar as questões que compõe uma lista, certifique-se de que os ids das questões foram repassados à requisição");
        }

        protected override void AssineRegrasDeExclusao()
        {
            //TODO: Elaborar uma regra para exclusão
            //No momento não consegui pensar em nada a respeito
        }
    }
}
