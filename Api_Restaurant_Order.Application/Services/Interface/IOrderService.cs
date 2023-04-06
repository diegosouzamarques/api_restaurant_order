using Api_Restaurant_Order.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api_Restaurant_Order.Application.Services.Interface
{
    public interface IOrderService
    {
        Task<ResultService<OrderDTO>> CreateAsync(OrderDTO orderDTO);
        Task<ResultService<ICollection<OrderDTO>>> GetAsync();
        Task<ResultService<OrderDTO>> GetByIdAsync(int id);
        Task<ResultService<OrderDTO>> UpdateAsync(OrderDTO orderDTO);
        Task<ResultService> DeleteAsync(int id);
    }
}
