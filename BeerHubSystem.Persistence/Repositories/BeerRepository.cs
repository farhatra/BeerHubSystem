using BeerHubSystem.Application.Contracts;
using BeerHubSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerHubSystem.Persistence.Repositories
{
    public class BeerRepository : IBeerRepository
    {
        private readonly ApplicationDbContext _context;

        public BeerRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Beer>> GetAllBeersAsync()
        {
            return await _context.Beers.ToListAsync();
        }

        public async Task<Beer> GetBeerByIdAsync(int id)
        {
            return await _context.Beers.FindAsync(id);
        }

        public async Task AddBeerAsync(Beer beer)
        {
            await _context.Beers.AddAsync(beer);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateBeerAsync(Beer beer)
        {
            _context.Beers.Update(beer);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteBeerAsync(Beer beer)
        {
            _context.Beers.Remove(beer);
            await _context.SaveChangesAsync();
        }
    }
}
