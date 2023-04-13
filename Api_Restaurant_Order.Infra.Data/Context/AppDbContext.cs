using Api_Restaurant_Order.Domain.Entities;
using Api_Restaurant_Order.Domain.Entities.Authorization;
using Microsoft.EntityFrameworkCore;

namespace Api_Restaurant_Order.Infra.Data.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }

        public DbSet<DisheDrink> DisheDrinks { get; set; }
        public DbSet<ItemOrder> ItemOrders { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<PhotoDisheDrink> PhotoDisheDrinks { get; set; }
        public DbSet<Table> Tables { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Permission> Permissions { get; set; }
    }
}