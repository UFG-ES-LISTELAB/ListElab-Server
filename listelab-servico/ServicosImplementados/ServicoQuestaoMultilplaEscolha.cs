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
    public class ServicoQuestaoMultilplaEscolha : ServicoQuestao<MultiplaEscolha, DtoQuestaoMultiplaEscolha>
    {
        private IRepositorio<Questao<MultiplaEscolha>> repositorio;
        private ValidacoesQuestaoMultiplaEscolha validador;

        protected override IConversor<DtoQuestaoMultiplaEscolha, Questao<MultiplaEscolha>> Conversor()
        {
            return new ConversorQuestaoMultiplaEscolha();
        }

        protected override IRepositorio<Questao<MultiplaEscolha>> Repositorio()
        {
            return repositorio ?? (repositorio = new Repositorio<Questao<MultiplaEscolha>>());
        }

        protected override ValidadorPadrao<Questao<MultiplaEscolha>> Validador()
        {
            return validador ?? (validador = new ValidacoesQuestaoMultiplaEscolha());
        }

        protected override Expression<Func<Questao<MultiplaEscolha>, bool>> CondicaoConsulteUm(Guid idConvertido)
        {
            return x => x.Id == idConvertido && x.Tipo == TipoQuestao.MultiplaEscolha;
        }

        protected override Expression<Func<Questao<MultiplaEscolha>, bool>> CondicaoDeConsulta()
        {
            return x => x.Tipo == TipoQuestao.MultiplaEscolha;
        }
    }
}
