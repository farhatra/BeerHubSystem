using BeerHubSystem.Application.Features.Commands.RequestQuote;
using FluentValidation;

namespace BeerHubSystem.Application.Exceptions
{
    public class RequestQuoteCommandValidator : AbstractValidator<RequestQuoteCommand>
    {
        public RequestQuoteCommandValidator()
        {
            RuleFor(x => x.WholesalerId).GreaterThan(0).WithMessage("Wholesaler ID must be greater than zero.");
            RuleFor(x => x.BeerOrders).NotEmpty().WithMessage("Beer orders cannot be empty.");
            RuleForEach(x => x.BeerOrders).ChildRules(order =>
            {
                order.RuleFor(o => o.BeerId).GreaterThan(0).WithMessage("Beer ID must be greater than zero.");
                order.RuleFor(o => o.Quantity).GreaterThan(0).WithMessage("Quantity must be greater than zero.");
            });
        }
    }

}
