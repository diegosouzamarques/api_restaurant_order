using Microsoft.AspNetCore.Http;

namespace Api_Restaurant_Order.Application.DTOs
{
    public class PhotoDisheDrinkDTO
    {
        public int DisheDrinkId { get; private set; }
        public IFormFile File { get; set; }

    }
}
