using Api_Restaurant_Order.Domain.Validations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api_Restaurant_Order.Domain.Entities
{
    public sealed class DisheDrink
    {
        [Key]
        public int Id { get; private set; }

        [MinLength(3), MaxLength(40)]
        public string Title { get; private set; }

        [MinLength(3), MaxLength(350)]
        public string Descript { get; private set; }

        [MinLength(3), MaxLength(50)]
        public string Origin { get; private set; }

        [MinLength(3), MaxLength(50)]
        public string Type { get; private set; }

        [Range(0.01, double.MaxValue)]
        [Column(TypeName = "decimal(10, 2)")]
        public decimal? Volume { get; private set; }

        [Range(0.01, double.MaxValue)]
        [Column(TypeName = "decimal(10, 2)")]
        public decimal Price { get; private set; }
        public ICollection<PhotoDisheDrink> PhotosDisheDrink { get; private set; }

        public DisheDrink(int id, string title, string descript, string origin, string type, decimal volume, decimal price)
        {
            DomainValidationException.When(id < 0, "Id dever ser maior que zero!");
            Validation(title, descript, origin, type, volume, price);
            Id = id;
            PhotosDisheDrink = new List<PhotoDisheDrink>();
        }

        public DisheDrink(string title, string descript, string origin, string type, decimal volume, decimal price)
        {
            Validation(title, descript, origin, type, volume, price);
            PhotosDisheDrink = new List<PhotoDisheDrink>();
        }

        private void Validation(string title, string descript, string origin, string type, decimal volume, decimal price) {

            DomainValidationException.When(string.IsNullOrEmpty(title), "Título deve ser informado!");
            DomainValidationException.When(string.IsNullOrEmpty(descript), "Descrição deve ser informado!");
            DomainValidationException.When(string.IsNullOrEmpty(type), "Tipo deve ser informado!");
            DomainValidationException.When(price <= 0, "Preço deve ser informado!");

            Title = title;
            Descript = descript;
            Type = type;
            Price = price;
            Origin = origin;
            Volume = volume;

        }

    }
}
