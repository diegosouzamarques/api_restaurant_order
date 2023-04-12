using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api_Restaurant_Order.Application.DTOs.Validations
{
    public class OrderDTOValidator : AbstractValidator<OrderDTO>
    {
        public OrderDTOValidator()
        {
            RuleFor(x => x.TableID)
                .Must(NotEqualZero)
                .WithMessage("Id da mesa deve ser informado!");

            RuleFor(x => x.Requester)
                 .NotNull()
                 .NotEmpty()
                 .WithMessage("Solicitante deve ser informado!")
                 .MaximumLength(100)
                 .WithMessage("Solicitante máximo 100 caracteres");

            RuleFor(x => x.Note)
                 .MaximumLength(250)
                 .WithMessage("Solicitante máximo 250 caracteres");
        }

        private bool NotEqualZero(int value)
        {
            return !(value <= 0);
        }
    }
}
