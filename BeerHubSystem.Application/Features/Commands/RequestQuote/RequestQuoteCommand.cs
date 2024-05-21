using BeerHubSystem.Application.Features.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerHubSystem.Application.Features.Commands.RequestQuote
{
    public class RequestQuoteCommand : IRequest<QuoteDto>
    {
        public int WholesalerId { get; set; }
        public List<BeerOrder> BeerOrders { get; set; }
    }
}
