using ListElab.Data.Repositorios;
using ListElab.Dominio.Conceitos.Filtro;
using ListElab.Dominio.Conceitos.ListaObj;
using ListElab.Dominio.Conceitos.QuestaoObj;
using ListElab.Dominio.Conceitos.RespostaObj;
using ListElab.Dominio.InterfaceDeServico;
using ListElab.Servico.Validacoes;
using System.Collections.Generic;
using System.Linq;

namespace ListElab.Servico.Servico
{
    public class ServicoListaQuestoes : ServicoPadrao<ListaQuestoes>, IServicoListaQuestoes
    {
        private IRepositorio<ListaQuestoes> _repositorio;
        private ValidacoesListaQuestoes _validador;

        /// <summary>
        /// Resposta uma lista de questões a partir de um filtro especificado
        /// </summary>
        /// <param name="filtro"></param>
        /// <returns></returns>
        public ListaQuestoes ConsulteQuestoes(FiltroQuestao filtro)
        {
            //TODO: Por hora a consulta retornará apenas questões discursivas.
            //Há um problema na desserialização de questões objetivas que será
            //revisto na próxima iteração e para que não ocasione erros na API,
            //a obtenção das questões objetivas está comentada.
            return new ListaQuestoes()
            {
                Discursivas = obtenhaQuestoes<Discursiva>(filtro),
                //Objetivas = obtenhaQuestoes<Objetiva>(filtro)
            };
        }

        private List<Questao<T>> obtenhaQuestoes<T>(FiltroQuestao filtro)
        {
            var repositorio = new Repositorio<Questao<T>>();
            var questoes = repositorio.ConsulteLista(x => x.AreaDeConhecimento.Equals(filtro.AreaDeConhecimento)
                                     || x.Disciplina.Equals(filtro.Disciplina)
                                     || x.NivelDificuldade.Equals(filtro.NivelDificuldade));
            return questoes.ToList();
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
