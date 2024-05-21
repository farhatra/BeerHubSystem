using BeerHubSystem.Domain.Entities;

namespace BeerHubSystem.Application.Contracts
{
    public interface IWholesalerRepository
    {
        Task<IEnumerable<Wholesaler>> GetAllWholesalersAsync();
        Task<Wholesaler> GetWholesalerByIdAsync(int id);
        Task AddWholesalerAsync(Wholesaler wholesaler);
        Task UpdateWholesalerAsync(Wholesaler wholesaler);
    }
}
