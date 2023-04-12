using Api_Restaurant_Order.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Api_Restaurant_Order.Infra.Data.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }

        public DbSet<DisheDrink> DisheDrinks { get; set; }
        public DbSet<ItemOrder> ItemOrders { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<PhotoDisheDrink> PhotoDisheDrinks { get; set; }
        public DbSet<Table> Tables { get; set; }
    }
}