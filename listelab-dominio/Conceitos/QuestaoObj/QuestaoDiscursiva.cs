using listelab_dominio.Conceitos.RespostaObj;
using listelab_dominio.CustomAttributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace listelab_dominio.Conceitos.QuestaoObj
{
    /// <summary>
    /// Representa uma questão discursiva.
    /// </summary>
    [Colecao(Nome = "questoesDiscursivas")]
    public class QuestaoDiscursiva : Questao<RespostaDiscursiva>
    {
    }
}
