using Api_Restaurant_Order.Domain.Validations;
using System.ComponentModel.DataAnnotations;

namespace Api_Restaurant_Order.Domain.Entities
{
    public sealed class Table
    {
        [Key]
        public int Id { get; private set; }
        public string Title { get; private set; }

        [Range(1, int.MaxValue)]
        public int AmountPeople { get; private set; }
        public string Status { get; set; }

        public Table(int id,string title, int amountPeople, string status)
        {
            DomainValidationException.When(id <= 0, "ID da Mesa deve ser informado!");
            Id = id;
            Validade(title, amountPeople, status);
        }

        public Table(string title, int amountPeople, string status) {
            Validade(title, amountPeople, status);
        }

        private void Validade(string title, int amountPeople, string status) 
        {
            DomainValidationException.When(string.IsNullOrEmpty(title), "Título da Mesa deve ser informado!");
            DomainValidationException.When(amountPeople <= 0, "Quantidade de pessoas deve ser informado!");

            Title = title;
            AmountPeople = amountPeople;
            Status = status;
        }
    }
}
