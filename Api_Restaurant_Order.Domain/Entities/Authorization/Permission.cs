using System.ComponentModel.DataAnnotations;

namespace Api_Restaurant_Order.Domain.Entities.Authorization
{
    public class Permission
    {
        [Key, Required]
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string VisualName { get; set; }

        [Required]
        [StringLength(200)]
        public string PermissionName { get; set; }
        public ICollection<UserPermission> UserPermissions { get; set; }

        public Permission() {
            UserPermissions = new List<UserPermission>();
        }
    }
}
