using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProdX.Application.Commands.Requests;
using ProdX.Application.Interfaces;
using ProdX.Application.Queries.Requests;
using ProdX.Domain.Entities;

namespace ProdX.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetAllProductQueryRequest request)
            => Ok(await _mediator.Send(request));


        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id) //Id degerini Guid tipte tuttugum icin burda direkt parametre ile aldim.
        {
            var result = await _mediator.Send(new GetByIdProductQueryRequest { Id = id });

            if (result == null)
                return NotFound();

            return Ok(result);    
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateProductCommandRequest request)
            => Ok(await _mediator.Send(request));


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _mediator.Send(new DeleteProductCommandRequest { Id = id });

            if (result == null)
                return NotFound();

            return Ok(result);
        }


    }
}
