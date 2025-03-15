using _2.Backend.DTOs;
using _2.Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace _2.Backend.Services
{
    public class BeerService : IBeerService
    {
        private StoreContext _context;

        public BeerService(StoreContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<BeerDto>> Get()
        {
            return await _context.Beers.Select(x => new BeerDto
            {
                Id = x.BeerId,
                Name = x.Name,
                AlcoholPercentage = x.AlcoholPercentage,
                BrandId = x.BrandId
            }).ToListAsync();
        }

        public async Task<BeerDto> GetById(int id)
        {
            var beer = await _context.Beers.FindAsync(id);
            BeerDto beerDto = new BeerDto();

            if (beer == null)
                return beerDto;

            beerDto = LoadBeerDto(beer);

            return beerDto;
        }
        
        public Task<BeerDto> Add(BeerInsertDto beerInsertDto)
        {
            throw new NotImplementedException();
        }

        public Task<BeerDto> Update(int id, BeerUpdateDto beerUpdateDto)
        {
            throw new NotImplementedException();
        }
        
        public Task<BeerDto> Delete(int id)
        {
            throw new NotImplementedException();
        }

        private BeerDto LoadBeerDto(Beer beer) 
        {
            var beerDto = new BeerDto
            {
                Id = beer.BeerId,
                Name = beer.Name,
                AlcoholPercentage = beer.AlcoholPercentage,
                BrandId = beer.BrandId
            };

            return beerDto;
        }

    }
}
