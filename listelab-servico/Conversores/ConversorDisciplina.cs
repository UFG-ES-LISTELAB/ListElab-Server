using System;
using ListElab.Dominio.Dtos;
using ListElab.Dominio.Enumeradores;

namespace ListElab.Servico.Conversores
{
    /// <summary>
    /// Conversor de disciplina.
    /// </summary>
    public class ConversorDisciplina
    {
        /// <summary>
        /// Converte uma disciplina do tipo enum para um dto.
        /// </summary>
        /// <param name="disciplina">Disciplina a ser convertida.</param>
        /// <returns>Retorna um dto de disciplina.</returns>
        public DtoDisciplina Converta(Disciplina disciplina)
        {
            switch (disciplina)
            {
                case Disciplina.EngenhariaEconomicaParaSoftware:
                    return new DtoDisciplina { Codigo = "INF0233", Descricao = "Engenharia Econômica para Software" };
                case Disciplina.MercadoInternoExternoSoftware:
                    return new DtoDisciplina { Codigo = "INF0137", Descricao = "Mercado Interno e Externo de Software" };
                case Disciplina.Integracao2:
                    return new DtoDisciplina { Codigo = "INF0089", Descricao = "Integração 2" };
                case Disciplina.PraticaEngenhariaSoftware:
                    return new DtoDisciplina { Codigo = "INF0150", Descricao = "Prática em Engenharia de Software" };
                case Disciplina.TecnicasAvancadasConstrucaoSoftware:
                    return new DtoDisciplina { Codigo = "INF0207", Descricao = "Técnicas Avançadas de Construção de Software" };
                case Disciplina.IntroducaoALinguagemSinais:
                    return new DtoDisciplina { Codigo = "FAL0214", Descricao = "Introdução a Língua Brasileira de Sinais" };
                default:
                    return null;

            }
        }

        /// <summary>
        /// Converte um dto de disciplina para um enumerador.
        /// </summary>
        /// <param name="dto">Dto a ser convertido.</param>
        /// <returns>Retorna o enumerador correspondente.</returns>
        public Disciplina? Converta(DtoDisciplina dto)
        {
            if (dto != null)
            {
                switch (dto.Codigo)
                {
                    case "INF0233":
                        return Disciplina.EngenhariaEconomicaParaSoftware;
                    case "INF0137":
                        return Disciplina.MercadoInternoExternoSoftware;
                    case "INF0089":
                        return Disciplina.Integracao2;
                    case "INF0150":
                        return Disciplina.PraticaEngenhariaSoftware;
                    case "INF0207":
                        return Disciplina.TecnicasAvancadasConstrucaoSoftware;
                    case "FAL0214":
                        return Disciplina.IntroducaoALinguagemSinais;
                    default:
                        return null;
                }
            }

            return null;
        }
    }
}
