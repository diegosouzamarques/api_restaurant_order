namespace Api_Restaurant_Order.Application.DTOs
{
    public class OrderDTO
    {
        public int Id { get; private set; }
        public int TableID { get; private set; }
        public string Requester { get; private set; }
        public string Note { get; private set; }
    }
}
