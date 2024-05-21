using BeerHubSystem.Domain.Entities;

namespace BeerHubSystem.Application.Contracts
{
    public interface IBeerSaleRepository
    {
        Task<IEnumerable<BeerSale>> GetAllBeerSalesAsync();
        Task<BeerSale> GetBeerSaleByIdAsync(int id);
        Task AddBeerSaleAsync(BeerSale beerSale);
        Task UpdateBeerSaleAsync(BeerSale beerSale);
    }
}
