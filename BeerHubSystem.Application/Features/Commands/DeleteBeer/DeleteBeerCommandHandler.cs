using BeerHubSystem.Application.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerHubSystem.Application.Features.Commands.DeleteBeer
{
    public class DeleteBeerCommandHandler : IRequestHandler<DeleteBeerCommand>
    {
        private readonly IBeerRepository _beerRepository;

        public DeleteBeerCommandHandler(IBeerRepository beerRepository)
        {
            _beerRepository = beerRepository;
        }

        public async Task<Unit> Handle(DeleteBeerCommand request, CancellationToken cancellationToken)
        {
            var beer = await _beerRepository.GetBeerByIdAsync(request.BeerId);
            if (beer == null) throw new Exception("Beer not found");

            await _beerRepository.DeleteBeerAsync(beer);

            return Unit.Value;
        }
    }
}
