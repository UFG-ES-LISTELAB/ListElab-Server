using ListElab.Data.Repositorios;
using ListElab.Dominio.Conceitos.QuestaoObj;
using ListElab.Dominio.Conceitos.RespostaObj;
using ListElab.Dominio.Dtos;
using ListElab.Dominio.Enumeradores;
using ListElab.Servico.Conversores;
using ListElab.Servico.Conversores.Interfaces;
using ListElab.Servico.Validacoes;
using System;
using System.Linq.Expressions;

namespace ListElab.Servico.ServicosImplementados
{
    /// <summary>
    /// Serviço de questão verdadeiro ou falso.
    /// </summary>
    public class ServicoQuestaoVerdadeiroOuFalso : ServicoQuestao<VerdadeiroOuFalso, DtoQuestaoVerdadeiroOuFalso>
    {
        private IRepositorio<Questao<VerdadeiroOuFalso>> _repositorio;
        private ValidacoesQuestaoVerdadeiroOuFalso _validador;

        protected override IConversor<DtoQuestaoVerdadeiroOuFalso, Questao<VerdadeiroOuFalso>> Conversor()
        {
            return new ConversorQuestaoVerdadeiroOuFalso();
        }

        protected override IRepositorio<Questao<VerdadeiroOuFalso>> Repositorio()
        {
            return _repositorio ?? (_repositorio = new Repositorio<Questao<VerdadeiroOuFalso>>());
        }

        protected override ValidadorPadrao<Questao<VerdadeiroOuFalso>> Validador()
        {
            return _validador ?? (_validador = new ValidacoesQuestaoVerdadeiroOuFalso());
        }

        protected override Expression<Func<Questao<VerdadeiroOuFalso>, bool>> CondicaoConsulteUm(Guid idConvertido)
        {
            return x => x.Id == idConvertido && x.Tipo == TipoQuestao.VerdadeiroOuFalso;
        }

        protected override Expression<Func<Questao<VerdadeiroOuFalso>, bool>> CondicaoDeConsulta()
        {
            return x => x.Tipo == TipoQuestao.VerdadeiroOuFalso;
        }
    }
}
