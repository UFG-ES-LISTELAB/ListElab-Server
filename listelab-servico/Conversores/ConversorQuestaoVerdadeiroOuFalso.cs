using ListElab.Dominio.Conceitos.QuestaoObj;
using ListElab.Dominio.Conceitos.RespostaObj;
using ListElab.Dominio.Dtos;
using ListElab.Servico.Conversores.Interfaces;
using System.Linq;

namespace ListElab.Servico.Conversores
{
    /// <summary>
    /// Conversor de objetos para dtos.
    /// </summary>
    public class ConversorQuestaoVerdadeiroOuFalso : IConversor<DtoQuestaoVerdadeiroOuFalso, Questao<VerdadeiroOuFalso>>
    {
        /// <summary>
        /// Converte uma questão de objeto para dto.
        /// </summary>
        /// <param name="objeto">A questão a ser convertida.</param>
        /// <returns>O Dto que representa a questão.</returns>
        public DtoQuestaoVerdadeiroOuFalso Converta(Questao<VerdadeiroOuFalso> objeto)
        {
            DtoQuestaoVerdadeiroOuFalso dto = null;

            if (objeto != null)
            {
                dto = ConversorQuestao().Converta(objeto) as DtoQuestaoVerdadeiroOuFalso;

                dto.RespostaEsperada = objeto.RespostaEsperada.Afirmacao.Select(escolha => new DtoEscolha { Descricao = escolha.Descricao, Correta = escolha.Correta }).ToList();
            }

            return dto;
        }

        /// <summary>
        /// Converte um dto de questão para seu objeto.
        /// </summary>
        /// <param name="dto">Dto a ser convertido.</param>
        /// <returns>Retorna o objeto convertido.</returns>
        public Questao<VerdadeiroOuFalso> Converta(DtoQuestaoVerdadeiroOuFalso dto)
        {
            Questao<VerdadeiroOuFalso> objeto = null;

            if (dto != null)
            {
                objeto = ConversorQuestao().Converta(dto);

                objeto.RespostaEsperada = new VerdadeiroOuFalso();
                objeto.RespostaEsperada.Afirmacao = dto.RespostaEsperada.Select(dtoEscolha => new Escolha { Descricao = dtoEscolha.Descricao, Correta = dtoEscolha.Correta }).ToList();
            }

            return objeto;
        }

        private ConversorQuestao<VerdadeiroOuFalso, DtoQuestaoVerdadeiroOuFalso> ConversorQuestao()
        {
            return new ConversorQuestao<VerdadeiroOuFalso, DtoQuestaoVerdadeiroOuFalso>();
        }
    }
}
