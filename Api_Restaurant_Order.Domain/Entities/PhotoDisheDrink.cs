using System.ComponentModel.DataAnnotations;

namespace Api_Restaurant_Order.Domain.Entities
{
    public sealed class PhotoDisheDrink
    {
        [Key, Required]
        public int Id { get; set; }

        [Required]
        public int DisheDrinkId { get; set;}

        [Required]
        [MaxLength(255)]
        public string Url { get; set; }
        public DisheDrink DisheDrink { get; set; }
    }
}
