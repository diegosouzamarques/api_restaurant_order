using Api_Restaurant_Order.Application.Mappings;
using Api_Restaurant_Order.Application.Services;
using Api_Restaurant_Order.Application.Services.Interface;
using Api_Restaurant_Order.Domain.Integrations;
using Api_Restaurant_Order.Domain.Repositories;
using Api_Restaurant_Order.Infra.Data.Context;
using Api_Restaurant_Order.Infra.Data.Integrations;
using Api_Restaurant_Order.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Api_Restaurant_Order.Infra.Ioc
{
    public static class DependencyInjection
    {
        public static IServiceCollection addInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options => options.UseNpgsql(configuration.GetConnectionString("DatabaseDefault")));
            services.AddScoped<IDisheDrinkRepository, DisheDrinkRepository>();
            services.AddScoped<IItemOrderRepository, ItemOrderRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IPhotoDisheDrinkRepository, PhotoDisheDrinkRepository>();
            services.AddScoped<ITableRepository, TableRepository>();
            services.AddScoped<ISaveFile, SaveFile>();

            return services;
        }

        public static IServiceCollection addServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(typeof(DomainToDtoMapping));
            services.AddScoped<IDisheDrinkService, DisheDrinkService>();
            services.AddScoped<IItemOrderService, ItemOrderService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IPhotoDisheDrinkService, PhotoDisheDrinkService>();
            services.AddScoped<ITableService, TableService>();

            return services;
        }
    }
}