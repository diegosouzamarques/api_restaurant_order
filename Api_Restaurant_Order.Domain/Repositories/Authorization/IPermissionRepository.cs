using Api_Restaurant_Order.Domain.Entities.Authorization;

namespace Api_Restaurant_Order.Domain.Repositories.Authorization
{
    public interface IPermissionRepository
    {
        Task<ICollection<Permission>> GetPermissionAsync();
        Task<ICollection<Permission>> GetExistAsync(List<int> permissions);
    }
}
