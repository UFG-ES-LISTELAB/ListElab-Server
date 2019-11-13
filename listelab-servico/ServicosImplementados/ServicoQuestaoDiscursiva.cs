using ListElab.Data.Repositorios;
using ListElab.Dominio.Conceitos.QuestaoObj;
using ListElab.Dominio.Conceitos.RespostaObj;
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
    public class ServicoQuestaoDiscursiva : ServicoCrudCompleto<Questao<Discursiva>, DtoQuestaoDiscursiva>, IServicoQuestaoDiscursiva
    {
        private IRepositorio<Questao<Discursiva>> _repositorio;
        private ValidacoesQuestaoDiscursiva _validador;

        /// <summary>
        /// Consulta o primeiro objeto genérico que atende uma condição.
        /// </summary>
        /// <param name="filtro">O filtro para trazer as questões.</param>
        /// <returns>A lista de questões que se adequam ao filtro.</returns>
        public IEnumerable<DtoQuestaoDiscursiva> Consulte(Filtro filtro)
        {
            return Repositorio().Filtre(ApliqueFiltro(filtro).ToArray()).Select(x => Conversor().Converta(x));
        }

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

        private List<Expression<Func<Questao<Discursiva>, bool>>> ApliqueFiltro(Filtro filtro)
        {
            var querys = new List<Expression<Func<Questao<Discursiva>, bool>>>();

            filtro.AreaDeConhecimento = filtro.AreaDeConhecimento ?? new DtoAreaDoConhecimento();
            filtro.Disciplina = filtro.Disciplina ?? new DtoDisciplina();

            if (filtro.AreaDeConhecimento.Codigo != null)
            {
                querys.Add(questao => questao.AreaDeConhecimento.Codigo == filtro.AreaDeConhecimento.Codigo);
            }

            if (filtro.NivelDificuldade != null)
            {
                querys.Add(questao => questao.NivelDificuldade == filtro.NivelDificuldade);

            }

            if (filtro.Disciplina.Codigo != null)
            {
                querys.Add(questao => questao.Disciplina.Codigo == filtro.Disciplina.Codigo);

            }

            if (filtro.Tipo != null)
            {
                querys.Add(questao => questao.Tipo == filtro.Tipo);

            }

            if (filtro.Usuario != null)
            {
                querys.Add(questao => questao.Usuario == filtro.Usuario);

            }

            if (filtro.TempoEsperadoResposta != 0)
            {
                querys.Add(questao => questao.TempoMaximoDeResposta <= filtro.TempoEsperadoResposta);

            }

            if (filtro.Tags != null && filtro.Tags.Any())
            {
                querys.Add(questao => questao.Tags.All(tag => filtro.Tags.Contains(tag)));
            }

            if (filtro.Enunciado != null && filtro.Enunciado.Any())
            {
                querys.Add(questao => filtro.Enunciado.All(enunciado => questao.Enunciado.Contains(enunciado)));
            }

            if (filtro.Id != null)
            {
                if (Guid.TryParse(filtro.Id, out var id))
                {
                    querys.Add(questao => questao.Id == id);
                }
                else
                {
                    throw new Exception("Não foi passado um id válido para a questão.");
                }
            }

            return querys;
        }

        protected override IConversor<DtoQuestaoDiscursiva, Questao<Discursiva>> Conversor()
        {
            return new ConversorQuestaoDiscursiva();
        }
    }
}
