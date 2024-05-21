using BeerHubSystem.Application.Exceptions;
using BeerHubSystem.Application.Features.Commands.CreateBeer;
using FluentValidation.TestHelper;
namespace BeerHubSystem.Test
{


    public class CreateBeerCommandValidatorTests
    {
        private readonly CreateBeerCommandValidator _validator;

        public CreateBeerCommandValidatorTests()
        {
            _validator = new CreateBeerCommandValidator();
        }

        [Fact]
        public void Should_Have_Error_When_Name_Is_Empty()
        {
            var command = new CreateBeerCommand { Name = string.Empty };
            var result = _validator.TestValidate(command);
            result.ShouldHaveValidationErrorFor(c => c.Name);
        }

        [Fact]
        public void Should_Not_Have_Error_When_Name_Is_Specified()
        {
            var command = new CreateBeerCommand { Name = "Test Beer" };
            var result = _validator.TestValidate(command);
            result.ShouldNotHaveValidationErrorFor(c => c.Name);
        }
    }
}
