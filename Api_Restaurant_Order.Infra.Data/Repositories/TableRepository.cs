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
    public class TableRepository : ITableRepository
    {
        private readonly AppDbContext _appDbContext;

        public TableRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<Table> CreateAsync(Table table)
        {
            _appDbContext.Add(table);
            await _appDbContext.SaveChangesAsync();
            return table;
        }

        public async Task DeleteAsync(Table table)
        {
            _appDbContext.Remove(table);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<Table> EditAsync(Table table)
        {
            _appDbContext.Update(table);
            await _appDbContext.SaveChangesAsync();
            return table;
        }

        public async Task<Table> GetByIdAsync(int id)
        {
            return await _appDbContext.Tables.FirstOrDefaultAsync(f => f.Id == id);
        }

        public async Task<ICollection<Table>> GetTableAsync()
        {
            return await _appDbContext.Tables.ToListAsync();
        }
    }
}
