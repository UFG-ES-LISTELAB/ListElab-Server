using ListElab.Dominio.Conceitos.QuestaoObj;
using ListElab.Dominio.Conceitos.RespostaObj;
using ListElab.Dominio.Dtos;
using ListElab.Servico.Conversores.Interfaces;
using System.Collections.Generic;
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
                dto = ConversorQuestao().Converta(objeto);

                dto.RespostaEsperada = new List<DtoPalavraChave>();

                dto.RespostaEsperada = objeto.RespostaEsperada.PalavrasChaves.Select(palavraChave => new DtoPalavraChave { Descricao = palavraChave.Descricao, Peso = palavraChave.Peso }).ToList();
            }

            return dto;
        }

        public Questao<Discursiva> Converta(DtoQuestaoDiscursiva dto)
        {
            Questao<Discursiva> objeto = null;

            if (dto != null)
            {
                objeto = ConversorQuestao().Converta(dto);

                objeto.RespostaEsperada = new Discursiva();
                objeto.RespostaEsperada.PalavrasChaves = dto.RespostaEsperada.Select(dtoPalavra => new PalavraChave { Descricao = dtoPalavra.Descricao, Peso = dtoPalavra.Peso }).ToList();
            }

            return objeto;
        }

        private ConversorQuestao<Discursiva, DtoQuestaoDiscursiva> ConversorQuestao()
        {
            return new ConversorQuestao<Discursiva, DtoQuestaoDiscursiva>();
        }
    }
}
