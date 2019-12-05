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
    public class ServicoQuestaoAssociacaoDeColunas : ServicoQuestao<AssociacaoDeColunas, DtoQuestaoAssociacaoDeColunas>
    {
        private IRepositorio<Questao<AssociacaoDeColunas>> repositorio;
        private ValidacoesQuestaoAssociacaoDeColuna validador;

        protected override IConversor<DtoQuestaoAssociacaoDeColunas, Questao<AssociacaoDeColunas>> Conversor() => new ConversorQuestaoAssociacaoDeColunas();

        protected override IRepositorio<Questao<AssociacaoDeColunas>> Repositorio()
        {
            return repositorio ?? (repositorio = new Repositorio<Questao<AssociacaoDeColunas>>());
        }

        protected override ValidadorPadrao<Questao<AssociacaoDeColunas>> Validador()
        {
            return validador ?? (validador = new ValidacoesQuestaoAssociacaoDeColuna());
        }

        protected override Expression<Func<Questao<AssociacaoDeColunas>, bool>> CondicaoDeConsulta()
        {
            return x => x.Tipo == TipoQuestao.Associacao;
        }
    }
}
