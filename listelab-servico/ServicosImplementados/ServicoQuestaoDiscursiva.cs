using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using ListElab.Data.Repositorios;
using ListElab.Dominio.Conceitos.QuestaoObj;
using ListElab.Dominio.Conceitos.RespostaObj;
using ListElab.Dominio.Dtos;
using ListElab.Dominio.Enumeradores;
using ListElab.Servico.Conversores;
using ListElab.Servico.Conversores.Interfaces;
using ListElab.Servico.Validacoes;

namespace ListElab.Servico.ServicosImplementados
{
    public class ServicoQuestaoDiscursiva : ServicoQuestao<Discursiva, DtoQuestaoDiscursiva>
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

        protected override IConversor<DtoQuestaoDiscursiva, Questao<Discursiva>> Conversor()
        {
            return new ConversorQuestaoDiscursiva();
        }

        protected override Expression<Func<Questao<Discursiva>, bool>> CondicaoConsulteUm(Guid idConvertido)
        {
            return x => x.Id == idConvertido && x.Tipo == TipoQuestao.Discursiva;
        }

        protected override Expression<Func<Questao<Discursiva>, bool>> CondicaoDeConsulta()
        {
            return x => x.Tipo == TipoQuestao.Discursiva;
        }
    }
}
