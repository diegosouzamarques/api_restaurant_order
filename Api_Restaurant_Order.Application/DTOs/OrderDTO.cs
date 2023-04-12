namespace Api_Restaurant_Order.Application.DTOs
{
    public class OrderDTO
    {
        public int Id { get; set; }
        public int TableID { get; set; }
        public string Requester { get; set; }
        public string? Note { get; set; }
    }
}
