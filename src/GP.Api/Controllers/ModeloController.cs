using GP.CommandSide.Application.Commands.ModeloCommands;
using GP.QuerySide.ModeloQueries;
using GP.Api.AspNet.Models;
using GP.Api.AspNet.Models.ModeloControllerModels;
using GP.CommandSide.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Examples;
using System.Threading.Tasks;

namespace GP.Api.Controllers
{
    /// <summary>
    /// Controller para manutençao de modelos
    /// </summary>
    [Route("modelos")]
    [ApiController]
    public class ModeloController : ControllerBase
    {

        private readonly IMediator _mediator;
        private readonly IUnitOfWork _uow;

        public ModeloController(
            IMediator mediator,
            IUnitOfWork uow)
        {
            _mediator = mediator;
            _uow = uow;
        }


        #region Commands

        /// <summary>
        /// Cria um modelo
        /// </summary>
        /// <returns>
        /// Não deve ter nome repetido de um modelo dentro da mesma marca.
        /// </returns>
        [HttpPost()]
        [ProducesResponseType(typeof(long), 200)]
        [ProducesResponseType(typeof(BaseModelResponse), 400)]
        public async Task<IActionResult> CriarModelo([FromBody] CriacaoModeloInput request)
        {
            var cmd = new CriarModeloCommand(request.MarcaId, request.Nome);

            var resultado = await _mediator.Send(cmd);

            await _uow.SaveEntitiesAsync();

            return Ok(resultado);
        }

        /// <summary>
        /// Renomeia um modelo
        /// </summary>
        /// <remarks>
        /// O Novo nome nao deve ser repetido na mesma marca.
        /// </remarks>
        [HttpPut("{modeloId}/renomear")]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(BaseModelResponse), 400)]
        public async Task<IActionResult> AlterarNomeDoModelo(long modeloId, [FromBody]AlteracaoNomeDoModeloInput request)
        {
            var cmd = new AlterarNomeDoModeloCommand(modeloId, request.Nome);

            var resultado = await _mediator.Send(cmd);

            await _uow.SaveEntitiesAsync();

            return Ok(resultado);
        }


        /// <summary>
        /// Altera a marca desse modelo
        /// </summary>
        /// <remarks>
        /// A Nova marca não deverá ter um modelo de mesmo nome.
        /// </remarks>
        [HttpPut("{modeloId}/alterar-marca")]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(BaseModelResponse), 400)]
        public async Task<IActionResult> AlterarMarcaDoModelo(long modeloId, [FromBody]AlteracaoMarcaDoModeloInput request)
        {
            var cmd = new AlterarMarcaDoModeloCommand(modeloId, request.MarcaId);

            await _mediator.Send(cmd);

            await _uow.SaveEntitiesAsync();

            return Ok();
        }

        /// <summary>
        /// Exclui um modelo
        /// </summary>
        /// <param name="modeloId"></param>
        /// <returns></returns>
        [HttpDelete("{modeloId}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(typeof(BaseModelResponse), 400)]
        public async Task<IActionResult> ExcluirModelo(long modeloId)
        {
            var cmd = new ExcluirModeloCommand(modeloId);

            await _mediator.Send(cmd);
            await _uow.SaveEntitiesAsync();

            return Ok();
        }

        #endregion


        #region Queries

        /// <summary>
        /// Obtem um modelo
        /// </summary>
        [HttpGet("{ModeloId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(typeof(ObterModeloQueryResponse), 200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(typeof(BaseModelResponse), 400)]
        public async Task<IActionResult> ObterModelo([FromRoute]ObterModeloQueryRequest query)
        {
            var result = await _mediator.Send(query);

            return Ok(result);
        }


        /// <summary>
        /// Carrega lista de modelos de acordo com filtros
        /// </summary>
        [HttpGet("")]
        [ProducesResponseType(204)]
        [ProducesResponseType(typeof(ObterModelosQueryResponse), 200)]
        public async Task<IActionResult> ObterModelos([FromQuery]ObterModelosQueryRequest query)
        {
            var result = await _mediator.Send(query);

            return Ok(result);
        }


        #endregion
    }
}