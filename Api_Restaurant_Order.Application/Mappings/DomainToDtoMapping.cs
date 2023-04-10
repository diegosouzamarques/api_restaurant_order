using Api_Restaurant_Order.Application.DTOs;
using Api_Restaurant_Order.Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api_Restaurant_Order.Application.Mappings
{
    public class DomainToDtoMapping : Profile
    {
        public DomainToDtoMapping() {
            CreateMap<DisheDrink, DisheDrinkDTO>();
            CreateMap<ItemOrder, ItemOrderDTO>();
            CreateMap<Order, OrderDTO>();
            CreateMap<PhotoDisheDrink, PhotoDisheDrinkDTO>();
            CreateMap<Table, TableDTO>();
        }
    }
}
