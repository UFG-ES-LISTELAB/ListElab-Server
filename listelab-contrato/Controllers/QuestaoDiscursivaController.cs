using System;
using listelab_contrato.RequestObject;
using listelab_dominio;
using listelab_dominio.Conceitos;
using listelab_dominio.Conceitos.QuestaoObj;
using listelab_dominio.Conceitos.RespostaObj;
using listelab_dominio.InterfaceDeServico;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace listelab_contrato.Controllers
{
    /// <summary>
    /// Api para o conceito de questão discursiva.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class QuestaoDiscursivaController : ControllerBase
    {
        /// <summary>
        /// Lista todas as questões discursivas cadastradas.
        /// </summary>
        /// <returns>Retorna um objeto de sucesso ou falha e a lista desejada, caso sucesso.</returns>
        [HttpGet]
        [Authorize]
        public ActionResult<ObjetoResult<Questao<RespostaDiscursiva>>> Get()
        {
            try
            {
                var servico = FabricaGenerica.Crie<IServicoQuestaoDiscursiva>();
                var questao = servico.ConsulteLista();

                return ObjetoResult<Questao<RespostaDiscursiva>>.ReturnResult(questao, "Consulta realizada sem erros");
            }
            catch (Exception e)
            {
                return ObjetoResult<Questao<RespostaDiscursiva>>.ReturnResultError(e);
            }
        }

        /// <summary>
        /// Retorna a questão discursiva do código informado.
        /// </summary>
        /// <param name="codigo">O código da questão discursiva que se deseja buscar.</param>
        /// <returns>Retorna objeto de resposta de sucesso ou falha, contendo o objeto desejado, caso sucesso.</returns>
        [HttpGet("{codigo}")]
        [Authorize]
        public ActionResult<ObjetoResult<Questao<RespostaDiscursiva>>> Get(int codigo)
        {
            try
            {
                var servico = FabricaGenerica.Crie<IServicoQuestaoDiscursiva>();
                var questao = servico.Consulte(codigo);

                return ObjetoResult<Questao<RespostaDiscursiva>>.ReturnResult(questao, "Consulta realizada sem erros");
            }
            catch (Exception e)
            {
                return ObjetoResult<Questao<RespostaDiscursiva>>.ReturnResultError(e);
            }
        }

        /// <summary>
        /// Cadastra uma questão discursiva.
        /// </summary>
        /// <param name="questao">A questão discursiva que se deseja cadastrar.</param>
        /// <returns>Retorna objeto com resultado da requisição.</returns>
        [HttpPost]
        [Authorize(Roles = "0,1")]
        [Route("cadastre")]
        public ActionResult<ObjetoResult<QuestaoDiscursiva>> Cadastre([FromBody] QuestaoDiscursiva questao)
        {
            try
            {
                var servico = FabricaGenerica.Crie<IServicoQuestaoDiscursiva>();
                servico.Cadastre(questao);
                return ObjetoResult<QuestaoDiscursiva>.ReturnResult("Cadastro realizado sem erros");
            }
            catch (Exception e)
            {
                return ObjetoResult<QuestaoDiscursiva>.ReturnResultError(e);
            }
        }

        /// <summary>
        /// Atualiza uma questão discursiva.
        /// </summary>
        /// <param name="objeto">O objeto para atualização.</param>
        /// <returns>Retorna objeto com resultado da requisição.</returns>
        [HttpPost]
        [Authorize(Roles = "0,1")]
        [Route("atualize")]
        public ActionResult<ObjetoResult<QuestaoDiscursiva>> Atualize([FromBody] QuestaoDiscursiva objeto)
        {
            try
            {
                var servico = FabricaGenerica.Crie<IServicoQuestaoDiscursiva>();
                servico.Atualize(objeto);
                return ObjetoResult<QuestaoDiscursiva>.ReturnResult("Atualização realizada sem erros");
            }
            catch (Exception e)
            {
                return ObjetoResult<QuestaoDiscursiva>.ReturnResultError(e);
            }
        }

        /// <summary>
        /// Exclue uma questão discursiva.
        /// </summary>
        /// <param name="codigo">Código da questão discursiva que se deseja excluir.</param>
        /// <returns>Retorna objeto com resultado da requisição.</returns>
        [HttpDelete("{codigo}")]
        [Authorize(Roles = "0,1")]

        public ActionResult<ObjetoResult<Questao<RespostaDiscursiva>>> Delete(int codigo)
        {
            try
            {
                var servico = FabricaGenerica.Crie<IServicoQuestaoDiscursiva>();
                servico.Exclua(codigo);

                return ObjetoResult<Questao<RespostaDiscursiva>>.ReturnResult("Exclusão realizada sem erros");
            }
            catch (Exception e)
            {
                return ObjetoResult<Questao<RespostaDiscursiva>>.ReturnResultError(e);
            }
        }
    }
}
