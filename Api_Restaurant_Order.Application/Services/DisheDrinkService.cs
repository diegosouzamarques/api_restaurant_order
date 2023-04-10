using Api_Restaurant_Order.Application.DTOs;
using Api_Restaurant_Order.Application.DTOs.Validations;
using Api_Restaurant_Order.Application.Services.Interface;
using Api_Restaurant_Order.Domain.Entities;
using Api_Restaurant_Order.Domain.Repositories;
using AutoMapper;

namespace Api_Restaurant_Order.Application.Services
{
    public class DisheDrinkService : IDisheDrinkService
    {
        private readonly IDisheDrinkRepository _disheDrinkRepo;
        private readonly IMapper _mapper;


        public DisheDrinkService(IDisheDrinkRepository disheDrinkrepo, IMapper mapper)
        {
            _disheDrinkRepo = disheDrinkrepo;
            _mapper = mapper;
        }

        public async Task<ResultService<DisheDrinkDTO>> CreateAsync(DisheDrinkDTO disheDrinkDTO)
        {
            if (disheDrinkDTO == null)
                return ResultService.Fail<DisheDrinkDTO>("Objeto dever ser informado");

            var result = new DisheDrinkDTOValidator().Validate(disheDrinkDTO);

            if (!result.IsValid)
                return ResultService.RequestError<DisheDrinkDTO>("Problemas de validade!", result);

            var disheDrink = _mapper.Map<DisheDrink>(disheDrinkDTO);

            var data = await _disheDrinkRepo.CreateAsync(disheDrink);
            return ResultService.Ok<DisheDrinkDTO>(_mapper.Map<DisheDrinkDTO>(data));
        }

        public async Task<ResultService> DeleteAsync(int id)
        {
            var disheDrink = await _disheDrinkRepo.GetByIdAsync(id);

            if (disheDrink == null)
                return ResultService.Fail("Prato ou Bebida não encontrada");

            await _disheDrinkRepo.DeleteAsync(disheDrink);

            return ResultService.Ok("Prato ou Bebida removido");
        }

        public async Task<ResultService<ICollection<DisheDrinkDTO>>> GetAsync()
        {
            var disheDrinks = await _disheDrinkRepo.GetDishesDrinkAsync();
            return ResultService.Ok<ICollection<DisheDrinkDTO>>(_mapper.Map<ICollection<DisheDrinkDTO>>(disheDrinks));
        }

        public async Task<ResultService<DisheDrinkDTO>> GetByIdAsync(int id)
        {
            var disheDrink = await _disheDrinkRepo.GetByIdAsync(id);
            if (disheDrink == null)
                return ResultService.Fail<DisheDrinkDTO>("Prato ou Bebida não encontrado");

            return ResultService.Ok<DisheDrinkDTO>(_mapper.Map<DisheDrinkDTO>(disheDrink));
        }

        public async Task<ResultService<DisheDrinkDTO>> UpdateAsync(DisheDrinkDTO disheDrinkDTO)
        {
            if (disheDrinkDTO == null)
                return ResultService.Fail<DisheDrinkDTO>("Objeto deve ser informado");

            var validation = new DisheDrinkDTOValidator().Validate(disheDrinkDTO);

            if (!validation.IsValid)
                return ResultService.RequestError<DisheDrinkDTO>("Problema com a validadção dos campos", validation);


            var disheDrink = await _disheDrinkRepo.GetByIdAsync(disheDrinkDTO.Id);

            if (disheDrink == null)
                return ResultService.Fail<DisheDrinkDTO>("Prato ou Bebida não encontrado");

            disheDrink = _mapper.Map<DisheDrinkDTO, DisheDrink>(disheDrinkDTO, disheDrink);

            await _disheDrinkRepo.EditAsync(disheDrink);

            return ResultService.Ok<DisheDrinkDTO>(_mapper.Map<DisheDrinkDTO>(disheDrink));
        }
    }
}
