using BeerHubSystem.Domain.Entities;

namespace BeerHubSystem.Application.Contracts
{
    public interface IBeerRepository
    {
        Task<IEnumerable<Beer>> GetAllBeersAsync();
        Task<Beer> GetBeerByIdAsync(int id);
        Task AddBeerAsync(Beer beer);
        Task UpdateBeerAsync(Beer beer);
        Task DeleteBeerAsync(Beer beer);
    }

}
