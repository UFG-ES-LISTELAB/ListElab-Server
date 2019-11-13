using ListElab.Data.Repositorios;
using ListElab.Dominio.Conceitos.AreaDeConhecimentoObj;
using ListElab.Dominio.Conceitos.DisciplinaObj;
using ListElab.Dominio.Conceitos.QuestaoObj;
using ListElab.Dominio.Conceitos.RespostaObj;
using ListElab.Dominio.Dtos;
using ListElab.Servico.Conversores.Interfaces;
using System;
using System.Linq;

namespace ListElab.Servico.Conversores
{
    public class ConversorQuestaoDiscursiva : IConversor<DtoQuestaoDiscursiva, Questao<Discursiva>>
    {
        private IRepositorio<Disciplina> repositorioDisciplina;
        private IRepositorio<AreaDeConhecimento> repositorioAreaConhecimento;

        public DtoQuestaoDiscursiva Converta(Questao<Discursiva> objeto)
        {
            DtoQuestaoDiscursiva dto = null;

            if (objeto != null)
            {
                dto = new DtoQuestaoDiscursiva();
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
                
                dto.RespostaEsperada = objeto.RespostaEsperada.PalavrasChaves.Select(x => new DtoPalavraChave { Descricao = x.Descricao, Peso = x.Peso }).ToList();
            }

            return dto;
        }

        public Questao<Discursiva> Converta(DtoQuestaoDiscursiva dto)
        {
            Questao<Discursiva> questao = null;

            if (dto != null)
            {
                questao = new Questao<Discursiva>();

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

                questao.RespostaEsperada = new Discursiva { PalavrasChaves = dto.RespostaEsperada.Select(x => new PalavraChave { Descricao = x.Descricao, Peso = x.Peso }).ToList() };
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
