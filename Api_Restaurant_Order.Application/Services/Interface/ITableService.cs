
using Api_Restaurant_Order.Application.DTOs;

namespace Api_Restaurant_Order.Application.Services.Interface
{
    public interface ITableService
    {
        Task<ResultService<TableDTO>> CreateAsync(TableDTO tableDTO);
        Task<ResultService<ICollection<TableDTO>>> GetAsync();
        Task<ResultService<TableDTO>> GetByIdAsync(int id);
        Task<ResultService<TableDTO>> UpdateAsync(TableDTO tableDTO);
        Task<ResultService> DeleteAsync(int id);
    }
}
