using Api_Restaurant_Order.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api_Restaurant_Order.Application.Services.Interface
{
    public interface IPhotoDisheDrinkService
    {
        Task<ResultService<PhotoDisheDrinkDTO>> CreateAsync(PhotoDisheDrinkDTO photoDisheDrinkDTO);
        Task<ResultService<ICollection<PhotoDisheDrinkDTO>>> GetAsync();
        Task<ResultService<PhotoDisheDrinkDTO>> GetByIdAsync(int id);
        Task<ResultService<PhotoDisheDrinkDTO>> UpdateAsync(PhotoDisheDrinkDTO photoDisheDrinkDTO);
        Task<ResultService> DeleteAsync(int id);
    }
}
