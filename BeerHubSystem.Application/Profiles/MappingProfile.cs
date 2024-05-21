using AutoMapper;
using BeerHubSystem.Application.Features.Commands.AddBeerSale;
using BeerHubSystem.Application.Features.Commands.CreateBeer;
using BeerHubSystem.Application.Features.DTOs;
using BeerHubSystem.Domain.Entities;

namespace BeerHubSystem.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Beer, BeerDto>().ReverseMap();
            CreateMap<Wholesaler, WholesalerDto>().ReverseMap();
            CreateMap<BeerSale, BeerSaleDto>().ReverseMap();
            CreateMap<CreateBeerCommand, Beer>();
            CreateMap<AddBeerSaleCommand, BeerSale>();
        }
    }

}
