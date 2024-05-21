using BeerHubSystem.Application.Contracts;
using BeerHubSystem.Application.Exceptions;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerHubSystem.Application.Features.Commands.UpdateBeerQuantity
{
    public class UpdateBeerQuantityCommandHandler : IRequestHandler<UpdateBeerQuantityCommand>
    {
        private readonly IBeerSaleRepository _beerSaleRepository;
        private readonly IValidator<UpdateBeerQuantityCommand> _validator;

        public UpdateBeerQuantityCommandHandler(IBeerSaleRepository beerSaleRepository, IValidator<UpdateBeerQuantityCommand> validator)
        {
            _beerSaleRepository = beerSaleRepository;
            _validator = validator;
        }

        public async Task<Unit> Handle(UpdateBeerQuantityCommand request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
            {
                throw new FluentValidation.ValidationException(validationResult.Errors.FirstOrDefault()?.ErrorMessage);
            }

            var beerSale = await _beerSaleRepository.GetBeerSaleByIdAsync(request.BeerSaleId);
            if (beerSale == null)
            {
                throw new NotFoundException($"Beer sale with ID {request.BeerSaleId} not found");
            }

            beerSale.Quantity = request.Quantity;
            await _beerSaleRepository.UpdateBeerSaleAsync(beerSale);

            return Unit.Value;
        }
    }

}
