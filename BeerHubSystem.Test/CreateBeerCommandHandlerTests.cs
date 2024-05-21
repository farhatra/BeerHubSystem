using AutoMapper;
using BeerHubSystem.Application.Contracts;
using BeerHubSystem.Application.Features.Commands.CreateBeer;
using BeerHubSystem.Domain.Entities;
using FluentValidation;
using FluentValidation.Results;
using Moq;

namespace BeerHubSystem.Test
{

    public class CreateBeerCommandHandlerTests
    {
        private readonly Mock<IBeerRepository> _beerRepositoryMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly Mock<IValidator<CreateBeerCommand>> _validatorMock;
        private readonly CreateBeerCommandHandler _handler;

        public CreateBeerCommandHandlerTests()
        {
            _beerRepositoryMock = new Mock<IBeerRepository>();
            _mapperMock = new Mock<IMapper>();
            _validatorMock = new Mock<IValidator<CreateBeerCommand>>();
            _handler = new CreateBeerCommandHandler(_beerRepositoryMock.Object, _mapperMock.Object, _validatorMock.Object);
        }

        [Fact]
        public async Task Handle_ValidCommand_AddsBeer()
        {
            var command = new CreateBeerCommand
            {
                Name = "New Beer",
                AlcoholPercentage = 5.0,
                Price = 10.0m,
                BreweryId = 1
            };

            _validatorMock.Setup(v => v.ValidateAsync(command, It.IsAny<CancellationToken>()))
                .ReturnsAsync(new ValidationResult());

            _mapperMock.Setup(m => m.Map<Beer>(command))
                .Returns(new Beer());

            await _handler.Handle(command, CancellationToken.None);

            _beerRepositoryMock.Verify(r => r.AddBeerAsync(It.IsAny<Beer>()), Times.Once);
        }
    }
}
