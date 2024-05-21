using BeerHubSystem.Application.Features.Commands.AddBeerSale;
using BeerHubSystem.Application.Features.Commands.CreateBeer;
using BeerHubSystem.Application.Features.Commands.DeleteBeer;
using BeerHubSystem.Application.Features.Commands.RequestQuote;
using BeerHubSystem.Application.Features.Commands.UpdateBeerQuantity;
using BeerHubSystem.Application.Features.DTOs;
using BeerHubSystem.Application.Features.Queries.GetBeersByBrewery;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BeerHubSystem.API.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class BeerController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BeerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/beer/brewery/{breweryId}
        [HttpGet("brewery/{breweryId}")]
        public async Task<ActionResult<IEnumerable<BeerDto>>> GetBeersByBrewery(int breweryId)
        {
            var query = new GetBeersByBreweryQuery { BreweryId = breweryId };
            var beers = await _mediator.Send(query);
            return Ok(beers);
        }

        // POST: api/beer
        [HttpPost]
        public async Task<ActionResult> CreateBeer([FromBody] CreateBeerCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        // POST: api/beer/sale
        [HttpPost("sale")]
        public async Task<ActionResult> AddBeerSale([FromBody] AddBeerSaleCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        // PUT: api/beer/sale/{id}/quantity
        [HttpPut("sale/{id}/quantity")]
        public async Task<ActionResult> UpdateBeerQuantity(int id, [FromBody] UpdateBeerQuantityCommand command)
        {
            if (id != command.BeerSaleId)
            {
                return BadRequest("Beer sale ID mismatch");
            }
            await _mediator.Send(command);
            return Ok();
        }

        // DELETE: api/beer/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteBeer(int id)
        {
            var command = new DeleteBeerCommand { BeerId = id };
            await _mediator.Send(command);
            return Ok();
        }

        // POST: api/beer/quote
        [HttpPost("quote")]
        public async Task<ActionResult<QuoteDto>> RequestQuote([FromBody] RequestQuoteCommand command)
        {
            var quote = await _mediator.Send(command);
            return Ok(quote);
        }
    }
}

