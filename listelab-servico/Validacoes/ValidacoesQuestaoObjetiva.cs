using ListElab.Dominio.Conceitos.QuestaoObj;
using ListElab.Dominio.Conceitos.RespostaObj;
using System;

namespace ListElab.Servico.Validacoes
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
