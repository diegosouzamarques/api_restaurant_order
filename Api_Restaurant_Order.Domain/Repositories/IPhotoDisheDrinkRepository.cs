using Api_Restaurant_Order.Domain.Entities;

namespace Api_Restaurant_Order.Domain.Repositories
{
    public interface IPhotoDisheDrinkRepository
    {
        Task<PhotoDisheDrink> GetByIdAsync(int id);
        Task<ICollection<PhotoDisheDrink>> GetPhotoDisheDrinkAsync();
        Task<PhotoDisheDrink> CreateAsync(PhotoDisheDrink photoDisheDrink);
        Task<PhotoDisheDrink> EditAsync(PhotoDisheDrink photoDisheDrink);
        Task DeleteAsync(PhotoDisheDrink photoDisheDrink);
    }
}
