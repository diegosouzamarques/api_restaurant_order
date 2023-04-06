namespace Api_Restaurant_Order.Application.DTOs
{
    public class TableDTO
    {
        public int Id { get; private set; }
        public string Title { get; private set; }
        public int AmountPeople { get; private set; }
        public string Status { get; set; }
    }

}
