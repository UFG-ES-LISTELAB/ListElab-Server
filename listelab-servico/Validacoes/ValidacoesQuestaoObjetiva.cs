using listelab_dominio.Conceitos.Questao;
using listelab_dominio.Conceitos.Resposta;
using System;
using System.Collections.Generic;
using System.Text;

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
