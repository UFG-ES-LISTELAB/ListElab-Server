﻿using ListElab.Dominio.Abstrato;
using ListElab.Dominio.AtributosCustomizados;
using System.Collections.Generic;

namespace ListElab.Dominio.Conceitos.ListaObj
{
    [Colecao(Nome = "listas")]
    public class ListaQuestoes : ObjetoComId
    {
        /// <summary>
        /// Título da lista.
        /// </summary>
        public string Titulo { get; set; }

        /// <summary>
        /// O email do usuário que criou a lista.
        /// </summary>
        public string Usuario { get; set; }

        /// <summary>
        /// Nível de dificuldade da lista.
        /// </summary>
        public int NivelDificuldade { get; set; }

        /// <summary>
        /// Define se uma lista está pronta para ser aplicada.
        /// </summary>
        public bool ProntaParaAplicacao { get; set; }

        /// <summary>
        /// Tempo esperado para resposta.
        /// </summary>
        public int TempoEsperadoResposta { get; set; }

        /// <summary>
        /// As tags de todas as questões da lista.
        /// </summary>
        public List<string> Tags { get; set; }

        /// <summary>
        /// Lista com os códigos da área de conhecimento das questões.
        /// </summary>
        public List<string> AreasDeConhecimento { get; set; }

        /// <summary>
        /// Lista com os códigos da disciplina das questões.
        /// </summary>
        public List<string> Disciplinas { get; set; }

        /// <summary>
        /// Questões discursivas
        /// </summary>
        public List<QuestaoDaLista> Questoes { get; set; }
    }
}
