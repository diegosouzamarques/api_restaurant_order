
namespace Api_Restaurant_Order.Application.Services.Interface.Authorization
{
    public interface IPasswordHash
    {
        public void HashPassword(string password, out byte[] passwordHash, out byte[] passwordSalt);
        public bool VerifyPasssword(string password, byte[] passwordHash, byte[] passwordSalt);
    }
}
