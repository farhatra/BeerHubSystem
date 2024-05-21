using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerHubSystem.Application.Features.Commands.DeleteBeer
{
    public class DeleteBeerCommand : IRequest
    {
        public int BeerId { get; set; }
    }
}
