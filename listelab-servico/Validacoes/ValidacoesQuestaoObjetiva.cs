using listelab_dominio.Conceitos.QuestaoObj;
using listelab_dominio.Conceitos.RespostaObj;
using System;

namespace listelab_servico.Validacoes
{
    public class ValidacoesQuestaoObjetiva : ValidadorPadrao<Questao<Objetiva>>
    {
        protected override void AssineRegrasDeAtualizacao()
        {
            throw new NotImplementedException();
        }

        protected override void AssineRegrasDeCadastro()
        {
            throw new NotImplementedException();
        }

        protected override void AssineRegrasDeExclusao()
        {
            throw new NotImplementedException();
        }
    }
}
