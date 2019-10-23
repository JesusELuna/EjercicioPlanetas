using Application.Features.Clima.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClimaController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ClimaController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        [Route("api/[controller]/{dia:int}")]
        public async Task<ClimaDTO> Get(int dia)
        {
            return await this._mediator.Send(new GetClimaByDiaQuery(dia));
        }
    }
}
