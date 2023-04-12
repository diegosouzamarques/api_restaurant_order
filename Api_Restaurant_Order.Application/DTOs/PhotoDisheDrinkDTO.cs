using Microsoft.AspNetCore.Http;

namespace Api_Restaurant_Order.Application.DTOs
{
    public class PhotoDisheDrinkDTO
    {
        public int DisheDrinkId { get; set; }
        public IFormFile File { get; set; }

    }

    public class PhotoDisheDrinkViewDTO
    {
        public int Id { get; set; }
        public int DisheDrinkId { get; set; }

    }
}
