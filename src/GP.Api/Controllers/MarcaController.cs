using GP.CommandSide.Application.Commands.MarcaCommands;
using GP.QuerySide.MarcaQueries;
using GP.Api.AspNet.Models;
using GP.Api.AspNet.Models.MarcaControllerModels;
using GP.CommandSide.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Examples;
using System.Threading.Tasks;

namespace GP.Api.Controllers
{
    /// <summary>
    /// Api para manutenção de marca
    /// </summary>
    [Route("marcas")]
    [ApiController]
    public class MarcaController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IUnitOfWork _uow;

        /// <summary>
        /// Construtor do Controller
        /// </summary>
        public MarcaController(
            IMediator mediator,
            IUnitOfWork uow)
        {
            _mediator = mediator;
            _uow = uow;
        }



        #region Commands


        /// <summary>
        /// Cria uma marca
        /// </summary>
        /// <remarks> 
        /// A marca não deve possuir nomes repetidos
        /// </remarks>
        [HttpPost()]
        [ProducesResponseType(typeof(long), 200)]
        [ProducesResponseType(typeof(BaseModelResponse), 400)]
        public async Task<IActionResult> CriarMarca([FromBody] CriacaoMarcaInput request)
        {
            var cmd = new CriarMarcaCommand(request.Nome);

            var resultado = await _mediator.Send(cmd);

            await _uow.SaveEntitiesAsync();

            return Ok(resultado);
        }


        /// <summary>
        /// Renomeia uma marca já criada
        /// </summary>
        /// <remarks>
        /// Não permite que renomeie a marca para outra de mesmo nome.
        /// </remarks>
        /// <returns></returns>
        [HttpPut("{marcaId}/renomear")]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(BaseModelResponse), 400)]
        public async Task<IActionResult> AlterarNomeDaMarca(long marcaId, [FromBody]AlteracaoNomeDaMarcaInput request)
        {
            var cmd = new AlterarNomeDaMarcaCommand(marcaId, request.Nome);

            var resultado = await _mediator.Send(cmd);

            await _uow.SaveEntitiesAsync();

            return Ok();
        }


        /// <summary>
        /// Exclui uma marca
        /// </summary>
        /// <remarks>
        /// Não permite que exclua a marca se ja possuir algum modelo vinculado a ela.
        /// </remarks>
        /// <returns></returns>
        [HttpDelete("{marcaId}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(BaseModelResponse), 400)]
        public async Task<IActionResult> ExcluirMarca(long marcaId)
        {
            var cmd = new ExcluirMarcaCommand(marcaId);

            await _mediator.Send(cmd);

            await _uow.SaveEntitiesAsync();

            return Ok();
        }

        #endregion



        #region Queries


        /// <summary>
        /// Obtem marca
        /// </summary>
        [HttpGet("{MarcaId}")] 
        [ProducesResponseType(typeof(ObterMarcaQueryResponse), 200)]
        [ProducesResponseType(204)]
        public async Task<IActionResult> ObterMarca([FromRoute]ObterMarcaQueryRequest query)
        {
            var result = await _mediator.Send(query);

            return Ok(result);
        }



        /// <summary>
        /// Carrega lista de marcas de acordo com filtros
        /// </summary>
        [HttpGet("")]
        [ProducesResponseType(204)]
        [ProducesResponseType(typeof(ObterMarcasQueryResponse), 200)]
        public async Task<IActionResult> ObterMarcas([FromQuery]ObterMarcasQueryRequest query)
        {
            var result = await _mediator.Send(query);

            return Ok(result);
        }

        #endregion
    }
}