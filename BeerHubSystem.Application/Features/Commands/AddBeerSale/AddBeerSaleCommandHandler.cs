using AutoMapper;
using BeerHubSystem.Application.Contracts;
using BeerHubSystem.Application.Exceptions;
using BeerHubSystem.Domain.Entities;
using FluentValidation;
using MediatR;


namespace BeerHubSystem.Application.Features.Commands.AddBeerSale
{
    public class AddBeerSaleCommandHandler : IRequestHandler<AddBeerSaleCommand>
    {
        private readonly IBeerSaleRepository _beerSaleRepository;
        private readonly IBeerRepository _beerRepository;
        private readonly IWholesalerRepository _wholesalerRepository;
        private readonly IMapper _mapper;
        private readonly IValidator<AddBeerSaleCommand> _validator;

        public AddBeerSaleCommandHandler(IBeerSaleRepository beerSaleRepository, IBeerRepository beerRepository, IWholesalerRepository wholesalerRepository, IMapper mapper, IValidator<AddBeerSaleCommand> validator)
        {
            _beerSaleRepository = beerSaleRepository;
            _beerRepository = beerRepository;
            _wholesalerRepository = wholesalerRepository;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task<Unit> Handle(AddBeerSaleCommand request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
            {
                throw new FluentValidation.ValidationException(validationResult.Errors.FirstOrDefault()?.ErrorMessage);
            }

            var beer = await _beerRepository.GetBeerByIdAsync(request.BeerId);
            if (beer == null)
            {
                throw new NotFoundException($"Beer with ID {request.BeerId} not found");
            }

            var wholesaler = await _wholesalerRepository.GetWholesalerByIdAsync(request.WholesalerId);
            if (wholesaler == null)
            {
                throw new NotFoundException($"Wholesaler with ID {request.WholesalerId} not found");
            }

            var beerSale = _mapper.Map<BeerSale>(request);
            await _beerSaleRepository.AddBeerSaleAsync(beerSale);
            return Unit.Value;
        }
    }

}
