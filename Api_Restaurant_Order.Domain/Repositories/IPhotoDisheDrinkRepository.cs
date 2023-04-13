using Api_Restaurant_Order.Domain.Entities;

namespace Api_Restaurant_Order.Domain.Repositories
{
    public interface IPhotoDisheDrinkRepository
    {
        Task<PhotoDisheDrink> GetByIdAsync(int id);
        Task<ICollection<PhotoDisheDrink>> GetPhotoDisheDrinkAsync(int disheDrinkId);
        Task<PhotoDisheDrink> CreateAsync(PhotoDisheDrink photoDisheDrink);
        Task DeleteAsync(PhotoDisheDrink photoDisheDrink);
    }
}
