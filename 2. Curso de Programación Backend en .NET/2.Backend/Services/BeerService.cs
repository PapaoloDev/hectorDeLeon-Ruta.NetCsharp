using _2.Backend.DTOs;
using _2.Backend.Models;
using _2.Backend.Repository;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace _2.Backend.Services
{
    public class BeerService : ICommonService<BeerDto, BeerInsertDto, BeerUpdateDto>
    {
        private IRepository<Beer> _beerRepository;
        private IMapper _mapper;

        public List<string> Errors { get; }

        public BeerService(
            IRepository<Beer> beerRepository,
            IMapper mapper)
        {
            _beerRepository = beerRepository;
            _mapper = mapper;
            Errors = new List<string>();
        }
        
        public async Task<IEnumerable<BeerDto>> Get()
        {
            IEnumerable<Beer> beers = await _beerRepository.Get();
            List<BeerDto> beerDtos = LoadBeerDtos(beers);

            return beerDtos;
        }

        public async Task<BeerDto?> GetById(int id)
        {
            Beer? beer = await _beerRepository.GetById(id);
            
            if (beer == null)
                return null;

            BeerDto beerDto = _mapper.Map<BeerDto>(beer);
            return beerDto;
        }
        
        public async Task<BeerDto> Add(BeerInsertDto beerInsertDto)
        {
            Beer beer = _mapper.Map<Beer>(beerInsertDto);

            await _beerRepository.Add(beer);
            await _beerRepository.Save();

            BeerDto beerDto = _mapper.Map<BeerDto>(beer);
            return beerDto;
        }

        public async Task<BeerDto?> Update(int id, BeerUpdateDto beerUpdateDto)
        {
            Beer? beer = await _beerRepository.GetById(id);

            if (beer != null)
            {
                beer = _mapper.Map(beerUpdateDto, beer);
                _beerRepository.Update(beer);
                await _beerRepository.Save();

                BeerDto beerDto = _mapper.Map<BeerDto>(beer);
                return beerDto;
            }
            
            return null;
        }
        
        public async Task<BeerDto?> Delete(int id)
        {
            var beer = await _beerRepository.GetById(id);
            if (beer == null)
                return null;

            _beerRepository.Delete(beer);
            await _beerRepository.Save();

            BeerDto beerDto = _mapper.Map<BeerDto>(beer);
            return beerDto;
        }

        public bool Validate(BeerInsertDto beerInsert)
        {
            if(_beerRepository.Search(b => b.Name == beerInsert.Name).Count() > 0)
            {
                Errors.Add("No puede existir una cerveza con un nombre ya existente.");
                return false;
            }
            return true;
        }
        public bool Validate(BeerUpdateDto beerUpdate)
        {
            if (_beerRepository.Search(b => b.Name == beerUpdate.Name
            && beerUpdate.Id != b.BeerId).Count() > 0)
            {
                Errors.Add("No puede existir una cerveza con un nombre ya existente.");
                return false;
            }
            return true;
        }
        private List<BeerDto> LoadBeerDtos(IEnumerable<Beer> beers)
        {
            List<BeerDto> beerDtos = new List<BeerDto>();
            foreach (var beer in beers)
            {
                BeerDto beerDto = _mapper.Map<BeerDto>(beer);
                beerDtos.Add(beerDto);
            }
            return beerDtos;
        }
    }
}
