using Application.Features.Prediction.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PredictionController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PredictionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Obtiene el clima del día indicado
        /// </summary>
        [HttpGet("{day}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<WeatherDTO> Get(int day)
        {
            return await this._mediator.Send(new GetPredictionByDayQuery(day));
        }

        /// <summary>
        /// Obtiene el clima del día indicado
        /// </summary>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IList<PredictionDTO>> GetPredictions()
        {
            return await this._mediator.Send(new GetPredictionsQuery());
        }
    }
}
