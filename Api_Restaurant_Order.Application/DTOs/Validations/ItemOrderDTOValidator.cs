using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api_Restaurant_Order.Application.DTOs.Validations
{
    public class ItemOrderDTOValidator : AbstractValidator<ItemOrderDTO>
    {
        public ItemOrderDTOValidator()
        {

            RuleFor(x => x.DisheDrinkId)
                .LessThanOrEqualTo(0)
                .WithMessage("Id prato ou bebida deve ser informado!");

            RuleFor(x => x.OrderId)
                .LessThanOrEqualTo(0)
                .WithMessage("Id do pedido deve ser informado!");

            RuleFor(x => x.Price)
                .LessThanOrEqualTo(0)
                .WithMessage("Preço deve ser informado!")
                .PrecisionScale(10, 2, false)
                .WithMessage("Preço tipo decimal tamanho 10 decimal 2 digitos");

        }
    }
}
