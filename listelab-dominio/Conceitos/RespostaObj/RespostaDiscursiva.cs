using System;
using System.Collections.Generic;
using System.Text;

namespace listelab_dominio.Conceitos.RespostaObj
{
    public class RespostaDiscursiva : Resposta
    {
        public IList<PalavrasChaves> PalavrasChaves { get; set; }
    }
}
