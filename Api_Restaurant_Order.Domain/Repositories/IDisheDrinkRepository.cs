using Api_Restaurant_Order.Domain.Entities;

namespace Api_Restaurant_Order.Domain.Repositories
{
    public interface IDisheDrinkRepository
    {
        Task<DisheDrink> GetByIdAsync(int id);
        Task<ICollection<DisheDrink>> GetDishesDrinkAsync();
        Task<DisheDrink> CreateAsync(DisheDrink disheDrink);
        Task<DisheDrink> EditAsync(DisheDrink dishesDrink);
        Task DeleteAsync(DisheDrink dishesDrink);

    }
}
