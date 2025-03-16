using _2.Backend.DTOs;
using _2.Backend.Models;
using _2.Backend.Repository;
using Microsoft.EntityFrameworkCore;

namespace _2.Backend.Services
{
    public class BeerService : ICommonService<BeerDto, BeerInsertDto, BeerUpdateDto>
    {
        private StoreContext _context;
        private IRepository<Beer> _beerRepository;

        public BeerService(StoreContext context,
            IRepository<Beer> beerRepository)
        {
            _context = context;
            _beerRepository = beerRepository;
        }
        public async Task<IEnumerable<BeerDto>> Get()
        {
            IEnumerable<Beer> beers = await _beerRepository.Get();
            List<BeerDto> beerDtos = LoadBeerDtos(beers);

            return beerDtos;
        }

        public async Task<BeerDto> GetById(int id)
        {
            Beer? beer = await _beerRepository.GetById(id);
            
            if (beer == null)
                return null;

            BeerDto beerDto = LoadBeerDto(beer);
            return beerDto;
        }
        
        public async Task<BeerDto> Add(BeerInsertDto beerInsertDto)
        {
            Beer beer = LoadBeer(beerInsertDto);

            await _context.Beers.AddAsync(beer);
            await _context.SaveChangesAsync();

            BeerDto beerDto = LoadBeerDto(beer);
            return beerDto;
        }

        public async Task<BeerDto> Update(int id, BeerUpdateDto beerUpdateDto)
        {
            Beer? beer = await _context.Beers.FindAsync(id);

            if (beer != null)
            {
                beer = LoadBeer(beerUpdateDto, beer);
                await _context.SaveChangesAsync();

                BeerDto beerDto = LoadBeerDto(beer);
                return beerDto;
            }
            
            return null;
        }
        
        public async Task<BeerDto> Delete(int id)
        {
            var beer = await _context.Beers.FindAsync(id);
            if (beer == null)
                return null;

            _context.Beers.Remove(beer);
            await _context.SaveChangesAsync();

            BeerDto beerDto = LoadBeerDto(beer);
            return beerDto;
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

        private List<BeerDto> LoadBeerDtos(IEnumerable<Beer> beers)
        {
            List<BeerDto> beerDtos = new List<BeerDto>();
            foreach (var beer in beers)
            {
                BeerDto beerDto = LoadBeerDto(beer);
                beerDtos.Add(beerDto);
            }
            return beerDtos;
        }

        private Beer LoadBeer(BeerInsertDto beerInsertDto)
        {
            var beer = new Beer()
            {
                Name = beerInsertDto.Name,
                AlcoholPercentage = beerInsertDto.AlcoholPercentage,
                BrandId = beerInsertDto.BrandId
            };
            return beer;
        }

        private Beer LoadBeer(BeerUpdateDto beerUpdateDto, Beer beer)
        {
            beer.Name = beerUpdateDto.Name;
            beer.AlcoholPercentage = beerUpdateDto.AlcoholPercentage;
            beer.BrandId = beerUpdateDto.BrandId;
            return beer;
        }

    }
}
