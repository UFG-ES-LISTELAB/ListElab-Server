﻿using listelab_dominio.Abstrato;
using listelab_dominio.Conceitos.Resposta;
using listelab_dominio.CustomAttributes;
using listelab_dominio.Enumeradores;
using System.Collections.Generic;

namespace listelab_dominio.Conceitos
{
    [Colecao(Nome = "listas")]
    public class ListaQuestoes : ObjetoComId
    {
        public string Titulo { get; set; }
        /// <summary>
        /// Representa as áreas de conhecimento disponíveis.
        /// </summary>
        public EnumAreaDeConhecimento AreaDeConhecimento { get; set; }
        /// <summary>
        /// Representa o nível de dificuldade, indo de 1 à 5.
        /// </summary>
        public EnumNivelDificuldade NivelDificuldade { get; set; }
        /// <summary>
        /// Tags para busca da lista
        /// </summary>
        public List<string> Tags { get; set; }
        /// <summary>
        /// Questões discursivas
        /// </summary>
        public List<Questao<Discursiva>> Discursivas { get; set; }
        /// <summary>
        /// Questões objetivas
        /// </summary>
        public List<Questao<Objetiva>> Objetivas { get; set; }

    }
}
