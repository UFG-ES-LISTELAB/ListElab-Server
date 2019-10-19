using System;
using listelab_contrato.RequestObject;
using listelab_dominio;
using listelab_dominio.Conceitos.Filtro;
using listelab_dominio.InterfaceDeServico;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace listelab_contrato.Controllers
{
    /// <summary>
    /// Controlador Controaldor com rotinas padrão da api.
    /// </summary>
    /// <typeparam name="T">Objeto a ser trafegado.</typeparam>
    /// <typeparam name="S">Interface de serviço do objeto.</typeparam>
    /// <typeparam name="F">Filtro para pesquisa</typeparam>
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("SiteCorsPolicy")]
    public class ControladorPadrao<T, S, F> : ControllerBase where S : IServicoPadrao<T> where F : Filtro
    {
        /// <summary>
        /// Retorna o serviço.
        /// </summary>
        /// <returns>A instância de serviço.</returns>
        protected S Servico()
        {
            return FabricaGenerica.Crie<S>();
        }

        /// <summary>
        /// Lista todas as questões discursivas cadastradas.
        /// </summary>
        /// <returns>Retorna um objeto de sucesso ou falha e a lista desejada, caso sucesso.</returns>
        [HttpGet]
        [Authorize]
        [EnableCors("SiteCorsPolicy")]
        public ActionResult<DtoResultado<T>> ConsulteLista()
        {
            try
            {
                var questao = Servico().ConsulteLista();

                return DtoResultado<T>.ObtenhaResultado(questao, "Consulta realizada sem erros");
            }
            catch (Exception e)
            {
                return DtoResultado<T>.ObtenhaResultado(e);
            }
        }

        /// <summary>
        /// Retorna a questão discursiva do código informado.
        /// </summary>
        /// <param name="filtro">O filtro de questão.</param>
        /// <returns>Retorna objeto de resposta de sucesso ou falha, contendo o objeto desejado, caso sucesso.</returns>
        [HttpPost]
        [Route("consulte")]
        [Authorize]
        public ActionResult<DtoResultado<T>> ConsulteComFiltro([FromBody] F filtro)
        {
            try
            {
                var questao = Servico().Consulte(filtro);

                return DtoResultado<T>.ObtenhaResultado(questao, "Consulta realizada sem erros");
            }
            catch (Exception e)
            {
                return DtoResultado<T>.ObtenhaResultado(e);
            }
        }

        /// <summary>
        /// Cadastra uma questão discursiva.
        /// </summary>
        /// <param name="questao">A questão discursiva que se deseja cadastrar.</param>
        /// <returns>Retorna objeto com resultado da requisição.</returns>
        [HttpPost]
        [Route("cadastre")]
        [Authorize(Roles = "Admin,Professor")]
        public ActionResult<DtoResultado<T>> Cadastre([FromBody] T questao)
        {
            try
            {
                Servico().Cadastre(questao);
                return DtoResultado<T>.ObtenhaResultado("Cadastro realizado sem erros");
            }
            catch (Exception e)
            {
                return DtoResultado<T>.ObtenhaResultado(e);
            }
        }

        /// <summary>
        /// Atualiza uma questão discursiva.
        /// </summary>
        /// <param name="objeto">O objeto para atualização.</param>
        /// <returns>Retorna objeto com resultado da requisição.</returns>
        [HttpPost]
        [Route("atualize")]
        [Authorize(Roles = "Admin,Professor")]
        public ActionResult<DtoResultado<T>> Atualize([FromBody] T objeto)
        {
            try
            {
                Servico().Atualize(objeto);
                return DtoResultado<T>.ObtenhaResultado("Atualização realizada sem erros");
            }
            catch (Exception e)
            {
                return DtoResultado<T>.ObtenhaResultado(e);
            }
        }

        /// <summary>
        /// Exclue uma questão discursiva.
        /// </summary>
        /// <param name="id">Id da questão discursiva que se deseja excluir.</param>
        /// <returns>Retorna objeto com resultado da requisição.</returns>
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin,Professor")]
        public ActionResult<DtoResultado<T>> Delete(string id)
        {
            try
            {
                Servico().Exclua(id);

                return DtoResultado<T>.ObtenhaResultado("Exclusão realizada sem erros");
            }
            catch (Exception e)
            {
                return DtoResultado<T>.ObtenhaResultado(e);
            }
        }

    }
}
