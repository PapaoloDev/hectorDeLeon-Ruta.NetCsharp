using _2.Backend.DTOs;
using _2.Backend.Models;
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

        public BeerController(StoreContext context)
        {
            _context = context;
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
        public async Task<ActionResult<BeerDto>> Get(int id)
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
    }
}
