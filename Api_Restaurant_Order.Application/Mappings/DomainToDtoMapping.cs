using Api_Restaurant_Order.Application.DTOs;
using Api_Restaurant_Order.Application.DTOs.Authorization;
using Api_Restaurant_Order.Domain.Entities;
using Api_Restaurant_Order.Domain.Entities.Authorization;
using AutoMapper;

namespace Api_Restaurant_Order.Application.Mappings
{
    public class DomainToDtoMapping : Profile
    {
        public DomainToDtoMapping() {
            CreateMap<DisheDrink, DisheDrinkDTO>();
            CreateMap<ItemOrder, ItemOrderDTO>();
            CreateMap<Order, OrderDTO>();
            CreateMap<PhotoDisheDrink, PhotoDisheDrinkViewDTO>();
            CreateMap<Table, TableDTO>();
            CreateMap<User, UserDTO>();
            CreateMap<Permission, PermissionDTO>();
        }
    }
}
