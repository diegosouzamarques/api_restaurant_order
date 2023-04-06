using Api_Restaurant_Order.Domain.Entities;

namespace Api_Restaurant_Order.Domain.Repositories
{
    public interface IOrderRepository
    {
        Task<Order> GetByIdAsync(int id);
        Task<ICollection<Order>> GetOrderAsync();
        Task<Order> CreateAsync(Order order);
        Task<Order> EditAsync(Order order);
        Task DeleteAsync(Order order);
    }
}
