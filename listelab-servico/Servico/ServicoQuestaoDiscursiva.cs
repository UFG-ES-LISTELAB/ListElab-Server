﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using listelab_data.Repositorios;
using listelab_dominio.Conceitos.Filtro;
using listelab_dominio.Conceitos.QuestaoObj;
using listelab_dominio.Conceitos.RespostaObj;
using listelab_dominio.InterfaceDeServico;
using listelab_servico.Validacoes;

namespace listelab_servico.Servico
{
    public class ServicoQuestaoDiscursiva : ServicoPadrao<Questao<Discursiva>>, IServicoQuestaoDiscursiva
    {
        private IRepositorio<Questao<Discursiva>> _repositorio;
        private ValidacoesQuestaoDiscursiva _validador;

        /// <summary>
        /// Retorna o repositório de questões discursivas.
        /// </summary>
        /// <returns>Uma instância do repositório.</returns>
        protected override IRepositorio<Questao<Discursiva>> Repositorio()
        {
            return _repositorio ?? (_repositorio = new Repositorio<Questao<Discursiva>>());
        }

        /// <summary>
        /// Retorna uma instância do validador de questões discursivas.
        /// </summary>
        /// <returns>Uma instância do validador.</returns>
        protected override ValidadorPadrao<Questao<Discursiva>> Validador()
        {
            return _validador ?? (_validador = new ValidacoesQuestaoDiscursiva());
        }

        /// <summary>
        /// Consulta o primeiro objeto genérico que atende uma condição.
        /// </summary>
        /// <param name="filtro">O filtro para trazer as questões.</param>
        /// <returns>A lista de questões que se adequam ao filtro.</returns>
        public List<Questao<Discursiva>> Consulte(FiltroQuestao filtro)
        {
            return Repositorio().Consulte(ApliqueFiltro(filtro));
        }

        private Expression<Func<Questao<Discursiva>, bool>> ApliqueFiltro(Filtro filtro)
        {
            var filtroQuestao = filtro as FiltroQuestao;

            Expression<Func<Questao<Discursiva>, bool>> query = questao => (questao.NivelDificuldade == filtroQuestao.NivelDificuldade)
                || (questao.AreaDeConhecimento == filtroQuestao.AreaDeConhecimento)
                || (questao.Tipo == filtroQuestao.Tipo)
                || (questao.TempoMaximoDeResposta <= filtroQuestao.TempoMaximoDeResposta)
                || (questao.Usuario == filtroQuestao.Usuario)
                || (questao.Disciplina == filtroQuestao.Disciplina);

            return query;
        }
    }
}