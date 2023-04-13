using Api_Restaurant_Order.Domain.Entities.Authorization;
using Api_Restaurant_Order.Domain.Repositories.Authorization;
using Api_Restaurant_Order.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Api_Restaurant_Order.Infra.Data.Repositories.Authorization
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _appDbContext;

        public UserRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<User> CreateAsync(User user)
        {
            _appDbContext.Add(user);
            await _appDbContext.SaveChangesAsync();
            return user;
        }

        public async Task<User?> GetUserByRefreshTokenAsync(string refreshTokenDTO)
        {
            return await _appDbContext.Users
                          .FirstOrDefaultAsync(x => x.RefreshToken == refreshTokenDTO);
        }

        public async Task<User?> GetUserByUsernameAsync(string username)
        {
            return await _appDbContext.Users
                          .Include(x => x.UserPermissions)
                          .ThenInclude(x => x.Permission)
                          .FirstOrDefaultAsync(x => x.Username == username);
        }

        public async Task<User> TokenRegisterAsync(User user)
        {
            _appDbContext.Update(user);
            await _appDbContext.SaveChangesAsync();
            return user;
        }

        public async Task<User> EditAsync(User user)
        {
            _appDbContext.Update(user);
            await _appDbContext.SaveChangesAsync();
            return user;

        }
    }
}
