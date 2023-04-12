using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api_Restaurant_Order.Domain.Entities
{
    public class ItemOrder
    {
        [Key, Required]
        public int Id { get; set; }

        [Required]
        public int DisheDrinkId { get; set; }

        [Required]
        public int OrderId { get; set; }

        [Required]
        [Range(0.01, double.MaxValue)]
        [Column(TypeName = "decimal(10, 2)")]
        public decimal Price { get; set; }
        public DisheDrink DisheDrink { get; set; }
        public Order Order { get; set; }
    }
}
