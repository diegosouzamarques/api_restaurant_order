using Api_Restaurant_Order.Domain.Entities;
using Api_Restaurant_Order.Domain.Repositories;
using Api_Restaurant_Order.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Api_Restaurant_Order.Infra.Data.Repositories
{
    public class DisheDrinkRepository : IDisheDrinkRepository
    {
        private readonly AppDbContext _appDbContext;

        public DisheDrinkRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<DisheDrink> CreateAsync(DisheDrink disheDrink)
        {
            _appDbContext.Add(disheDrink);
            await _appDbContext.SaveChangesAsync();
            return disheDrink;
        }

        public async Task DeleteAsync(DisheDrink dishesDrink)
        {
            _appDbContext.Remove(dishesDrink);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<DisheDrink> EditAsync(DisheDrink dishesDrink)
        {
            _appDbContext.Update(dishesDrink);
            await _appDbContext.SaveChangesAsync();
            return dishesDrink;
        }

        public async Task<DisheDrink> GetByIdAsync(int id)
        {
            return await _appDbContext.DisheDrinks.FirstOrDefaultAsync(f => f.Id == id);
        }

        public async Task<ICollection<DisheDrink>> GetDishesDrinkAsync()
        {     
           return await _appDbContext.DisheDrinks.ToListAsync();        
        }
    }
}
