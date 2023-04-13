using System.ComponentModel.DataAnnotations;

namespace Api_Restaurant_Order.Domain.Entities.Authorization
{
    public sealed class UserPermission
    {
        [Key, Required]
        public int Id { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public int PermissionId { get; set; }

        public User User { get; set; }
        public Permission Permission { get; set; }
    }
}
