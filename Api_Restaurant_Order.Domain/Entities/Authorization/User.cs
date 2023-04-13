using System.ComponentModel.DataAnnotations;


namespace Api_Restaurant_Order.Domain.Entities.Authorization
{
    public sealed class User
    {
        [Key, Required]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Username { get; set; }
        [Required]
        [StringLength(200)]
        public string Email { get; set; }
        public byte[]? PasswordHash { get; set; }
        public byte[]? PasswordSalt { get; set; }
        [StringLength(500)]
        public string? RefreshToken { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? TokenExpires { get; set; }
        public ICollection<UserPermission> UserPermissions { get; set; }

        public User()
        {
            UserPermissions = new List<UserPermission>();
        }
    }
}
