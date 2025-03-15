using _2.Backend.DTOs;
using _2.Backend.Models;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace _2.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BeerController : ControllerBase
    {
        private StoreContext _context;
        private IValidator<BeerInsertDto> _beerInsertValidator;
        private IValidator<BeerUpdateDto> _beerUpdateValidator;

        public BeerController(StoreContext context, 
            IValidator<BeerInsertDto> beerInsertValidator,
            IValidator<BeerUpdateDto> beerUpdateValidator)
        {
            _context = context;
            _beerInsertValidator = beerInsertValidator;
            _beerUpdateValidator=beerUpdateValidator;
        }

        [HttpGet]
        public async Task<IEnumerable<BeerDto>> Get()
        {
           return  await _context.Beers.Select(x => new BeerDto
            {
                Id = x.BeerId,
                Name = x.Name,
                AlcoholPercentage = x.AlcoholPercentage,
                BrandId = x.BrandId
            }).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BeerDto>> GetById(int id)
        {
            var beer = await _context.Beers.FindAsync(id);

            if (beer == null)
                return NotFound();

            var beerDto = new BeerDto
            {
                Id = beer.BeerId,
                Name = beer.Name,
                AlcoholPercentage = beer.AlcoholPercentage,
                BrandId = beer.BrandId
            };

            return beerDto;
        }

        [HttpPost]
        public async Task<ActionResult<BeerDto>> Add(BeerInsertDto beerInsertDto)
        {
            var validationResult = await _beerInsertValidator.ValidateAsync(beerInsertDto);
            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var beer = new Beer()
            {
                Name = beerInsertDto.Name,
                AlcoholPercentage = beerInsertDto.AlcoholPercentage,
                BrandId = beerInsertDto.BrandId
            };

            await _context.Beers.AddAsync(beer);
            await _context.SaveChangesAsync();

            var beerDto = new BeerDto
            {
                Id = beer.BeerId,
                Name = beer.Name,
                AlcoholPercentage = beer.AlcoholPercentage,
                BrandId = beer.BrandId
            };

            return CreatedAtAction(nameof(GetById), new { id = beer.BeerId }, beerDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<BeerDto>> Update(int id, BeerUpdateDto beerUpdateDto)
        {
            beerUpdateDto.Id = id;

            var validationResult = await _beerUpdateValidator.ValidateAsync(beerUpdateDto);
            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var beer = await _context.Beers.FindAsync(id);

            if(beer == null)
                return NotFound();

            beer.Name = beerUpdateDto.Name;
            beer.AlcoholPercentage = beerUpdateDto.AlcoholPercentage;
            beer.BrandId = beerUpdateDto.BrandId;

            await _context.SaveChangesAsync();

            var beerDto = new BeerDto
            {
                Id = beer.BeerId,
                Name = beer.Name,
                AlcoholPercentage = beer.AlcoholPercentage,
                BrandId = beer.BrandId
            };

            return Ok(beerDto);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<BeerDto>> Delete(int id)
        {
            var beer = await _context.Beers.FindAsync(id);
            if (beer == null)
                return NotFound();

            _context.Beers.Remove(beer);
            await _context.SaveChangesAsync();

            var beerDto = new BeerDto
            {
                Id = beer.BeerId,
                Name = beer.Name,
                AlcoholPercentage = beer.AlcoholPercentage,
                BrandId = beer.BrandId
            };

            return Ok();
        }
    }
}
