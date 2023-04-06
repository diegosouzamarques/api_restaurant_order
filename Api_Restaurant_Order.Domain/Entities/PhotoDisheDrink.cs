using Api_Restaurant_Order.Domain.Validations;
using System.ComponentModel.DataAnnotations;

namespace Api_Restaurant_Order.Domain.Entities
{
    public sealed class PhotoDisheDrink
    {
        [Key]
        public int Id { get; private set; }
        public int DisheDrinkId { get; private set;}
        public string Url { get; private set; }
        public DisheDrink DisheDrink { get; private set; }

        public PhotoDisheDrink(int id, int disheDrinkId, string url)
        {
            DomainValidationException.When(id <= 0, "Id da foto deve ser informado!");
            Id = id;
            Validade(disheDrinkId, url);

        }

        public PhotoDisheDrink(int disheDrinkId, string url)
        {
            Validade(disheDrinkId, url);

        }
        private void Validade(int disheDrinkId, string url)
        {
            c
            DomainValidationException.When(string.IsNullOrEmpty(url), "Url da foto deve ser informado!");
            DisheDrinkId = disheDrinkId;
            Url = url;
        }
    }
}
