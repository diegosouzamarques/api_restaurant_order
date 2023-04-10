using Api_Restaurant_Order.Application.DTOs;
using Api_Restaurant_Order.Application.DTOs.Validations;
using Api_Restaurant_Order.Application.Services.Interface;
using Api_Restaurant_Order.Domain.Entities;
using Api_Restaurant_Order.Domain.Repositories;
using AutoMapper;

namespace Api_Restaurant_Order.Application.Services
{
    public class TableService : ITableService
    {
        private readonly ITableRepository _tableRepository;
        private readonly IMapper _mapper;

        public TableService(ITableRepository tableRepository, IMapper mapper)
        {
            _tableRepository = tableRepository;
            _mapper = mapper;
        }

        public async Task<ResultService<TableDTO>> CreateAsync(TableDTO tableDTO)
        {
            if (tableDTO == null)
                return ResultService.Fail<TableDTO>("Objeto dever ser informado");

            var result = new TableDTOValidator().Validate(tableDTO);

            if (!result.IsValid)
                return ResultService.RequestError<TableDTO>("Problemas de validade!", result);

            var table = _mapper.Map<Table>(tableDTO);

            var data = await _tableRepository.CreateAsync(table);
            return ResultService.Ok(_mapper.Map<TableDTO>(data));
        }

        public async Task<ResultService> DeleteAsync(int id)
        {
            var table = await _tableRepository.GetByIdAsync(id);
            if (table == null)
                return ResultService.Fail("Mesa não encontrada");

            await _tableRepository.DeleteAsync(table);

            return ResultService.Ok("Mesa removida");
        }

        public async Task<ResultService<ICollection<TableDTO>>> GetAsync()
        {
            var tables = await _tableRepository.GetTableAsync();
            return ResultService.Ok(_mapper.Map<ICollection<TableDTO>>(tables));
        }

        public async Task<ResultService<TableDTO>> GetByIdAsync(int id)
        {
            var table = await _tableRepository.GetByIdAsync(id);
            if (table == null)
                return ResultService.Fail<TableDTO>("Mesa não encontrada");

            return ResultService.Ok(_mapper.Map<TableDTO>(table));
        }

        public async Task<ResultService<TableDTO>> UpdateAsync(TableDTO tableDTO)
        {
            if (tableDTO == null)
                return ResultService.Fail<TableDTO>("Objeto deve ser informado");

            var validation = new TableDTOValidator().Validate(tableDTO);

            if (!validation.IsValid)
                return ResultService.RequestError<TableDTO>("Problema com a validadção dos campos", validation);


            var table = await _tableRepository.GetByIdAsync(tableDTO.Id);

            if (table == null)
                return ResultService.Fail<TableDTO>("Mesa não encontrada");

            table = _mapper.Map(tableDTO, table);

            await _tableRepository.EditAsync(table);

            return ResultService.Ok(_mapper.Map<TableDTO>(table));
        }
    }
}
