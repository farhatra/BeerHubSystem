using BeerHubSystem.Application.Exceptions;
using BeerHubSystem.Application.Features.Commands.AddBeerSale;
using FluentValidation.TestHelper;


namespace BeerHubSystem.Test
{

    public class AddBeerSaleCommandValidatorTests
    {
        private readonly AddBeerSaleCommandValidator _validator;

        public AddBeerSaleCommandValidatorTests()
        {
            _validator = new AddBeerSaleCommandValidator();
        }

        [Fact]
        public void Should_Have_Error_When_Quantity_Is_Zero()
        {
            var command = new AddBeerSaleCommand { Quantity = 0 };
            var result = _validator.TestValidate(command);
            result.ShouldHaveValidationErrorFor(c => c.Quantity);
        }

        [Fact]
        public void Should_Not_Have_Error_When_Quantity_Is_Greater_Than_Zero()
        {
            var command = new AddBeerSaleCommand { Quantity = 5 };
            var result = _validator.TestValidate(command);
            result.ShouldNotHaveValidationErrorFor(c => c.Quantity);
        }
    }
}
