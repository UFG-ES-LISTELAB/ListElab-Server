using System;
using System.Collections.Generic;
using System.Text;

namespace ListElab.Dominio.Dtos
{
    public class DtoQuestaoDaLista
    {
        /// <summary>
        /// Número da questão dentro da lista.
        /// </summary>
        public int Numero { get; set; }

        /// <summary>
        /// Peso da questão dentro da lista.
        /// </summary>
        public int Peso { get; set; }

        /// <summary>
        /// Questão da lista.
        /// </summary>
        public DtoQuestaoDiscursiva Questao { get; set; }
    }
}
