using Api_Restaurant_Order.Domain.Entities;

namespace Api_Restaurant_Order.Domain.Repositories
{
    public interface IItemOrderRepository
    {
        Task<ItemOrder> CreateAsync(ItemOrder itemOrder);
        Task<ICollection<ItemOrder>> GetItemsOrderAsync(int OrderId);
        Task<ItemOrder> GetByIdAsync(int OrderId);       
        Task DeleteAsync(ItemOrder itemOrder);
    }
}
