using FluentValidation;

namespace Api_Restaurant_Order.Application.DTOs.Validations
{
    public class PhotoDisheDrinkDTOValidator : AbstractValidator<PhotoDisheDrinkDTO>
    {
        public PhotoDisheDrinkDTOValidator()
        {
            RuleFor(x => x.DisheDrinkId)
            .LessThanOrEqualTo(0)
            .WithMessage("Id do prato ou bedida deve ser informado!");

            RuleFor(x => x.File)
            .NotNull()
            .NotEmpty()
            .WithMessage("Imagem deve ser informado!");

        }
    }
}
