namespace Api_Restaurant_Order.Application.DTOs.Authorization
{
    public class UserDTO
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public List<int> Permissions { get; set; }

        public UserDTO()
        {
            Permissions = new List<int>();
        }
    }
}
