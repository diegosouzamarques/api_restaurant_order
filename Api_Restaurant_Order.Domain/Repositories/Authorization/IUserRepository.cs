using Api_Restaurant_Order.Domain.Entities.Authorization;

namespace Api_Restaurant_Order.Domain.Repositories.Authorization
{
    public interface IUserRepository
    {
        Task<User?> GetUserByUsernameAsync(string username);
        Task<User> CreateAsync(User user);
        Task<User> TokenRegisterAsync(User user);
        Task<User> GetUserByRefreshTokenAsync(string refreshTokenDTO);
        Task<User> EditAsync(User user);

    }
}
