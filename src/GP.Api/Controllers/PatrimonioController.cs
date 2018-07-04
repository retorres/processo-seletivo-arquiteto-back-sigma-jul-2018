using GP.CommandSide.Application.Commands.PatrimonioCommands;
using GP.QuerySide.PatrimonioQueries;
using GP.Api.AspNet.Models;
using GP.Api.AspNet.Models.PatrimonioControllerModels;
using GP.CommandSide.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Examples;
using System.Threading.Tasks;

namespace GP.Api.Controllers
{
    [Route("patrimonios")]
    [ApiController]
    public class PatrimonioController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IUnitOfWork _uow;

        public PatrimonioController(
            IMediator mediator,
            IUnitOfWork uow)
        {
            _mediator = mediator;
            _uow = uow;
        }



        #region Commands
        /// <summary>
        /// Cria um patrimonio
        /// </summary>
        /// <remarks>
        /// O Retorno do metodo, trará o numero de tombamento deste patrimonio
        /// </remarks>
        [HttpPost()]
        [ProducesResponseType(typeof(long), 200)]
        [ProducesResponseType(typeof(BaseModelResponse), 400)]
        public async Task<IActionResult> CriarPatrimonio([FromBody] CriacaoPatrimonioInput request)
        {
            var cmd = new CriarPatrimonioCommand(request.ModeloId, request.Nome, request.Descricao);

            var resultado = await _mediator.Send(cmd);
            await _uow.SaveEntitiesAsync();

            return Ok(resultado);
        }

        /// <summary>
        /// Altera dados cadastrais de um patrimonio
        /// </summary>
        [HttpPut("{tomboNumero}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(BaseModelResponse), 400)]
        public async Task<IActionResult> AlterarNomeDoPatrimonio(long tomboNumero, [FromBody]AlteracaoInformacoesCadastraisDoPatrimonioInput request)
        {
            var cmd = new CriarPatrimonioCommand(tomboNumero, request.Nome, request.Descricao);

            await _mediator.Send(cmd);
            await _uow.SaveEntitiesAsync();

            return Ok();
        }

        /// <summary>
        /// Exclui um patrimonio
        /// </summary>
        [HttpDelete("{tomboNumero}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(typeof(BaseModelResponse), 400)]
        public async Task<IActionResult> ExcluirMarca(long tomboNumero)
        {
            var cmd = new ExcluirPatrimonioCommand(tomboNumero);

            await _mediator.Send(cmd);
            await _uow.SaveEntitiesAsync();

            return Ok();
        }


        #endregion



        #region Queries

        /// <summary>
        /// Obtem um patrimonio através do numero tombado
        /// </summary>
        [HttpGet("{tomboNumero}")]
        [ProducesResponseType(typeof(ObterPatrimonioQueryResponse), 200)]
        [ProducesResponseType(204)]
        public async Task<IActionResult> ObterPatrimonio([FromRoute]long tomboNumero)
        {
            var query = new ObterPatrimonioQueryRequest { TomboNumero = tomboNumero };
            var result = await _mediator.Send(query);

            return Ok(result);
        }


        /// <summary>
        /// Consulta patrimonio de acordo com filtro informado
        /// </summary>
        [HttpGet("")]
        [ProducesResponseType(204)]
        [ProducesResponseType(typeof(ObterPatrimoniosQueryResponse), 200)]
        public async Task<IActionResult> ObterPatrimonios([FromQuery]ObterPatrimoniosQueryRequest query)
        {
            var result = await _mediator.Send(query);

            return Ok(result);
        }


        #endregion


    }
}