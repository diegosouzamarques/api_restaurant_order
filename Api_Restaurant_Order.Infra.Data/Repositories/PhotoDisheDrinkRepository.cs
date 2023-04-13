using Api_Restaurant_Order.Domain.Entities;
using Api_Restaurant_Order.Domain.Repositories;
using Api_Restaurant_Order.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Api_Restaurant_Order.Infra.Data.Repositories
{
    public class PhotoDisheDrinkRepository : IPhotoDisheDrinkRepository
    {
        private readonly AppDbContext _appDbContext;

        public PhotoDisheDrinkRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<PhotoDisheDrink> CreateAsync(PhotoDisheDrink photoDisheDrink)
        {
            _appDbContext.Add(photoDisheDrink);
            await _appDbContext.SaveChangesAsync();
            return photoDisheDrink;
        }

        public async Task DeleteAsync(PhotoDisheDrink photoDisheDrink)
        {
            _appDbContext.Remove(photoDisheDrink);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<PhotoDisheDrink> GetByIdAsync(int id)
        {
            return await _appDbContext.PhotoDisheDrinks.FirstOrDefaultAsync(f => f.Id == id);
        }

        public async Task<ICollection<PhotoDisheDrink>> GetPhotoDisheDrinkAsync(int disheDrinkId)
        {
            return await _appDbContext.PhotoDisheDrinks.Where(w => w.DisheDrinkId == disheDrinkId).ToListAsync();
        }
    }
}
