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
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("SiteCorsPolicy")]
    public class ControladorPadrao<T, S> : ControllerBase where S : IServicoPadrao<T>
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
        /// Lista todas os registros cadastrados.
        /// </summary>
        /// <returns>Retorna um objeto de sucesso ou falha e os registros cadastrados, caso sucesso.</returns>
        [HttpGet]
        [Authorize]
        public ActionResult<DtoResultado<T>> ConsulteLista()
        {
            return ExecuteAcaoAutorizada(() =>
            {
                var resultado = Servico().ConsulteLista();
                return DtoResultado<T>.ObtenhaResultado(resultado, "Consulta realizada sem erros");
            });
        }

        /// <summary>
        /// Consulta um registro passando o identificador único.
        /// </summary>
        /// <returns>Retorna um objeto de sucesso ou falha com o registro encontrado, caso sucesso.</returns>
        [Authorize]
        [HttpGet("{id}")]
        public ActionResult<DtoResultado<T>> ConsultePorId(string id)
        {
            return ExecuteAcaoAutorizada(() =>
            {
                var resultado = Servico().Consulte(id);
                return DtoResultado<T>.ObtenhaResultado(resultado, "Consulta realizada sem erros");
            });
        }

        /// <summary>
        /// Cadastra um registro novo no banco.
        /// </summary>
        /// <param name="objeto">O registro a ser cadastrado..</param>
        /// <returns>Retorna objeto com resultado da requisição.</returns>
        [HttpPost]
        [Authorize(Roles = "Admin,Professor")]
        public ActionResult<DtoResultado<T>> Cadastre([FromBody] T objeto)
        {
            return ExecuteAcaoAutorizada(() =>
            {
                var resultado = Servico().Cadastre(objeto);
                return DtoResultado<T>.ObtenhaResultado(resultado, "Cadastro realizado sem erros");
            });
        }

        /// <summary>
        /// Atualiza um registro existente no banco.
        /// </summary>
        /// <param name="objeto">O registro com seus novos dados e o id para identificação.</param>
        /// <returns>Retorna objeto com resultado da requisição.</returns>
        [HttpPut]
        [Authorize(Roles = "Admin,Professor")]
        public ActionResult<DtoResultado<T>> Atualize([FromBody] T objeto)
        {
            return ExecuteAcaoAutorizada(() =>
            {
                var resultado = Servico().Atualize(objeto);

                return DtoResultado<T>.ObtenhaResultado(resultado, "Atualização realizada sem erros");
            });
        }

        /// <summary>
        /// Exclue um registro no banco.
        /// </summary>
        /// <param name="id">Id do registro que será excluído.</param>
        /// <returns>Retorna objeto com resultado da requisição.</returns>
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin,Professor")]
        public ActionResult<DtoResultado<T>> Delete(string id)
        {
            return ExecuteAcaoAutorizada(() =>
            {
                Servico().Exclua(id);
                return DtoResultado<T>.ObtenhaResultado("Exclusão realizada sem erros");
            });
        }

        /// <summary>
        /// Executa o método para a requisição da api e retorna o resultado da requisição.
        /// </summary>
        /// <param name="sucesso">Método quando a requisição aconteceu com sucesso.</param>
        /// <returns></returns>
        protected ActionResult<DtoResultado<T>> ExecuteAcaoAutorizada(Func<ActionResult<DtoResultado<T>>> sucesso)
        {
            try
            {
                return sucesso();
            } 
            catch(Exception e)
            {
                return DtoResultado<T>.ObtenhaResultado(e);
            }
        }
    }
}
