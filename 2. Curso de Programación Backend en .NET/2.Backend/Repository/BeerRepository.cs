using _2.Backend.DTOs;
using _2.Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace _2.Backend.Repository
{
    public class BeerRepository : IRepository<Beer>
    {
        private StoreContext _context;

        public BeerRepository(StoreContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Beer>> Get()
        {
            return await _context.Beers.ToListAsync();
        }

        public async Task<Beer?> GetById(int id)
        {
            return await _context.Beers.FindAsync(id);
        }
        public Task Add(Beer entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Beer entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Beer entity)
        {
            throw new NotImplementedException();
        }       

        public Task Save()
        {
            throw new NotImplementedException();
        }
        
    }
}
