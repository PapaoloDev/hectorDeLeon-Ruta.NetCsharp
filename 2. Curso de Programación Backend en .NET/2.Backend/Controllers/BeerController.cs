using _2.Backend.DTOs;
using _2.Backend.Models;
using _2.Backend.Services;
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
        private IBeerService _beerService;

        public BeerController(StoreContext context, 
            IValidator<BeerInsertDto> beerInsertValidator,
            IValidator<BeerUpdateDto> beerUpdateValidator,
            IBeerService beerService)
        {
            _context = context;
            _beerInsertValidator = beerInsertValidator;
            _beerUpdateValidator=beerUpdateValidator;
            _beerService = beerService;
        }

        [HttpGet]
        public async Task<IEnumerable<BeerDto>> Get()
        {
           return  await _beerService.Get();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BeerDto>> GetById(int id)
        {
            BeerDto beerDto = await _beerService.GetById(id);

            if (beerDto == null)
                return NotFound();

            return Ok(beerDto);
        }

        [HttpPost]
        public async Task<ActionResult<BeerDto>> Add(BeerInsertDto beerInsertDto)
        {
            var validationResult = await _beerInsertValidator.ValidateAsync(beerInsertDto);
            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            BeerDto beerDto = await _beerService.Add(beerInsertDto);

            return CreatedAtAction(nameof(GetById), new { id = beerDto.Id }, beerDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<BeerDto>> Update(int id, BeerUpdateDto beerUpdateDto)
        {
            beerUpdateDto.Id = id;

            var validationResult = await _beerUpdateValidator.ValidateAsync(beerUpdateDto);
            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            BeerDto beerDto = await _beerService.Update(id, beerUpdateDto);

            if (beerDto == null)
                return NotFound();

            return Ok(beerDto);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<BeerDto>> Delete(int id)
        {
            BeerDto beerDto = await _beerService.Delete(id);
            if (beerDto == null)
                return NotFound();

            return Ok(beerDto);
        }
    }
}
