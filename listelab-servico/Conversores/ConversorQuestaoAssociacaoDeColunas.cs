using ListElab.Dominio.Conceitos.QuestaoObj;
using ListElab.Dominio.Conceitos.RespostaObj;
using ListElab.Dominio.Dtos;
using ListElab.Servico.Conversores.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace ListElab.Servico.Conversores
{
    /// <summary>
    /// Representa o conversor de associação de colunas.
    /// </summary>
    public class ConversorQuestaoAssociacaoDeColunas : IConversor<DtoQuestaoAssociacaoDeColunas, Questao<AssociacaoDeColunas>>
    {
        /// <summary>
        /// Converte uma questão de objeto para dto.
        /// </summary>
        /// <param name="objeto">A questão a ser convertida.</param>
        /// <returns>O Dto que representa a questão.</returns>
        public DtoQuestaoAssociacaoDeColunas Converta(Questao<AssociacaoDeColunas> objeto)
        {
            DtoQuestaoAssociacaoDeColunas dto = null;

            if (objeto != null)
            {
                dto = ConversorQuestao().Converta(objeto);

                dto.RespostaEsperada = new List<DtoColunas>();

                dto.RespostaEsperada = objeto.RespostaEsperada.Colunas.Select(colunas =>
                    new DtoColunas
                    {
                        ColunaAssociada = new DtoColuna { Descricao = colunas.ColunaAssociada.Descricao, Letra = colunas.ColunaAssociada.Letra },
                        ColunaPrincipal = new DtoColuna { Descricao = colunas.ColunaPrincipal.Descricao, Letra = colunas.ColunaPrincipal.Letra }
                    }).ToList();
            }

            return dto;
        }

        /// <summary>
        /// Converte um dto de questão para seu objeto.
        /// </summary>
        /// <param name="dto">Dto a ser convertido.</param>
        /// <returns>Retorna o objeto convertido.</returns>
        public Questao<AssociacaoDeColunas> Converta(DtoQuestaoAssociacaoDeColunas dto)
        {
            Questao<AssociacaoDeColunas> objeto = null;

            if (dto != null)
            {
                objeto = ConversorQuestao().Converta(dto);

                objeto.RespostaEsperada = new AssociacaoDeColunas();

                objeto.RespostaEsperada.Colunas = dto.RespostaEsperada.Select(dtoColuna => new Colunas
                {
                    ColunaPrincipal = new Coluna
                    {
                        Descricao = dtoColuna.ColunaPrincipal.Descricao,
                        Letra = dtoColuna.ColunaPrincipal.Letra
                    },
                    ColunaAssociada = new Coluna
                    {
                        Descricao = dtoColuna.ColunaAssociada.Descricao,
                        Letra = dtoColuna.ColunaAssociada.Letra
                    }
                }).ToList();
            }

            return objeto;
        }

        private ConversorQuestao<AssociacaoDeColunas, DtoQuestaoAssociacaoDeColunas> ConversorQuestao()
        {
            return new ConversorQuestao<AssociacaoDeColunas, DtoQuestaoAssociacaoDeColunas>();
        }
    }
}
