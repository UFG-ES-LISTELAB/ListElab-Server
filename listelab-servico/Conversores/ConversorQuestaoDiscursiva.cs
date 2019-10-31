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
                dto.AreaDeConhecimento = new ConversorAreaDeConhecimento().Converta(objeto.AreaDeConhecimento);
                dto.Disciplina = new ConversorDisciplina().Converta(objeto.Disciplina);
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
                questao.AreaDeConhecimento = new ConversorAreaDeConhecimento().Converta(dto.AreaDeConhecimento).GetValueOrDefault();
                questao.Disciplina = new ConversorDisciplina().Converta(dto.Disciplina).GetValueOrDefault();
                questao.RespostaEsperada = new Discursiva { PalavrasChaves = dto.RespostaEsperada.Select(x => new PalavraChave { Descricao = x.Descricao, Peso = x.Peso }).ToList() };
            }

            return questao;
        }
    }
}
