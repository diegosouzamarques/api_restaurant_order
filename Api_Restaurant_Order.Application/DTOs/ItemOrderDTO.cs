namespace Api_Restaurant_Order.Application.DTOs
{
    public class ItemOrderDTO
    {
        public int Id { get; private set; }
        public int DisheDrinkId { get; private set; }
        public int OrderId { get; private set; }
        public decimal Price { get; private set; }
    }
}
