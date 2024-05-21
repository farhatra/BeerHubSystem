using BeerHubSystem.Application.Features.Commands.CreateBeer;
using FluentValidation;

namespace BeerHubSystem.Application.Exceptions
{
    public class CreateBeerCommandValidator : AbstractValidator<CreateBeerCommand>
    {
        public CreateBeerCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Beer name is required.");
            RuleFor(x => x.AlcoholPercentage).GreaterThan(0).WithMessage("Alcohol percentage must be greater than zero.");
            RuleFor(x => x.Price).GreaterThan(0).WithMessage("Price must be greater than zero.");
            RuleFor(x => x.BreweryId).NotEmpty().WithMessage("Brewery ID is required.");
        }
    }
}
