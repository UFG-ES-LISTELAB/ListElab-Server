using ListElab.Dominio.Conceitos.QuestaoObj;
using ListElab.Dominio.Dtos;
using ListElab.Dominio.Dtos.Filtro;
using ListElab.Dominio.InterfaceDeServico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ListElab.Servico.ServicosImplementados
{
    public abstract class ServicoQuestao<TObjetoResposta, TDtoQuestao> : ServicoCrudCompleto<Questao<TObjetoResposta>, TDtoQuestao>, IServicoQuestao<TObjetoResposta, TDtoQuestao>
    {
        public IEnumerable<TDtoQuestao> Consulte(Filtro filtro)
        {
            return Repositorio().Filtre(ApliqueFiltro(filtro).ToArray()).Select(x => Conversor().Converta(x));
        }

        private List<Expression<Func<Questao<TObjetoResposta>, bool>>> ApliqueFiltro(Filtro filtro)
        {
            var querys = new List<Expression<Func<Questao<TObjetoResposta>, bool>>>();

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
    }
}
