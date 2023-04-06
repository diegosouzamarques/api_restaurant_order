using Api_Restaurant_Order.Domain.Entities;
using Api_Restaurant_Order.Domain.Repositories;
using Api_Restaurant_Order.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Api_Restaurant_Order.Infra.Data.Repositories
{
    public class ItemOrderRepository : IItemOrderRepository
    {
        private readonly AppDbContext _appDbContext;

        public ItemOrderRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<ItemOrder> CreateAsync(ItemOrder itemOrder)
        {
            _appDbContext.Add(itemOrder);
            await _appDbContext.SaveChangesAsync();
            return itemOrder;
        }

        public async Task DeleteAsync(ItemOrder itemOrder)
        {
            _appDbContext.Remove(itemOrder);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<ItemOrder> EditAsync(ItemOrder itemOrder)
        {
            _appDbContext.Update(itemOrder);
            await _appDbContext.SaveChangesAsync();
            return itemOrder;
        }

        public async Task<ItemOrder> GetByIdAsync(int id)
        {
            return await _appDbContext.ItemOrders.FirstOrDefaultAsync(f => f.Id == id);
        }

        public async Task<ICollection<ItemOrder>> GetItemOrderAsync()
        {
            return await _appDbContext.ItemOrders.ToListAsync();
        }
    }
}
