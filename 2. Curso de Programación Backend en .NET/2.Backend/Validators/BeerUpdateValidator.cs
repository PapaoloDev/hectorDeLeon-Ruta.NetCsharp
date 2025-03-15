using _2.Backend.DTOs;
using FluentValidation;

namespace _2.Backend.Validators
{
    public class BeerUpdateValidator : AbstractValidator<BeerUpdateDto>
    {
        public BeerUpdateValidator() 
        {
            RuleFor(x => x.Id).NotNull().WithMessage("el id es obligatorio.");
            RuleFor(x => x.Name).NotEmpty().WithMessage("el nombre es obligatorio.");
            RuleFor(x => x.Name).Length(2, 20).WithMessage("el nombre debe medir de 2 a 20 caracteres.");
            RuleFor(x => x.BrandId).NotEmpty().WithMessage("la marca es obligatoria");
            RuleFor(x => x.AlcoholPercentage).NotEmpty().InclusiveBetween(0, 100);
        }
    }
}
