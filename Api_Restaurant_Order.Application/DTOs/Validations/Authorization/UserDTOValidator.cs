using Api_Restaurant_Order.Application.DTOs.Authorization;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api_Restaurant_Order.Application.DTOs.Validations.Authorization
{
    public class UserDTOValidator : AbstractValidator<UserDTO>
    {
        public UserDTOValidator()
        {

            RuleFor(x => x.Username)
                .NotNull()
                .NotEmpty()
                .WithMessage("Nome de usuário deve ser informado!")
                .MaximumLength(100)
                .WithMessage("Nome de usuário máximo 100 caracteres");

            RuleFor(x => x.Email)
                .NotNull()
                .NotEmpty()
                .WithMessage("Email deve ser informado!")
                .MaximumLength(200)
                .WithMessage("Email de usuário máximo 100 caracteres");

            RuleFor(x => x.Permissions)
                .NotNull().WithMessage("Permissões deve ser informadas")
                .Must(NotEqualZero).WithMessage("Deve pelo menos ter uma permissão informada");
        }

        private bool NotEqualZero(List<int> ints)
        {
            return ints.All(i => i != 0);
        }

    }
}
