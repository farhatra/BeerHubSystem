using BeerHubSystem.Application.Features.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerHubSystem.Application.Features.Queries.GetBeersByBrewery
{
    public class GetBeersByBreweryQuery : IRequest<IEnumerable<BeerDto>>
    {
        public int BreweryId { get; set; }
    }
}
