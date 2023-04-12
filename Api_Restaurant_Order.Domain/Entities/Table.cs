using Api_Restaurant_Order.Domain.Enumerator;
using System.ComponentModel.DataAnnotations;

namespace Api_Restaurant_Order.Domain.Entities
{
    public sealed class Table
    {
        [Key, Required]
        public int Id { get; set; }

        [Required]
        [MinLength(3), MaxLength(50)]
        public string Title { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int AmountPeople { get; set; }

        [Required]
        public ETableStatus Status { get; set; }
    }
}
