using FluentValidation;

namespace Api_Restaurant_Order.Application.DTOs.Validations
{
    public class DisheDrinkDTOValidator : AbstractValidator<DisheDrinkDTO>
    {
        public DisheDrinkDTOValidator()
        {
            RuleFor(x => x.Kind)
            .NotNull()
            .NotEmpty()
            .IsInEnum()
            .WithMessage("Espécie do alimento deve ser informado corretamente!");

            RuleFor(x => x.Title)
                 .NotNull()
                 .NotEmpty()
                 .WithMessage("Título deve ser informado!")
                 .MaximumLength(40)
                 .WithMessage("Título máximo 40 caracteresss");

            RuleFor(x => x.Descript)
                 .NotNull()
                    .NotEmpty()
                    .WithMessage("Descrição deve ser informado!")
                    .MaximumLength(350)
                    .WithMessage("Descrição máximo 350 caracteres");

            RuleFor(x => x.Origin)
                  .MaximumLength(50)
                  .WithMessage("Origem máximo 50 caracteres");

            RuleFor(x => x.Type)
                  .MaximumLength(50)
                  .WithMessage("Tipo máximo 50 caracteres");

            RuleFor(x => x.Volume)
                  .PrecisionScale(10, 2, false)
                  .WithMessage("Volume tipo decimal tamanho 10 decimal 2 digitos");


            RuleFor(x => x.Price)
                  .NotNull()    
                  .NotEmpty()
                  .Must(NotEqualZero) 
                  .WithMessage("Preço deve ser informado!")
                  .PrecisionScale(10, 2, false)
                  .WithMessage("Preço tipo decimal tamanho 10 decimal 2 digitos");

        }

        private bool NotEqualZero(decimal price)
        {
            return !(price <= 0);
        }
    }
}
