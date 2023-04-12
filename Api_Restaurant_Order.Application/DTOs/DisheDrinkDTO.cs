using Api_Restaurant_Order.Domain.Enumerator;

namespace Api_Restaurant_Order.Application.DTOs
{
    public class DisheDrinkDTO
    {
        public int Id { get; set; }
        public EDisheDrink Kind { get; set; }
        public string Title { get; set; }
        public string Descript { get; set; }
        public string? Origin { get; set; }
        public string? Type { get; set; }
        public decimal? Volume { get; set; }
        public decimal Price { get; set; }
    }
}
