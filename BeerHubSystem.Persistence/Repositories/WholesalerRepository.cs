using BeerHubSystem.Application.Contracts;
using BeerHubSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BeerHubSystem.Persistence.Repositories
{
    public class WholesalerRepository : IWholesalerRepository
    {
        private readonly ApplicationDbContext _context;

        public WholesalerRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Wholesaler>> GetAllWholesalersAsync()
        {
            return await _context.Wholesalers.ToListAsync();
        }

        public async Task<Wholesaler> GetWholesalerByIdAsync(int id)
        {
            return await _context.Wholesalers.FindAsync(id);
        }

        public async Task AddWholesalerAsync(Wholesaler wholesaler)
        {
            await _context.Wholesalers.AddAsync(wholesaler);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateWholesalerAsync(Wholesaler wholesaler)
        {
            _context.Wholesalers.Update(wholesaler);
            await _context.SaveChangesAsync();
        }
    }
}
