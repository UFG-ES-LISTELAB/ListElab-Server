using ListElab.Data.Repositorios;
using ListElab.Dominio.Conceitos.AreaDeConhecimentoObj;
using ListElab.Dominio.Conceitos.DisciplinaObj;
using ListElab.Dominio.Conceitos.QuestaoObj;
using ListElab.Dominio.Conceitos.RespostaObj;
using ListElab.Dominio.Dtos;
using ListElab.Servico.Conversores.Interfaces;
using System;

namespace ListElab.Servico.Conversores
{
    public class ConversorQuestao<TResposta, TDto> : IConversor<TDto, Questao<TResposta>> where TDto : DtoQuestao
    {
        private IRepositorio<Disciplina> repositorioDisciplina;
        private IRepositorio<AreaDeConhecimento> repositorioAreaConhecimento;

        public TDto Converta(Questao<TResposta> objeto)
        {
            TDto dto = null;

            if (objeto != null)
            {
                dto = Activator.CreateInstance<TDto>();
                dto.Id = objeto.Id;
                dto.NivelDificuldade = objeto.NivelDificuldade;
                dto.Tags = objeto.Tags;
                dto.TempoMaximoDeResposta = objeto.TempoMaximoDeResposta;
                dto.Tipo = objeto.Tipo;
                dto.Usuario = objeto.Usuario;
                dto.Enunciado = objeto.Enunciado;

                if (objeto.AreaDeConhecimento != null)
                {
                    dto.AreaDeConhecimento = new DtoAreaDoConhecimento { Codigo = objeto.AreaDeConhecimento.Codigo, Descricao = objeto.AreaDeConhecimento.Descricao };
                }

                if (objeto.Disciplina != null)
                {
                    dto.Disciplina = new DtoDisciplina { Codigo = objeto.Disciplina.Codigo, Descricao = objeto.Disciplina.Descricao };
                }
            }

            return dto;
        }

        public Questao<TResposta> Converta(TDto dto)
        {
            Questao<TResposta> questao = null;

            if (dto != null)
            {
                questao = new Questao<TResposta>();

                if (dto.Id != null && dto.Id != Guid.Empty)
                {
                    questao.Id = dto.Id;
                }

                questao.NivelDificuldade = dto.NivelDificuldade;
                questao.Tags = dto.Tags;
                questao.TempoMaximoDeResposta = dto.TempoMaximoDeResposta;
                questao.Tipo = dto.Tipo;
                questao.Usuario = dto.Usuario;
                questao.Enunciado = dto.Enunciado;

                if (dto.AreaDeConhecimento != null)
                {
                    questao.AreaDeConhecimento = RepositorioAreaDeConhecimento().ConsulteUm(x => x.Codigo == dto.AreaDeConhecimento.Codigo);
                }

                if (dto.Disciplina != null)
                {
                    questao.Disciplina = RepositorioDisciplina().ConsulteUm(x => x.Codigo == dto.Disciplina.Codigo);

                }
            }

            return questao;
        }

        private IRepositorio<Disciplina> RepositorioDisciplina()
        {
            return repositorioDisciplina ?? (repositorioDisciplina = new Repositorio<Disciplina>());
        }

        private IRepositorio<AreaDeConhecimento> RepositorioAreaDeConhecimento()
        {
            return repositorioAreaConhecimento ?? (repositorioAreaConhecimento = new Repositorio<AreaDeConhecimento>());
        }
    }
}
