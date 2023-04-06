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

        public async Task<PhotoDisheDrink> EditAsync(PhotoDisheDrink photoDisheDrink)
        {
            _appDbContext.Update(photoDisheDrink);
            await _appDbContext.SaveChangesAsync();
            return photoDisheDrink;
        }

        public async Task<PhotoDisheDrink> GetByIdAsync(int id)
        {
            return await _appDbContext.PhotoDisheDrinks.FirstOrDefaultAsync(f => f.Id == id);
        }

        public async Task<ICollection<PhotoDisheDrink>> GetPhotoDisheDrinkAsync()
        {
            return await _appDbContext.PhotoDisheDrinks.ToListAsync();
        }
    }
}
