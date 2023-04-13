using Api_Restaurant_Order.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api_Restaurant_Order.Application.Services.Interface
{
    public interface IItemOrderService
    {
        Task<ResultService<ItemOrderDTO>> CreateAsync(ItemOrderDTO itemOrderDTO);
        Task<ResultService<ICollection<ItemOrderDTO>>> GetItemsOrderAsync(int OrderId);
        Task<ResultService> DeleteAsync(int id);
    }
}
