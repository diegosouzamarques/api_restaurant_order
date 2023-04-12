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
                .Must(NotEqualZero)
                .WithMessage("Id prato ou bebida deve ser informado!");

            RuleFor(x => x.OrderId)
                .Must(NotEqualZero)
                .WithMessage("Id do pedido deve ser informado!");

            RuleFor(x => x.Price)
                .Must(NotEqualZeroDecima)
                .WithMessage("Preço deve ser informado!")
                .PrecisionScale(10, 2, false)
                .WithMessage("Preço tipo decimal tamanho 10 decimal 2 digitos");

        }

        private bool NotEqualZeroDecima(decimal value)
        {
            return !(value <= 0);
        }

        private bool NotEqualZero(int value)
        {
            return !(value <= 0);
        }
    }
}
