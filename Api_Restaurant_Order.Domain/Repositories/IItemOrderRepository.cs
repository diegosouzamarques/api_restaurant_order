using Api_Restaurant_Order.Domain.Entities;

namespace Api_Restaurant_Order.Domain.Repositories
{
    public interface IItemOrderRepository
    {
        Task<ItemOrder> GetByIdAsync(int id);
        Task<ICollection<ItemOrder>> GetItemOrderAsync();
        Task<ItemOrder> CreateAsync(ItemOrder itemOrder);
        Task<ItemOrder> EditAsync(ItemOrder itemOrder);
        Task DeleteAsync(ItemOrder itemOrder);
    }
}
