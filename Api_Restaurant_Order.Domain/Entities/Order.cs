using Api_Restaurant_Order.Domain.Validations;
using System.ComponentModel.DataAnnotations;

namespace Api_Restaurant_Order.Domain.Entities
{
    public sealed class Order
    {
        [Key]
        public int Id { get;  private set; }
        public int TableID { get; private set; }
        public string Requester { get; private set; }
        public string Note { get; private set; }
        public List<ItemOrder> ItemsOrder { get;private set; }
        public Table Table { get; private set; }

        public Order(int id, int tableId, string requester, string note)
        {
            DomainValidationException.When(id <= 0, "Id do pedido deve ser informado!");
            Id = id;
            Validation(tableId, requester, note);
            ItemsOrder = new List<ItemOrder>();
        }

        public Order(int tableId, string requester, string note)
        {
            Validation(tableId, requester, note);
            ItemsOrder = new List<ItemOrder>();
        }

        private void Validation(int tableId, string requester, string note) 
        {
            DomainValidationException.When(tableId <= 0, "Id da Mesa deve ser informado!");
            DomainValidationException.When(string.IsNullOrEmpty(requester), "Solicitante deve ser informado!");

            TableID = tableId;
            Requester = requester;
            Note = note;
        }

    }
}
