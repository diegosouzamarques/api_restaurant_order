using Api_Restaurant_Order.Application.DTOs;
using Api_Restaurant_Order.Application.DTOs.Validations;
using Api_Restaurant_Order.Application.Services.Interface;
using Api_Restaurant_Order.Domain.Entities;
using Api_Restaurant_Order.Domain.Repositories;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api_Restaurant_Order.Application.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepo;
        private readonly IMapper _mapper;

        public OrderService(IOrderRepository orderRepo, IMapper mapper)
        {
            _orderRepo = orderRepo;
            _mapper = mapper;
        }

        public async Task<ResultService<OrderDTO>> CreateAsync(OrderDTO orderDTO)
        {
            if (orderDTO == null)
                return ResultService.Fail<OrderDTO>("Objeto dever ser informado");

            var result = new OrderDTOValidator().Validate(orderDTO);

            if (!result.IsValid)
                return ResultService.RequestError<OrderDTO>("Problemas de validade!", result);

            var order = _mapper.Map<Order>(orderDTO);

            var data = await _orderRepo.CreateAsync(order);
            return ResultService.Ok<OrderDTO>(_mapper.Map<OrderDTO>(data));
        }

        public async Task<ResultService> DeleteAsync(int id)
        {
            var order = await _orderRepo.GetByIdAsync(id);
            if (order == null)
                return ResultService.Fail("Pedido não encontrada");

            await _orderRepo.DeleteAsync(order);

            return ResultService.Ok("Pedido removido");
        }

        public async Task<ResultService<ICollection<OrderDTO>>> GetAsync()
        {
            var orders = await _orderRepo.GetOrderAsync();
            return ResultService.Ok<ICollection<OrderDTO>>(_mapper.Map<ICollection<OrderDTO>>(orders));
        }

        public async Task<ResultService<OrderDTO>> GetByIdAsync(int id)
        {
            var order = await _orderRepo.GetByIdAsync(id);
            if (order == null)
                return ResultService.Fail<OrderDTO>("Pedido não encontrado");

            return ResultService.Ok<OrderDTO>(_mapper.Map<OrderDTO>(order));
        }

        public async Task<ResultService<OrderDTO>> UpdateAsync(OrderDTO orderDTO)
        {
            if (orderDTO == null)
                return ResultService.Fail<OrderDTO>("Objeto deve ser informado");

            var validation = new OrderDTOValidator().Validate(orderDTO);

            if (!validation.IsValid)
                return ResultService.RequestError<OrderDTO>("Problema com a validadção dos campos", validation);


            var order = await _orderRepo.GetByIdAsync(orderDTO.Id);

            if (order == null)
                return ResultService.Fail<OrderDTO>("Pedido não encontrado");

            order = _mapper.Map<OrderDTO, Order>(orderDTO, order);

            await _orderRepo.EditAsync(order);

            return ResultService.Ok<OrderDTO>(_mapper.Map<OrderDTO>(order));
        }
    }
}
