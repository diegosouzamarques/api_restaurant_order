using Api_Restaurant_Order.Application.DTOs;


namespace Api_Restaurant_Order.Application.Services.Interface
{
    public interface IDisheDrinkService
    {
        Task<ResultService<DisheDrinkDTO>> CreateAsync(DisheDrinkDTO disheDrinkDTO);
        Task<ResultService<ICollection<DisheDrinkDTO>>> GetAsync();
        Task<ResultService<DisheDrinkDTO>> GetByIdAsync(int id);
        Task<ResultService<DisheDrinkDTO>> UpdateAsync(DisheDrinkDTO disheDrinkDTO);
        Task<ResultService> DeleteAsync(int id);
    }
}
