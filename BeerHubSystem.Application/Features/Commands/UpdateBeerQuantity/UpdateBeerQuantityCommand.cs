using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerHubSystem.Application.Features.Commands.UpdateBeerQuantity
{
    public class UpdateBeerQuantityCommand : IRequest
    {
        public int BeerSaleId { get; set; }
        public int Quantity { get; set; }
    }
}
