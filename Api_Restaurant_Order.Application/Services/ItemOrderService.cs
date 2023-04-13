using Api_Restaurant_Order.Application.DTOs;
using Api_Restaurant_Order.Application.DTOs.Validations;
using Api_Restaurant_Order.Application.Services.Interface;
using Api_Restaurant_Order.Domain.Entities;
using Api_Restaurant_Order.Domain.Enumerator;
using Api_Restaurant_Order.Domain.Repositories;
using AutoMapper;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Api_Restaurant_Order.Application.Services
{
    public class ItemOrderService : IItemOrderService
    {
        private readonly IItemOrderRepository _itemOrderRepo;
        private readonly IMapper _mapper;


        public ItemOrderService(IItemOrderRepository itemOrderRepo, IMapper mapper)
        {
            _itemOrderRepo = itemOrderRepo;
            _mapper = mapper;
        }
        public async Task<ResultService<ItemOrderDTO>> CreateAsync(ItemOrderDTO itemOrderDTO)
        {
            if (itemOrderDTO == null)
                return ResultService.Fail<ItemOrderDTO>("Objeto dever ser informado");

            var result = new ItemOrderDTOValidator().Validate(itemOrderDTO);

            if (!result.IsValid)
                return ResultService.RequestError<ItemOrderDTO>("Problemas de validade!", result);

            var itemOrder = _mapper.Map<ItemOrder>(itemOrderDTO);

            var data = await _itemOrderRepo.CreateAsync(itemOrder);
            return ResultService.Ok<ItemOrderDTO>(_mapper.Map<ItemOrderDTO>(data));
        }

        public async Task<ResultService> DeleteAsync(int id)
        {
            if (id <= 0)
                throw new Exception("Id do item deve ser informado");

            var itemOrder = await _itemOrderRepo.GetByIdAsync(id);
            if (itemOrder == null)
                return ResultService.Fail("Item não encontrado");

            await _itemOrderRepo.DeleteAsync(itemOrder);

            return ResultService.Ok("Item removido");
        }

        public async Task<ResultService<ICollection<ItemOrderDTO>>> GetItemsOrderAsync(int OrderId)
        {
            if (OrderId <= 0)
                throw new Exception("Id do pedido deve ser informado");

            var itemsOrder = await _itemOrderRepo.GetItemsOrderAsync(OrderId);
            if (itemsOrder == null)
                return ResultService.Fail<ICollection<ItemOrderDTO>> ("Itens não encontrado");

            return ResultService.Ok<ICollection<ItemOrderDTO>>(_mapper.Map<ICollection<ItemOrderDTO>>(OrderId));
        }
    }
}
