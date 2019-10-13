using listelab_data.Repositorios;
using listelab_dominio.Conceitos.Filtro;
using listelab_dominio.Conceitos.QuestaoObj;
using listelab_dominio.Conceitos.RespostaObj;
using listelab_dominio.InterfaceDeServico;
using listelab_servico.Validacoes;
using System;
using System.Linq.Expressions;
namespace listelab_servico.Servico
{
    public class ServicoQuestaoObjetiva : ServicoPadrao<Questao<Objetiva>>, IServicoQuestaoObjetiva
    {
        private IRepositorio<Questao<Objetiva>> _repositorio;
        private ValidacoesQuestaoObjetiva _validador;

        /// <summary>
        /// Retorna o repositório de questões discursivas.
        /// </summary>
        /// <returns>Uma instância do repositório.</returns>
        protected override IRepositorio<Questao<Objetiva>> Repositorio()
        {
            return _repositorio ?? (_repositorio = new Repositorio<Questao<Objetiva>>());
        }

        /// <summary>
        /// Retorna uma instância do validador de questões discursivas.
        /// </summary>
        /// <returns>Uma instância do validador.</returns>
        protected override ValidadorPadrao<Questao<Objetiva>> Validador()
        {
            return _validador ?? (_validador = new ValidacoesQuestaoObjetiva());
        }

        protected override Expression<Func<Questao<Objetiva>, bool>> ApliqueFiltro(Filtro filtro)
        {
            var filtroQuestao = filtro as FiltroQuestao;

            Expression<Func<Questao<Objetiva>, bool>> query = x => (x.NivelDificuldade == filtroQuestao.NivelDificuldade)
                || (x.AreaDeConhecimento == filtroQuestao.AreaDeConhecimento)
                || (x.Tipo == filtroQuestao.Tipo);

            return query;
        }
    }
}
