using Api_Restaurant_Order.Domain.Validations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api_Restaurant_Order.Domain.Entities
{
    public class ItemOrder
    {
        [Key]
        public int Id { get;  private set; }
        public int DisheDrinkId { get; private set; }
        public int OrderId { get; private set; }

        [Range(0.01, double.MaxValue)]
        [Column(TypeName = "decimal(10, 2)")]
        public decimal Price { get; private set; }
        public DisheDrink DisheDrink { get; private set; }
        public Order Order { get; private set; }

        public ItemOrder(int id, int disheDrinkId, int orderId, decimal price)
        {
            DomainValidationException.When(id <= 0, "Id do item deve ser informado!");
            Id = id;
            Validation(disheDrinkId, orderId, price);
        }

        public ItemOrder(int disheDrinkId, int orderId, decimal price)
        {
            Validation(disheDrinkId, orderId, price);
        }

        private void Validation(int disheDrinkId, int orderId, decimal price) {

            DomainValidationException.When(disheDrinkId <= 0, "Id Prato ou Bedida deve ser informado!");
            DomainValidationException.When(orderId <= 0, "Id Pedido deve ser informado!");
            DomainValidationException.When(price <= 0, "Preço deve ser informado!");

            DisheDrinkId = disheDrinkId;
            OrderId = orderId;
            Price = price;
        }
    }
}
