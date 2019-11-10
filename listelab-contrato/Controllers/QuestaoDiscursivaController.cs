using ListElab.Dominio.Conceitos.QuestaoObj;
using ListElab.Dominio.Conceitos.RespostaObj;
using ListElab.Dominio.Dtos;
using ListElab.Dominio.Dtos.Filtro;
using ListElab.Dominio.Enumeradores;
using ListElab.Dominio.InterfaceDeServico;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace ListElab.Contrato.Controllers
{
    /// <summary>
    /// Api para o conceito de questão discursiva.
    /// </summary>
    public class QuestaoDiscursivaController : ControladorPadrao<Questao<Discursiva>, IServicoQuestaoDiscursiva, DtoQuestaoDiscursiva>
    {
        /// <summary>
        /// Filtro de questões. Funciona de forma cumulativa. Se eu escolher nivel de dificuldade 'Fácil' e Tempo Máximo de Resposta 10 minutos, então 
        /// o a api só retornar questões que atendem aos dois filtros. Não é preciso preencher todos os filtros, somente àqueles que se deseja usar.
        /// </summary>
        /// <param name="nivelDificuldade">1 - 'Muito Fácil'; 2 - 'Fácil', 3 - 'Médio', 4 - 'Difícil', 5 - 'Muito Difícil'</param>
        /// <param name="disciplina">Deve-se passar o código da disciplina desejada.</param>
        /// <param name="areaDeConhecimento">Deve-se passar o código da área de conhecimento desejada.</param>
        /// <param name="tipoQuestao">0 - 'Discursiva'; 1 - 'Objetiva'</param>
        /// <param name="tempoEsperadoResposta">Tempo máximo de resposta expresso em minutos.</param>
        /// <param name="usuario">Autor da questão.</param>
        /// <param name="id">O id da questão, caso precise só de uma.</param>
        /// <param name="tags">Uma lista de tags que o professor pode colocar para identificar uma questão ao cadastrá-la.</param>
        /// <returns></returns>
        [HttpGet]
        [Authorize]
        [Route("filtro")]
        public ActionResult<DtoResultado<DtoQuestaoDiscursiva>> ConsulteComFiltro(
            string enunciado = null,
            int nivelDificuldade = -1,
            string disciplina = null,
            string areaDeConhecimento = null,
            int tipoQuestao = -1,
            int tempoEsperadoResposta = 0,
            string usuario = null,
            string id = null,
            string[] tags = null
            )
        {
            return ExecuteAcaoAutorizada(() =>
            {
                var filtro = new Filtro
                {
                    AreaDeConhecimento = new DtoAreaDoConhecimento { Codigo = areaDeConhecimento },
                    Disciplina = new DtoDisciplina { Codigo = disciplina },
                    NivelDificuldade = nivelDificuldade != -1 ? (NivelDificuldade)nivelDificuldade : new NivelDificuldade?(),
                    TempoEsperadoResposta = tempoEsperadoResposta,
                    Tipo = tipoQuestao != -1 ? (TipoQuestao)tipoQuestao : new TipoQuestao?(),
                    Usuario = usuario,
                    Enunciado = string.IsNullOrEmpty(enunciado) ? null : enunciado.Split(" ").ToList(),
                    Tags = tags.ToList(),
                    Id = id
                };

                var resultado = Servico().Consulte(filtro);

                return Ok(DtoResultado<DtoListaQuestoes>.ObtenhaResultado(resultado, "Consulta realizada sem erros"));
            });
        }
    }
}
