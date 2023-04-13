using Api_Restaurant_Order.Domain.Entities.Authorization;
using Api_Restaurant_Order.Domain.Repositories.Authorization;
using Api_Restaurant_Order.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Api_Restaurant_Order.Infra.Data.Repositories.Authorization
{
    public class PermissionRepository : IPermissionRepository
    {
        private readonly AppDbContext _db;
        public PermissionRepository(AppDbContext db)
        {
            _db = db;
        }
        public async Task<ICollection<Permission>> GetPermissionAsync()
        {
            return await _db.Permissions.ToListAsync();
        }
        public async Task<ICollection<Permission>> GetExistAsync(List<int> permissions)
        {
            return await _db.Permissions.Where(w => permissions.Contains(w.Id)).ToListAsync();
        }
    }
}
