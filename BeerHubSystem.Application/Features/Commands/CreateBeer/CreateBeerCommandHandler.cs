using AutoMapper;
using BeerHubSystem.Application.Contracts;
using BeerHubSystem.Domain.Entities;
using FluentValidation;
using MediatR;

namespace BeerHubSystem.Application.Features.Commands.CreateBeer
{
    public class CreateBeerCommandHandler : IRequestHandler<CreateBeerCommand>
    {
        private readonly IBeerRepository _beerRepository;
        private readonly IMapper _mapper;
        private readonly IValidator<CreateBeerCommand> _validator;

        public CreateBeerCommandHandler(IBeerRepository beerRepository, IMapper mapper, IValidator<CreateBeerCommand> validator)
        {
            _beerRepository = beerRepository;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task<Unit> Handle(CreateBeerCommand request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors.FirstOrDefault()?.ErrorMessage);
            }

            var beer = _mapper.Map<Beer>(request);
            await _beerRepository.AddBeerAsync(beer);
            return Unit.Value;
        }
    }

}
