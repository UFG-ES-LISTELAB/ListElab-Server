﻿using FluentValidation;
using ListElab.Dominio.Conceitos.ListaObj;

namespace ListElab.Servico.Validacoes
{
    public class ValidacoesListaQuestoes : ValidadorPadrao<ListaQuestoes>
    {
        protected override void AssineRegrasPersonalizadasDeAtualizacao()
        {
            AssineRegraListaDeveTerTitulo();
            AssineRegraListaDeveTerUsuario();
            AssineRegraListaDeveTerQuestoes();
        }

        protected override void AssineRegrasPersonalizadasDeCadastro()
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
                .Must((lista, id) => (lista.QuestoesDiscursivas != null && lista.QuestoesDiscursivas.Count > 0) ||
                                    (lista.QuestoesVerdadeiroOuFalso != null && lista.QuestoesVerdadeiroOuFalso.Count > 0) ||
                                    (lista.QuestoesMultiplaEscolha != null && lista.QuestoesMultiplaEscolha.Count > 0) ||
                                    (lista.QuestoesAssociacaoDeColunas != null && lista.QuestoesAssociacaoDeColunas.Count > 0))
                .WithMessage("É preciso informar as questões que compõe uma lista, certifique-se de que os ids das questões foram repassados à requisição");
        }

        protected override void AssineRegrasPersonalizadasDeExclusao()
        {
            //TODO: Elaborar uma regra para exclusão
            //No momento não consegui pensar em nada a respeito
        }
    }
}
