using System;
using System.Threading.Tasks;
using Easify.Template.Core.Handlers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Easify.Template.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class SamplesController : Controller
    {
        private readonly IMediator _mediator;

        public SamplesController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _mediator.Send(new SampleRequest());
            if (result.HasError)
                return BadRequest(result.ErrorMessage);

            return Ok(result.Samples);
        }
    }
}
