using BeerHubSystem.Application.Contracts;
using BeerHubSystem.Application.Exceptions;
using BeerHubSystem.Application.Features.DTOs;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerHubSystem.Application.Features.Commands.RequestQuote
{
    public class RequestQuoteCommandHandler : IRequestHandler<RequestQuoteCommand, QuoteDto>
    {
        private readonly IBeerSaleRepository _beerSaleRepository;
        private readonly IWholesalerRepository _wholesalerRepository;
        private readonly IValidator<RequestQuoteCommand> _validator;

        public RequestQuoteCommandHandler(IBeerSaleRepository beerSaleRepository, IWholesalerRepository wholesalerRepository, IValidator<RequestQuoteCommand> validator)
        {
            _beerSaleRepository = beerSaleRepository;
            _wholesalerRepository = wholesalerRepository;
            _validator = validator;
        }

        public async Task<QuoteDto> Handle(RequestQuoteCommand request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
            {
                throw new FluentValidation.ValidationException(validationResult.Errors.FirstOrDefault()?.ErrorMessage);
            }

            var wholesaler = await _wholesalerRepository.GetWholesalerByIdAsync(request.WholesalerId);
            if (wholesaler == null)
            {
                throw new NotFoundException($"Wholesaler with ID {request.WholesalerId} not found");
            }

            var beerSales = await _beerSaleRepository.GetAllBeerSalesAsync();
            var wholesalerBeerSales = beerSales.Where(bs => bs.WholesalerId == request.WholesalerId).ToList();

            if (!wholesalerBeerSales.Any())
            {
                throw new Exception($"Wholesaler with ID {request.WholesalerId} does not sell any beer");
            }

            if (request.BeerOrders.GroupBy(o => o.BeerId).Any(g => g.Count() > 1))
            {
                throw new Exception("Duplicate beer orders are not allowed");
            }

            decimal totalPrice = 0;
            foreach (var order in request.BeerOrders)
            {
                var beerSale = wholesalerBeerSales.FirstOrDefault(bs => bs.BeerId == order.BeerId);
                if (beerSale == null)
                {
                    throw new Exception($"Beer with ID {order.BeerId} is not sold by the wholesaler");
                }
                if (beerSale.Quantity < order.Quantity)
                {
                    throw new Exception($"Insufficient stock for Beer ID {order.BeerId}");
                }

                totalPrice += beerSale.FixedPrice * order.Quantity;
            }

            int totalQuantity = request.BeerOrders.Sum(o => o.Quantity);
            if (totalQuantity > 20)
            {
                totalPrice *= 0.8m; // 20% discount
            }
            else if (totalQuantity > 10)
            {
                totalPrice *= 0.9m; // 10% discount
            }

            var quoteDto = new QuoteDto
            {
                TotalPrice = totalPrice,
                Summary = $"Order from Wholesaler {wholesaler.Name}, Total Price: {totalPrice}"
            };

            return quoteDto;
        }
    }
}
