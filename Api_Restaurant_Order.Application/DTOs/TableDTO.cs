using Api_Restaurant_Order.Domain.Enumerator;

namespace Api_Restaurant_Order.Application.DTOs
{
    public class TableDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int AmountPeople { get; set; }    
        public ETableStatus Status { get; set; }
    }

}
