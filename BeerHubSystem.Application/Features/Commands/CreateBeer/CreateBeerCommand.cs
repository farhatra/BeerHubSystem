using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerHubSystem.Application.Features.Commands.CreateBeer
{
    public class CreateBeerCommand : IRequest
    {
        public string Name { get; set; } = string.Empty;
        public double AlcoholPercentage { get; set; }
        public decimal Price { get; set; }
        public int BreweryId { get; set; }
    }
}
