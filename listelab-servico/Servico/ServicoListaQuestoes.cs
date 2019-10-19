using listelab_data.Repositorios;
using listelab_dominio.Conceitos.Filtro;
using listelab_dominio.Conceitos.ListaObj;
using listelab_dominio.InterfaceDeServico;
using listelab_servico.Validacoes;
using System;
using System.Linq.Expressions;

namespace listelab_servico.Servico
{
    public class ServicoListaQuestoes : ServicoPadrao<ListaQuestoes>, IServicoListaQuestoes
    {
        private IRepositorio<ListaQuestoes> _repositorio;
        private ValidacoesListaQuestoes _validador;

        protected override Expression<Func<ListaQuestoes, bool>> ApliqueFiltro(Filtro filtro)
        {
            throw new NotImplementedException();
        }

        protected override IRepositorio<ListaQuestoes> Repositorio()
        {
            return _repositorio ?? (_repositorio = new Repositorio<ListaQuestoes>());
        }

        protected override ValidadorPadrao<ListaQuestoes> Validador()
        {
            return _validador ?? (_validador = new ValidacoesListaQuestoes());
        }
    }
}
