using Application.Features.Prediccion.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrediccionController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PrediccionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{dia}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ClimaDTO> Get(int dia)
        {
            return await this._mediator.Send(new GetPrediccionByDiaQuery(dia));
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IList<PeriodoDTO>> Get()
        {
            return await this._mediator.Send(new GetPrediccionesQuery());
        }
    }
}
