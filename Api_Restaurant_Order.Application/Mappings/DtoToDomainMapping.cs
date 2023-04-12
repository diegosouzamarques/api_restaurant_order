using Api_Restaurant_Order.Application.DTOs;
using Api_Restaurant_Order.Domain.Entities;
using AutoMapper;

namespace Api_Restaurant_Order.Application.Mappings
{
    public class DtoToDomainMapping: Profile
    {
        public DtoToDomainMapping() {
            CreateMap<DisheDrinkDTO, DisheDrink>();
            CreateMap<ItemOrderDTO, ItemOrder>();
            CreateMap<OrderDTO, Order>();
            CreateMap<TableDTO, Table>();
        }
    }
}
