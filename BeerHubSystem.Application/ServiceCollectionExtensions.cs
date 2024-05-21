using BeerHubSystem.Application.Contracts;
using BeerHubSystem.Application.Exceptions;
using BeerHubSystem.Application.Features.Commands.AddBeerSale;
using BeerHubSystem.Application.Features.Commands.CreateBeer;
using BeerHubSystem.Application.Features.Commands.RequestQuote;
using BeerHubSystem.Application.Features.Commands.UpdateBeerQuantity;
using BeerHubSystem.Application.Profiles;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace BeerHubSystem.Application
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MappingProfile));
            services.AddMediatR(typeof(CreateBeerCommand).Assembly);
            services.AddValidatorsFromAssemblyContaining<CreateBeerCommandValidator>();

            //services.AddTransient<IBeerRepository, BeerRepository>();
            //services.AddTransient<IWholesalerRepository, WholesalerRepository>();
            //services.AddTransient<IBeerSaleRepository, BeerSaleRepository>();

            services.AddTransient<IValidator<CreateBeerCommand>, CreateBeerCommandValidator>();
            services.AddTransient<IValidator<AddBeerSaleCommand>, AddBeerSaleCommandValidator>();
            services.AddTransient<IValidator<UpdateBeerQuantityCommand>, UpdateBeerQuantityCommandValidator>();
            services.AddTransient<IValidator<RequestQuoteCommand>, RequestQuoteCommandValidator>();

            return services;
        }
    }
}
