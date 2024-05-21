using AutoMapper;
using BeerHubSystem.Application.Contracts;
using BeerHubSystem.Application.Features.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerHubSystem.Application.Features.Queries.GetBeersByBrewery
{
    public class GetBeersByBreweryQueryHandler : IRequestHandler<GetBeersByBreweryQuery, IEnumerable<BeerDto>>
    {
        private readonly IBeerRepository _beerRepository;
        private readonly IMapper _mapper;

        public GetBeersByBreweryQueryHandler(IBeerRepository beerRepository, IMapper mapper)
        {
            _beerRepository = beerRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<BeerDto>> Handle(GetBeersByBreweryQuery request, CancellationToken cancellationToken)
        {
            var beers = await _beerRepository.GetAllBeersAsync();
            var breweryBeers = beers.Where(b => b.BreweryId == request.BreweryId);
            return _mapper.Map<IEnumerable<BeerDto>>(breweryBeers);
        }
    }
}
