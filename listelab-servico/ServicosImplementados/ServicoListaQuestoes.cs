using ListElab.Data.Repositorios;
using ListElab.Dominio.Conceitos.ListaObj;
using ListElab.Dominio.Dtos;
using ListElab.Dominio.Dtos.Filtro;
using ListElab.Dominio.InterfaceDeServico;
using ListElab.Servico.Conversores;
using ListElab.Servico.Conversores.Interfaces;
using ListElab.Servico.Validacoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ListElab.Servico.ServicosImplementados
{
    public class ServicoListaQuestoes : ServicoCrudCompleto<ListaQuestoes, DtoListaQuestoes>, IServicoListaQuestoes
    {
        private IRepositorio<ListaQuestoes> _repositorio;
        private ValidacoesListaQuestoes _validador;

        /// <summary>
        /// Retorna uma lista de questões de acordo com o filtro passado.
        /// </summary>
        /// <param name="filtro">O filtro passado para pesquisar a lista.</param>
        /// <returns>A lista de lista de questões.</returns>
        public IEnumerable<DtoListaQuestoes> Consulte(Filtro filtro)
        {
            return Repositorio().Filtre(ApliqueFiltro(filtro).ToArray()).Select(x => Conversor().Converta(x));
        }

        private List<Expression<Func<ListaQuestoes, bool>>> ApliqueFiltro(Filtro filtro)
        {
            var querys = new List<Expression<Func<ListaQuestoes, bool>>>();

            filtro.AreaDeConhecimento = filtro.AreaDeConhecimento ?? new DtoAreaDoConhecimento();
            filtro.Disciplina = filtro.Disciplina ?? new DtoDisciplina();

            if (filtro.AreaDeConhecimento.Codigo != null)
            {
                querys.Add(lista => lista.AreasDeConhecimento.Any(codigo => codigo == filtro.AreaDeConhecimento.Codigo));

            }

            if (filtro.NivelDificuldade != null)
            {
                querys.Add(lista => lista.NivelDificuldade == (int)filtro.NivelDificuldade);

            }

            if (filtro.Disciplina.Codigo != null)
            {
                querys.Add(lista => lista.Disciplinas.Any(codigo => codigo == filtro.Disciplina.Codigo));

            }

            if (filtro.Usuario != null)
            {
                querys.Add(lista => lista.Usuario == filtro.Usuario);
            }

            if (filtro.TempoEsperadoResposta != 0)
            {
                querys.Add(lista => lista.TempoEsperadoResposta <= filtro.TempoEsperadoResposta);

            }

            if (filtro.Tags != null && filtro.Tags.Any())
            {
                querys.Add(lista => filtro.Tags.Any(tag => lista.Tags.Contains(tag)));
            }

            if (filtro.Id != null)
            {
                if (Guid.TryParse(filtro.Id, out var id))
                {
                    querys.Add(questao => questao.Id == id);
                }
                else
                {
                    throw new Exception("Não foi passado um id válido para a lista.");
                }
            }

            return querys;
        }

        protected override IRepositorio<ListaQuestoes> Repositorio()
        {
            return _repositorio ?? (_repositorio = new Repositorio<ListaQuestoes>());
        }

        protected override ValidadorPadrao<ListaQuestoes> Validador()
        {
            return _validador ?? (_validador = new ValidacoesListaQuestoes());
        }

        protected override IConversor<DtoListaQuestoes, ListaQuestoes> Conversor()
        {
            return new ConversorListaDeQuestoes();
        }
    }
}
