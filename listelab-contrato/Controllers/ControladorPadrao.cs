using ListElab.Dominio;
using ListElab.Dominio.Dtos;
using ListElab.Dominio.InterfaceDeServico;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace ListElab.Contrato.Controllers
{
    /// <summary>
    /// Controller padrão.
    /// </summary>
    /// <typeparam name="TObjeto">Objeto a ser trafegado.</typeparam>
    /// <typeparam name="S">Serviço do conceito.</typeparam>
    /// <typeparam name="TDto">Dto a ser trafegado.</typeparam>
    [Route("api/[controller]")]
    [EnableCors("SiteCorsPolicy")]
    [ApiController]
    public class ControladorPadrao<TObjeto, S, TDto> : ControllerBase where S : IServicoCrudCompleto<TObjeto, TDto>
    {
        private S servico;

        /// <summary>
        /// Retorna o serviço.
        /// </summary>
        /// <returns>A instância de serviço.</returns>
        protected S Servico()
        {
            return servico != null ? servico : (servico = FabricaGenerica.Crie<S>());
        }

        /// <summary>
        /// Lista todas os registros cadastrados.
        /// </summary>
        /// <returns>Retorna um objeto de sucesso ou falha e os registros cadastrados, caso sucesso.</returns>
        [HttpGet]
        [Authorize]
        public ActionResult<DtoResultado<TDto>> ConsulteLista()
        {
            return ExecuteAcaoAutorizada(() =>
            {
                var resultado = Servico().ConsulteLista();
                return DtoResultado<TDto>.ObtenhaResultado(resultado, "Consulta realizada sem erros");
            });
        }

        /// <summary>
        /// Consulta um registro passando o identificador único.
        /// </summary>
        /// <returns>Retorna um objeto de sucesso ou falha com o registro encontrado, caso sucesso.</returns>
        [Authorize]
        [HttpGet("{id}")]
        public ActionResult<DtoResultado<TDto>> ConsultePorId(string id)
        {
            return ExecuteAcaoAutorizada(() =>
            {
                var resultado = Servico().Consulte(id);
                return DtoResultado<TDto>.ObtenhaResultado(resultado, "Consulta realizada sem erros");
            });
        }

        /// <summary>
        /// Cadastra um registro novo no banco.
        /// </summary>
        /// <param name="objeto">O registro a ser cadastrado..</param>
        /// <returns>Retorna objeto com resultado da requisição.</returns>
        [HttpPost]
        [Authorize(Roles = "Admin,Professor")]
        public ActionResult<DtoResultado<TDto>> Cadastre([FromBody] TDto objeto)
        {
            return ExecuteAcaoAutorizada(() =>
            {
                var resultado = Servico().Cadastre(objeto);
                return DtoResultado<TDto>.ObtenhaResultado(resultado, "Cadastro realizado sem erros");
            });
        }

        /// <summary>
        /// Atualiza um registro existente no banco.
        /// </summary>
        /// <param name="objeto">O registro com seus novos dados e o id para identificação.</param>
        /// <returns>Retorna objeto com resultado da requisição.</returns>
        [HttpPut]
        [Authorize(Roles = "Admin,Professor")]
        public ActionResult<DtoResultado<TDto>> Atualize([FromBody] TDto objeto)
        {
            return ExecuteAcaoAutorizada(() =>
            {
                var resultado = Servico().Atualize(objeto);

                return DtoResultado<TDto>.ObtenhaResultado(resultado, "Atualização realizada sem erros");
            });
        }

        /// <summary>
        /// Exclue um registro no banco.
        /// </summary>
        /// <param name="id">Id do registro que será excluído.</param>
        /// <returns>Retorna objeto com resultado da requisição.</returns>
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin,Professor")]
        public ActionResult<DtoResultado<TDto>> Delete(string id)
        {
            return ExecuteAcaoAutorizada(() =>
            {
                Servico().Exclua(id);
                return DtoResultado<TDto>.ObtenhaResultado("Exclusão realizada sem erros");
            });
        }

        /// <summary>
        /// Executa o método para a requisição da api e retorna o resultado da requisição.
        /// </summary>
        /// <param name="sucesso">Método quando a requisição aconteceu com sucesso.</param>
        /// <returns></returns>
        protected ActionResult<DtoResultado<TDto>> ExecuteAcaoAutorizada(Func<ActionResult<DtoResultado<TDto>>> sucesso)
        {
            try
            {
                return sucesso();
            }
            catch (Exception e)
            {
                var erros = Servico().Erros;
                return erros != null && erros.Any() ? erros.FirstOrDefault() : DtoResultado<TDto>.ObtenhaResultado(e);
            }
        }
    }
}
