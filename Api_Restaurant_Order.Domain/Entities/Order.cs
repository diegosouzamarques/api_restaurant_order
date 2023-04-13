using System.ComponentModel.DataAnnotations;

namespace Api_Restaurant_Order.Domain.Entities
{
    public sealed class Order
    {
        [Key, Required]
        public int Id { get; set; }

        [Required]
        public int TableID { get; set; }

        [Required]
        [MinLength(3), MaxLength(100)]
        public string Requester { get; set; }

        [MaxLength(250)]
        public string? Note { get; set; }
        public List<ItemOrder> ItemsOrder { get; set; }
        public Table Table { get; set; }

        public Order()
        {
            ItemsOrder= new List<ItemOrder>();
        }

    }
}
