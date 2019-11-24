using ListElab.Dominio;
using ListElab.Dominio.Conceitos.RespostaObj;
using ListElab.Dominio.Dtos;
using ListElab.Dominio.Dtos.Filtro;
using ListElab.Dominio.Enumeradores;
using ListElab.Dominio.InterfaceDeServico;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;

namespace ListElab.Contrato.Controllers
{
    /// <summary>
    /// Controller de questão.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("SiteCorsPolicy")]
    public class QuestaoController : ControllerBase
    {
        IServicoQuestao<MultiplaEscolha, DtoQuestaoMultiplaEscolha> servicoMultiplaEscolha;
        IServicoQuestao<Discursiva, DtoQuestaoDiscursiva> servicoDiscursiva;
        IServicoQuestao<AssociacaoDeColunas, DtoQuestaoAssociacaoDeColunas> servicoAssociacao;

        /// <summary>
        /// Retorna um serviço de questão do tipo múltipla escolha.
        /// </summary>
        /// <returns>Retorna o serviço de múltipla escolha.</returns>
        protected IServicoQuestao<MultiplaEscolha, DtoQuestaoMultiplaEscolha> ServicoMultiplaEscolha()
        {
            return servicoMultiplaEscolha != null ? servicoMultiplaEscolha : (servicoMultiplaEscolha = FabricaGenerica.Crie<IServicoQuestao<MultiplaEscolha, DtoQuestaoMultiplaEscolha>>());
        }

        /// <summary>
        /// Retorna um serviço de questão do tipo múltipla escolha.
        /// </summary>
        /// <returns>Retorna o serviço de múltipla escolha.</returns>
        protected IServicoQuestao<Discursiva, DtoQuestaoDiscursiva> ServicoDiscursiva()
        {
            return servicoDiscursiva != null ? servicoDiscursiva : (servicoDiscursiva = FabricaGenerica.Crie<IServicoQuestao<Discursiva, DtoQuestaoDiscursiva>>());
        }

        /// <summary>
        /// Filtro de questões. Funciona de forma cumulativa. Se eu escolher nivel de dificuldade 'Fácil' e Tempo Máximo de Resposta 10 minutos, então 
        /// o a api só retornar questões que atendem aos dois filtros. Não é preciso preencher todos os filtros, somente àqueles que se deseja usar.
        /// </summary>
        /// <param name="enunciado">Adicione palavras que podem conter no enunciado.</param>
        /// <param name="nivelDificuldade">1 - 'Muito Fácil'; 2 - 'Fácil', 3 - 'Médio', 4 - 'Difícil', 5 - 'Muito Difícil'</param>
        /// <param name="tipo"></param>
        /// <param name="disciplina">Deve-se passar o código da disciplina desejada.</param>
        /// <param name="areaDeConhecimento">Deve-se passar o código da área de conhecimento desejada.</param>
        /// <param name="tempoEsperadoResposta">Tempo máximo de resposta expresso em minutos.</param>
        /// <param name="usuario">Autor da questão.</param>
        /// <param name="id">O id da questão, caso precise só de uma.</param>
        /// <param name="tags">Uma lista de tags que o professor pode colocar para identificar uma questão ao cadastrá-la.</param>
        /// <returns></returns>
        [HttpGet]
        [Authorize]
        [Route("filtro")]
        public ActionResult<DtoResultado<JObject>> ConsulteComFiltro(
            string enunciado = null,
            int nivelDificuldade = -1,
            int tipo = -1,
            string disciplina = null,
            string areaDeConhecimento = null,
            int tempoEsperadoResposta = 0,
            string usuario = null,
            string id = null,
            string[] tags = null
            )
        {
            var filtro = new Filtro
            {
                AreaDeConhecimento = new DtoAreaDoConhecimento { Codigo = areaDeConhecimento },
                Disciplina = new DtoDisciplina { Codigo = disciplina },
                NivelDificuldade = nivelDificuldade != -1 ? (NivelDificuldade)nivelDificuldade : new NivelDificuldade?(),
                TempoEsperadoResposta = tempoEsperadoResposta,
                Tipo = (TipoQuestao)tipo,
                Usuario = usuario,
                Enunciado = string.IsNullOrEmpty(enunciado) ? null : enunciado.Split(" ").ToList(),
                Tags = tags.ToList(),
                Id = id
            };

            if (tipo == 0)
            {
                filtro.Tipo = TipoQuestao.Discursiva;
                var retorno = FabricaGenerica.Crie<IServicoQuestao<Discursiva, DtoQuestaoDiscursiva>>().Consulte(filtro);
                return Ok(DtoResultado<JObject>.ObtenhaResultado(new { Discursiva = retorno, MultiplaEscolha = new List<JObject>(), AssociacaoDeColunas = new List<JObject>() }, "Consulta realizada sem erros"));
            }
            else if (tipo == 1)
            {
                filtro.Tipo = TipoQuestao.MultiplaEscolha;
                var retorno = FabricaGenerica.Crie<IServicoQuestao<MultiplaEscolha, DtoQuestaoMultiplaEscolha>>().Consulte(filtro);
                return Ok(DtoResultado<JObject>.ObtenhaResultado(new { Discursiva = new List<JObject>(), MultiplaEscolha = retorno, AssociacaoDeColunas = new List<JObject>() }, "Consulta realizada sem erros"));
            }
            else if(tipo == 2)
            {
                filtro.Tipo = TipoQuestao.Associacao;
                var retorno = FabricaGenerica.Crie<IServicoQuestao<AssociacaoDeColunas, DtoQuestaoAssociacaoDeColunas>>().Consulte(filtro);
                return Ok(DtoResultado<JObject>.ObtenhaResultado(new { Discursiva = new List<JObject>(), MultiplaEscolha = new List<JObject>(), AssociacaoDeColunas = retorno }, "Consulta realizada sem erros"));
            }
            else
            {
                filtro.Tipo = TipoQuestao.Discursiva;
                var retornoQuestaoDiscursiva = FabricaGenerica.Crie<IServicoQuestao<Discursiva, DtoQuestaoDiscursiva>>().Consulte(filtro);
                filtro.Tipo = TipoQuestao.MultiplaEscolha;
                var retornoQuestaoMultiplaEscolha = FabricaGenerica.Crie<IServicoQuestao<MultiplaEscolha, DtoQuestaoMultiplaEscolha>>().Consulte(filtro);
                filtro.Tipo = TipoQuestao.Associacao;
                var retornoAssociacao = FabricaGenerica.Crie<IServicoQuestao<AssociacaoDeColunas, DtoQuestaoAssociacaoDeColunas>>().Consulte(filtro);

                return Ok(DtoResultado<JObject>.ObtenhaResultado(new { Discursiva = retornoQuestaoDiscursiva, MultiplaEscolha = retornoQuestaoMultiplaEscolha, AssociacaoDeColunas = retornoAssociacao }, "Consulta realizada sem erros"));
            }
        }
    }
}