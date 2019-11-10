using ListElab.Dominio.Conceitos.ListaObj;
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
    /// Api para Lista
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ListaController : ControladorPadrao<ListaQuestoes, IServicoListaQuestoes, DtoListaQuestoes>
    {
        /// <summary>
        /// Filtro de lista. Funciona de forma cumulativa. Se eu escolher nivel de dificuldade 'Fácil' e Tempo Máximo de Resposta 10 minutos, então 
        /// o a api só retornar as listas que atendem aos dois filtros. Não é preciso preencher todos os filtros, somente àqueles que se deseja usar.
        /// </summary>
        /// <param name="nivelDificuldade">1 - 'Muito Fácil'; 2 - 'Fácil', 3 - 'Médio', 4 - 'Difícil', 5 - 'Muito Difícil'</param>
        /// <param name="disciplina">Deve-se passar o código da disciplina desejada. O filtro busca por listas que possuem questões dessa disciplina.</param>
        /// <param name="areaDeConhecimento">Deve-se passar o código da área de conhecimento desejada. O filtro busca por listas que possuem questões dessa área de conhecimento.</param>
        /// <param name="tempoEsperadoResposta">Tempo máximo de resposta da lista expresso em minutos.</param>
        /// <param name="usuario">Autor da lista.</param>
        /// <param name="id">O id da lista, caso precise só de uma.</param>
        /// <param name="tags">Busca as tags das questões e traz as listas que possuem questões com as tags passada.</param>
        /// <returns></returns>
        [HttpGet]
        [Authorize]
        [Route("filtro")]
        public ActionResult<DtoResultado<DtoListaQuestoes>> ConsulteComFiltro(
            int nivelDificuldade = -1,
            string disciplina = null,
            string areaDeConhecimento = null,
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
                    Usuario = usuario,
                    Tags = tags.ToList(),
                    Id = id
                };

                var resultado = Servico().Consulte(filtro);

                return Ok(DtoResultado<DtoListaQuestoes>.ObtenhaResultado(resultado, "Consulta realizada sem erros"));
            });
        }
    }
}