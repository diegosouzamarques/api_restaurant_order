namespace Api_Restaurant_Order.Application.DTOs
{
    public class ItemOrderDTO
    {
        public int Id { get; set; }
        public int DisheDrinkId { get; set; }
        public int OrderId { get; set; }
        public decimal Price { get; set; }
    }
}
