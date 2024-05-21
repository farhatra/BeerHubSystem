using BeerHubSystem.Application.Features.Commands.AddBeerSale;
using FluentValidation;

namespace BeerHubSystem.Application.Exceptions
{
    public class AddBeerSaleCommandValidator : AbstractValidator<AddBeerSaleCommand>
    {
        public AddBeerSaleCommandValidator()
        {
            RuleFor(x => x.BeerId).NotEmpty().WithMessage("Beer ID is required.");
            RuleFor(x => x.WholesalerId).NotEmpty().WithMessage("Wholesaler ID is required.");
            RuleFor(x => x.Quantity).GreaterThan(0).WithMessage("Quantity must be greater than zero.");
            RuleFor(x => x.FixedPrice).GreaterThan(0).WithMessage("Fixed price must be greater than zero.");
        }
    }
}
