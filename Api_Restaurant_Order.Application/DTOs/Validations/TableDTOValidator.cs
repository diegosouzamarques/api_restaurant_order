using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api_Restaurant_Order.Application.DTOs.Validations
{
    public class TableDTOValidator : AbstractValidator<TableDTO>
    {
        public TableDTOValidator()
        {
            RuleFor(x => x.Title)
                .NotNull()
                .NotEmpty()
                .WithMessage("Título deve ser informado!")
                .MaximumLength(50)
                .WithMessage("Título máximo 50 caracteres");

            RuleFor(x => x.AmountPeople)
                .Must(NotEqualZero)
                .WithMessage("Quantidade de lugares deve ser informado!");

            RuleFor(x => x.Status)
                .NotNull()
                .NotEmpty()
                .IsInEnum()
                .WithMessage("Status da mesa dever ser informado de forma correta!");
        }

        private bool NotEqualZero(int value)
        {
            return !(value <= 0);
        }
    }
}
