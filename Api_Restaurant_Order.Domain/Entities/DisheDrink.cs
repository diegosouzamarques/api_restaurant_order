using Api_Restaurant_Order.Domain.Enumerator;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api_Restaurant_Order.Domain.Entities
{
    public sealed class DisheDrink
    {
        [Key, Required]
        public int Id { get; set; }

        [Required]
        public EDisheDrink Kind { get; set; }

        [Required]
        [MinLength(3), MaxLength(40)]
        public string Title { get; set; }

        [Required]
        [MinLength(3), MaxLength(350)]
        public string Descript { get; set; }

        [MinLength(3), MaxLength(50)]
        public string? Origin { get; set; }

        [MinLength(3), MaxLength(50)]
        public string? Type { get; set; }

        [Range(0.01, double.MaxValue)]
        [Column(TypeName = "decimal(10, 2)")]
        public decimal? Volume { get; set; }

        [Range(0.01, double.MaxValue)]
        [Column(TypeName = "decimal(10, 2)")]
        public decimal Price { get; set; }
        public ICollection<PhotoDisheDrink> PhotosDisheDrink { get; private set; }

        public DisheDrink()
        {
            PhotosDisheDrink = new List<PhotoDisheDrink>();
        }

    }
}
