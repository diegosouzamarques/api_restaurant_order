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
                .LessThanOrEqualTo(0)
                .WithMessage("Quantidade de lugares deve ser informado!");
        }
    }
}
