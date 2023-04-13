using Api_Restaurant_Order.Application.DTOs.Authorization;
using FluentValidation;

namespace Api_Restaurant_Order.Application.DTOs.Validations.Authorization
{
    public class RefreshTokenDTOValidator : AbstractValidator<RefreshTokenDTO>
    {
        public RefreshTokenDTOValidator()
        {
            RuleFor(x => x.RefreshToken)
            .NotNull()
            .NotEmpty()
            .WithMessage("Token refresh deve ser informado!");
        }

    }
}
