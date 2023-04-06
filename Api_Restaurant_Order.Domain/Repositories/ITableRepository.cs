using Api_Restaurant_Order.Domain.Entities;

namespace Api_Restaurant_Order.Domain.Repositories
{
    public interface ITableRepository
    {
        Task<Table> GetByIdAsync(int id);
        Task<ICollection<Table>> GetTableAsync();
        Task<Table> CreateAsync(Table table);
        Task<Table> EditAsync(Table table);
        Task DeleteAsync(Table table);
    }
}
