using ListElab.Dominio.Dtos;
using ListElab.Dominio.Enumeradores;

namespace ListElab.Servico.Conversores
{
    /// <summary>
    /// Conversor de área de conhecimento.
    /// </summary>
    public class ConversorAreaDeConhecimento
    {
        /// <summary>
        /// Converte uma área de conhecimento do tipo enum para um dto.
        /// </summary>
        /// <param name="areaDeConhecimento">Área de conhecimento.</param>
        /// <returns>Retorna um dto de área de conhecimento.</returns>
        public DtoAreaDoConhecimento Converta(AreaDeConhecimento areaDeConhecimento)
        {
            switch (areaDeConhecimento)
            {
                case AreaDeConhecimento.CienciaComputacao:
                    return new DtoAreaDoConhecimento { Codigo = "10300007", Descricao = "CIÊNCIA DA COMPUTAÇÃO" };
                case AreaDeConhecimento.LogicaESemanticaDeProgramas:
                    return new DtoAreaDoConhecimento { Codigo = "10301046", Descricao = "LÓGICAS E SEM NTICA DE PROGRAMAS" };
                case AreaDeConhecimento.MetodologiasDaComputacao:
                    return new DtoAreaDoConhecimento { Codigo = "10303006", Descricao = "METODOLOGIA E TÉCNICAS DA COMPUTAÇÃO" };
                case AreaDeConhecimento.LinguagensDeProgramacao:
                    return new DtoAreaDoConhecimento { Codigo = "10303014", Descricao = "LINGUAGENS DE PROGRAMAÇÃO" };
                case AreaDeConhecimento.EngenhariaDeSoftware:
                    return new DtoAreaDoConhecimento { Codigo = "10303022", Descricao = "ENGENHARIA DE SOFTWARE" };
                case AreaDeConhecimento.BancoDeDados:
                    return new DtoAreaDoConhecimento { Codigo = "10303030", Descricao = "BANCO DE DADOS" };
                case AreaDeConhecimento.SistemasDeInformacao:
                    return new DtoAreaDoConhecimento { Codigo = "10303049", Descricao = "SISTEMAS DE INFORMAÇÃO" };
                case AreaDeConhecimento.ArquiteturaDeSistemasDeInformacao:
                    return new DtoAreaDoConhecimento { Codigo = "10304029", Descricao = "ARQUITETURA DE SISTEMAS DE COMPUTAÇÃO" };
                default:
                    return null;

            }
        }

        /// <summary>
        /// Converte um dto de área de conhecimento para um enumerador.
        /// </summary>
        /// <param name="dto">Dto a ser convertido.</param>
        /// <returns>Retorna o enumerador correspondente.</returns>
        public AreaDeConhecimento? Converta(DtoAreaDoConhecimento dto)
        {
            if (dto != null)
            {
                switch (dto.Codigo)
                {
                    case "10300007":
                        return AreaDeConhecimento.CienciaComputacao;
                    case "10301046":
                        return AreaDeConhecimento.LogicaESemanticaDeProgramas;
                    case "10303006":
                        return AreaDeConhecimento.MetodologiasDaComputacao;
                    case "10303014":
                        return AreaDeConhecimento.LinguagensDeProgramacao;
                    case "10303022":
                        return AreaDeConhecimento.EngenhariaDeSoftware;
                    case "10303030":
                        return AreaDeConhecimento.BancoDeDados;
                    case "10303049":
                        return AreaDeConhecimento.SistemasDeInformacao;
                    case "10304029":
                        return AreaDeConhecimento.ArquiteturaDeSistemasDeInformacao;
                    default:
                        return null;
                }
            }

            return null;
        }
    }
}
