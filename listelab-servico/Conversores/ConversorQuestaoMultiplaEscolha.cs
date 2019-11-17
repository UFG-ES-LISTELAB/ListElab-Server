using ListElab.Dominio.Conceitos.QuestaoObj;
using ListElab.Dominio.Conceitos.RespostaObj;
using ListElab.Dominio.Dtos;
using ListElab.Servico.Conversores.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ListElab.Servico.Conversores
{
    /// <summary>
    /// Conversor de questão múltipla escolha
    /// </summary>
    public class ConversorQuestaoMultiplaEscolha : IConversor<DtoQuestaoMultiplaEscolha, Questao<MultiplaEscolha>>
    {
        public DtoQuestaoMultiplaEscolha Converta(Questao<MultiplaEscolha> objeto)
        {
            DtoQuestaoMultiplaEscolha dto = null;

            if (objeto != null)
            {
                dto = ConversorQuestao().Converta(objeto) as DtoQuestaoMultiplaEscolha;

                dto.RespostaEsperada = objeto.RespostaEsperada.Alternativas.Select(escolha => new DtoEscolha { Descricao = escolha.Descricao, Correta = escolha.Correta }).ToList();
            }

            return dto;
        }

        public Questao<MultiplaEscolha> Converta(DtoQuestaoMultiplaEscolha dto)
        {
            Questao<MultiplaEscolha> objeto = null;

            if (dto != null)
            {
                objeto = ConversorQuestao().Converta(dto);

                objeto.RespostaEsperada = new MultiplaEscolha();
                objeto.RespostaEsperada.Alternativas = dto.RespostaEsperada.Select(dtoEscolha => new Escolha { Descricao = dtoEscolha.Descricao, Correta = dtoEscolha.Correta }).ToList();
            }

            return objeto;
        }

        private ConversorQuestao<MultiplaEscolha, DtoQuestaoMultiplaEscolha> ConversorQuestao()
        {
            return new ConversorQuestao<MultiplaEscolha, DtoQuestaoMultiplaEscolha>();
        }
    }
}
