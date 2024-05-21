using AutoMapper;
using BeerHubSystem.Application.Contracts;
using BeerHubSystem.Application.Features.Commands.AddBeerSale;
using BeerHubSystem.Domain.Entities;
using FluentValidation;
using FluentValidation.Results;
using Moq;

namespace BeerHubSystem.Test
{


    public class AddBeerSaleCommandHandlerTests
    {
        private readonly Mock<IBeerSaleRepository> _beerSaleRepositoryMock;
        private readonly Mock<IBeerRepository> _beerRepositoryMock;
        private readonly Mock<IWholesalerRepository> _wholesalerRepositoryMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly Mock<IValidator<AddBeerSaleCommand>> _validatorMock;
        private readonly AddBeerSaleCommandHandler _handler;

        public AddBeerSaleCommandHandlerTests()
        {
            _beerSaleRepositoryMock = new Mock<IBeerSaleRepository>();
            _beerRepositoryMock = new Mock<IBeerRepository>();
            _wholesalerRepositoryMock = new Mock<IWholesalerRepository>();
            _mapperMock = new Mock<IMapper>();
            _validatorMock = new Mock<IValidator<AddBeerSaleCommand>>();
            _handler = new AddBeerSaleCommandHandler(_beerSaleRepositoryMock.Object, _beerRepositoryMock.Object, _wholesalerRepositoryMock.Object, _mapperMock.Object, _validatorMock.Object);
        }

        [Fact]
        public async Task Handle_ValidCommand_AddsBeerSale()
        {
            var command = new AddBeerSaleCommand
            {
                BeerId = 1,
                WholesalerId = 1,
                Quantity = 10,
                FixedPrice = 2.0m
            };

            _validatorMock.Setup(v => v.ValidateAsync(command, It.IsAny<CancellationToken>()))
                .ReturnsAsync(new ValidationResult());

            _beerRepositoryMock.Setup(r => r.GetBeerByIdAsync(command.BeerId))
                .ReturnsAsync(new Beer());

            _wholesalerRepositoryMock.Setup(r => r.GetWholesalerByIdAsync(command.WholesalerId))
                .ReturnsAsync(new Wholesaler());

            _mapperMock.Setup(m => m.Map<BeerSale>(command))
                .Returns(new BeerSale());

            await _handler.Handle(command, CancellationToken.None);

            _beerSaleRepositoryMock.Verify(r => r.AddBeerSaleAsync(It.IsAny<BeerSale>()), Times.Once);
        }
    }
}
