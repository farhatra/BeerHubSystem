using BeerHubSystem.Application.Contracts;
using BeerHubSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BeerHubSystem.Persistence.Repositories
{
    public class BeerSaleRepository : IBeerSaleRepository
    {
        private readonly ApplicationDbContext _context;

        public BeerSaleRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<BeerSale>> GetAllBeerSalesAsync()
        {
            return await _context.BeerSales.ToListAsync();
        }

        public async Task<BeerSale> GetBeerSaleByIdAsync(int id)
        {
            return await _context.BeerSales.FindAsync(id);
        }

        public async Task AddBeerSaleAsync(BeerSale beerSale)
        {
            await _context.BeerSales.AddAsync(beerSale);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateBeerSaleAsync(BeerSale beerSale)
        {
            _context.BeerSales.Update(beerSale);
            await _context.SaveChangesAsync();
        }
    }
}
