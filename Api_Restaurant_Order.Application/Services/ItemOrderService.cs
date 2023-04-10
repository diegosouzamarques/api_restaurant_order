using Api_Restaurant_Order.Application.DTOs;
using Api_Restaurant_Order.Application.DTOs.Validations;
using Api_Restaurant_Order.Application.Services.Interface;
using Api_Restaurant_Order.Domain.Entities;
using Api_Restaurant_Order.Domain.Repositories;
using AutoMapper;

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
            var itemOrder = await _itemOrderRepo.GetByIdAsync(id);
            if (itemOrder == null)
                return ResultService.Fail("Item não encontrado");

            await _itemOrderRepo.DeleteAsync(itemOrder);

            return ResultService.Ok("Item removido");
        }

        public async Task<ResultService<ICollection<ItemOrderDTO>>> GetAsync()
        {
            var items = await _itemOrderRepo.GetItemOrderAsync();
            return ResultService.Ok<ICollection<ItemOrderDTO>>(_mapper.Map<ICollection<ItemOrderDTO>>(items));
        }

        public async Task<ResultService<ItemOrderDTO>> GetByIdAsync(int id)
        {
            var itemOrder = await _itemOrderRepo.GetByIdAsync(id);
            if (itemOrder == null)
                return ResultService.Fail<ItemOrderDTO>("Item não encontrado");

            return ResultService.Ok<ItemOrderDTO>(_mapper.Map<ItemOrderDTO>(itemOrder));
        }

        public async Task<ResultService<ItemOrderDTO>> UpdateAsync(ItemOrderDTO itemOrderDTO)
        {
            if (itemOrderDTO == null)
                return ResultService.Fail<ItemOrderDTO>("Objeto deve ser informado");

            var validation = new ItemOrderDTOValidator().Validate(itemOrderDTO);

            if (!validation.IsValid)
                return ResultService.RequestError<ItemOrderDTO>("Problema com a validadção dos campos", validation);


            var item = await _itemOrderRepo.GetByIdAsync(itemOrderDTO.Id);

            if (item == null)
                return ResultService.Fail<ItemOrderDTO>("Item não encontrado");

            item = _mapper.Map<ItemOrderDTO, ItemOrder>(itemOrderDTO, item);

            await _itemOrderRepo.EditAsync(item);

            return ResultService.Ok<ItemOrderDTO>(_mapper.Map<ItemOrderDTO>(item));
        }
    }
}
