using listelab_data.Repositorios;
using listelab_dominio.Conceitos.Filtro;
using listelab_dominio.Conceitos.ListaObj;
using listelab_dominio.Conceitos.QuestaoObj;
using listelab_dominio.Conceitos.RespostaObj;
using listelab_dominio.InterfaceDeServico;
using listelab_servico.Validacoes;
using System.Linq;
using System.Collections.Generic;

namespace listelab_servico.Servico
{
    public class ServicoListaQuestoes : ServicoPadrao<ListaQuestoes>, IServicoListaQuestoes
    {
        private IRepositorio<ListaQuestoes> _repositorio;
        private ValidacoesListaQuestoes _validador;

        public List<Questao<Discursiva>> ConsulteQuestoesDiscursivas(FiltroQuestao filtro)
        {
            var repositorio = new Repositorio<Questao<Discursiva>>();
            var listaDeQuestoes = repositorio.ConsulteLista(x => x.AreaDeConhecimento.Equals(filtro.AreaDeConhecimento) 
                                     || x.Disciplina.Equals(filtro.Disciplina) 
                                     || x.NivelDificuldade.Equals(filtro.NivelDificuldade));
            return listaDeQuestoes.ToList();
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
