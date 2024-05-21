using BeerHubSystem.Application.Contracts;
using BeerHubSystem.Application.Features.Commands.UpdateBeerQuantity;
using BeerHubSystem.Domain.Entities;
using FluentValidation;
using FluentValidation.Results;
using Moq;

namespace BeerHubSystem.Test
{


    public class UpdateBeerQuantityCommandHandlerTests
    {
        private readonly Mock<IBeerSaleRepository> _beerSaleRepositoryMock;
        private readonly Mock<IValidator<UpdateBeerQuantityCommand>> _validatorMock;
        private readonly UpdateBeerQuantityCommandHandler _handler;

        public UpdateBeerQuantityCommandHandlerTests()
        {
            _beerSaleRepositoryMock = new Mock<IBeerSaleRepository>();
            _validatorMock = new Mock<IValidator<UpdateBeerQuantityCommand>>();
            _handler = new UpdateBeerQuantityCommandHandler(_beerSaleRepositoryMock.Object, _validatorMock.Object);
        }

        [Fact]
        public async Task Handle_ValidCommand_UpdatesQuantity()
        {
            var command = new UpdateBeerQuantityCommand
            {
                BeerSaleId = 1,
                Quantity = 20
            };

            _validatorMock.Setup(v => v.ValidateAsync(command, It.IsAny<CancellationToken>()))
                .ReturnsAsync(new ValidationResult());

            var beerSale = new BeerSale { Id = command.BeerSaleId, Quantity = 10 };
            _beerSaleRepositoryMock.Setup(r => r.GetBeerSaleByIdAsync(command.BeerSaleId))
                .ReturnsAsync(beerSale);

            await _handler.Handle(command, CancellationToken.None);

            _beerSaleRepositoryMock.Verify(r => r.UpdateBeerSaleAsync(It.Is<BeerSale>(bs => bs.Quantity == command.Quantity)), Times.Once);
        }
    }
}
