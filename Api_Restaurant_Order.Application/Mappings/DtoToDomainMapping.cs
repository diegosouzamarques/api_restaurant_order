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
    public class DtoToDomainMapping: Profile
    {
        public DtoToDomainMapping() {
            CreateMap<DisheDrinkDTO, DisheDrink>();
            CreateMap<ItemOrderDTO, ItemOrder>();
            CreateMap<OrderDTO, Order>();
            CreateMap<PhotoDisheDrinkDTO, PhotoDisheDrink>();
            CreateMap<TableDTO, Table>();
        }
    }
}
