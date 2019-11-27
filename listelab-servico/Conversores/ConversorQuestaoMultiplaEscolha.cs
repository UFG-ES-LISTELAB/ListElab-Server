using ListElab.Dominio.Conceitos.QuestaoObj;
using ListElab.Dominio.Conceitos.RespostaObj;
using ListElab.Dominio.Dtos;
using ListElab.Servico.Conversores.Interfaces;
using System.Linq;

namespace ListElab.Servico.Conversores
{
    /// <summary>
    /// Conversor de questão múltipla escolha
    /// </summary>
    public class ConversorQuestaoMultiplaEscolha : IConversor<DtoQuestaoMultiplaEscolha, Questao<MultiplaEscolha>>
    {
        /// <summary>
        /// Converte uma questão de objeto para dto.
        /// </summary>
        /// <param name="objeto">A questão a ser convertida.</param>
        /// <returns>O Dto que representa a questão.</returns>
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

        /// <summary>
        /// Converte um dto de questão para seu objeto.
        /// </summary>
        /// <param name="dto">Dto a ser convertido.</param>
        /// <returns>Retorna o objeto convertido.</returns>
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
