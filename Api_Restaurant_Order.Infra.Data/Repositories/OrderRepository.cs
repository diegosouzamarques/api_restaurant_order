using Api_Restaurant_Order.Domain.Entities;
using Api_Restaurant_Order.Domain.Repositories;
using Api_Restaurant_Order.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api_Restaurant_Order.Infra.Data.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext _appDbContext;

        public OrderRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<Order> CreateAsync(Order order)
        {
            _appDbContext.Add(order);
            await _appDbContext.SaveChangesAsync();
            return order;
        }

        public async Task DeleteAsync(Order order)
        {
            _appDbContext.Remove(order);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<Order> EditAsync(Order order)
        {
            _appDbContext.Update(order);
            await _appDbContext.SaveChangesAsync();
            return order;
        }

        public async Task<Order> GetByIdAsync(int id)
        {
            return await _appDbContext.Orders.FirstOrDefaultAsync(f => f.Id == id);
        }

        public async Task<ICollection<Order>> GetOrderAsync()
        {
            return await _appDbContext.Orders.ToListAsync();
        }
    }
}
