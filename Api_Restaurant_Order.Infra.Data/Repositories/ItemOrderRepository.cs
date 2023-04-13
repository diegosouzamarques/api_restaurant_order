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

        public async Task<ItemOrder> GetByIdAsync(int itemId)
        {
            return await _appDbContext.ItemOrders.FirstOrDefaultAsync(w => w.Id == itemId);
        }

        public async Task<ICollection<ItemOrder>> GetItemsOrderAsync(int OrderId)
        {
            return await _appDbContext.ItemOrders.Where(w => w.OrderId == OrderId).ToListAsync();
                
        }
    }
}
