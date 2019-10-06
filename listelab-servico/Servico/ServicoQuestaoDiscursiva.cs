using System;
using System.Linq.Expressions;
using listelab_data.Repositorios;
using listelab_dominio.Conceitos;
using listelab_dominio.Conceitos.Filtro;
using listelab_dominio.Conceitos.Questao;
using listelab_dominio.Conceitos.Resposta;
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

        protected override Expression<Func<Questao<Discursiva>, bool>> ApliqueFiltro(Filtro filtro)
        {
            var filtroQuestao = filtro as FiltroQuestao;

            Expression<Func<Questao<Discursiva>, bool>> query = x => (x.NivelDificuldade == filtroQuestao.NivelDificuldade)
                || (x.AreaDeConhecimento == filtroQuestao.AreaDeConhecimento)
                || (x.Tipo == filtroQuestao.Tipo);

            return query;
        }
    }
}
