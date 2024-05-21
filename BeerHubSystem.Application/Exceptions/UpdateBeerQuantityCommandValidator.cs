using BeerHubSystem.Application.Features.Commands.UpdateBeerQuantity;
using FluentValidation;

namespace BeerHubSystem.Application.Exceptions
{
    public class UpdateBeerQuantityCommandValidator : AbstractValidator<UpdateBeerQuantityCommand>
    {
        public UpdateBeerQuantityCommandValidator()
        {
            RuleFor(x => x.BeerSaleId).NotEmpty().WithMessage("Beer sale ID is required.");
            RuleFor(x => x.Quantity).GreaterThanOrEqualTo(0).WithMessage("Quantity cannot be negative.");
        }
    }
}
