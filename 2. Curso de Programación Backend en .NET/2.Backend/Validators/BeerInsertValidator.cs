using _2.Backend.DTOs;
using FluentValidation;

namespace _2.Backend.Validators
{
    public class BeerInsertValidator : AbstractValidator<BeerInsertDto>
    {
        public BeerInsertValidator() {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.BrandId).NotEmpty();
            RuleFor(x => x.AlcoholPercentage).NotEmpty().InclusiveBetween(0, 100);
        }
    }
}
