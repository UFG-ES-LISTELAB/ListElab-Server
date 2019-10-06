using System;
using listelab_contrato.RequestObject;
using listelab_dominio;
using listelab_dominio.Conceitos;
using listelab_dominio.Conceitos.Questao;
using listelab_dominio.Conceitos.Resposta;
using listelab_dominio.InterfaceDeServico;
using Microsoft.AspNetCore.Mvc;

namespace listelab_contrato.Controllers
{
    /// <summary>
    /// Api para o conceito de questão discursiva.
    /// </summary>
    [Route("api/questao_discursiva")]
    [ApiController]
    public class QuestaoDiscursivaController : ControladorPadrao<IServicoQuestaoDiscursiva>
    {
        /// <summary>
        /// Lista todas as questões discursivas cadastradas.
        /// </summary>
        /// <returns>Retorna um objeto de sucesso ou falha e a lista desejada, caso sucesso.</returns>
        [HttpGet]
        public ActionResult<DtoResultado<Questao<Discursiva>>> Get()
        {
            try
            {
                var questao = Servico.ConsulteLista();

                return DtoResultado<Questao<Discursiva>>.ObtenhaResultado(questao, "Consulta realizada sem erros");
            }
            catch (Exception e)
            {
                return DtoResultado<Questao<Discursiva>>.ObtenhaResultado(e);
            }
        }

        /// <summary>
        /// Retorna a questão discursiva do código informado.
        /// </summary>
        /// <param name="codigo">O código da questão discursiva que se deseja buscar.</param>
        /// <returns>Retorna objeto de resposta de sucesso ou falha, contendo o objeto desejado, caso sucesso.</returns>
        [HttpGet("{codigo}")]
        public ActionResult<DtoResultado<Questao<Discursiva>>> Get(int codigo)
        {
            try
            {
                var questao = Servico.Consulte(codigo);

                return DtoResultado<Questao<Discursiva>>.ObtenhaResultado(questao, "Consulta realizada sem erros");
            }
            catch(Exception e)
            {
                return DtoResultado<Questao<Discursiva>>.ObtenhaResultado(e);
            }
        }

        /// <summary>
        /// Cadastra uma questão discursiva.
        /// </summary>
        /// <param name="questao">A questão discursiva que se deseja cadastrar.</param>
        /// <returns>Retorna objeto com resultado da requisição.</returns>
        [HttpPost]
        [Route("cadastre")]
        public ActionResult<DtoResultado<Questao<Discursiva>>> Cadastre([FromBody] Questao<Discursiva> questao)
        {
            try
            {
                Servico.Cadastre(questao);
                return DtoResultado<Questao<Discursiva>>.ObtenhaResultado("Cadastro realizado sem erros");
            }
            catch (Exception e)
            {
                return DtoResultado<Questao<Discursiva>>.ObtenhaResultado(e);
            }
        }

        /// <summary>
        /// Atualiza uma questão discursiva.
        /// </summary>
        /// <param name="objeto">O objeto para atualização.</param>
        /// <returns>Retorna objeto com resultado da requisição.</returns>
        [HttpPost]
        [Route("atualize")]
        public ActionResult<DtoResultado<Questao<Discursiva>>> Atualize([FromBody] Questao<Discursiva> objeto)
        {
            try
            {
                Servico.Atualize(objeto);
                return DtoResultado<Questao<Discursiva>>.ObtenhaResultado("Atualização realizada sem erros");
            }
            catch (Exception e)
            {
                return DtoResultado<Questao<Discursiva>>.ObtenhaResultado(e);
            }
        }

        /// <summary>
        /// Exclue uma questão discursiva.
        /// </summary>
        /// <param name="codigo">Código da questão discursiva que se deseja excluir.</param>
        /// <returns>Retorna objeto com resultado da requisição.</returns>
        [HttpDelete("{codigo}")]
        public ActionResult<DtoResultado<Questao<Discursiva>>> Delete(int codigo)
        {
            try
            {
                var servico = FabricaGenerica.Crie<IServicoQuestaoDiscursiva>();
                servico.Exclua(codigo);

                return DtoResultado<Questao<Discursiva>>.ObtenhaResultado("Exclusão realizada sem erros");
            }
            catch (Exception e)
            {
                return DtoResultado<Questao<Discursiva>>.ObtenhaResultado(e);
            }
        }
    }
}
