using Api_Restaurant_Order.Domain.Entities.Authorization;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api_Restaurant_Order.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedPermission : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData("Permissions",
           columns: new[] { nameof(Permission.VisualName), nameof(Permission.PermissionName) },
           values: new object[,] {
                   { "administrator", "admin"},

                   { "Dishe & Drink Register", "DisheDrink_Register"},
                   { "Dishe & Drink Search", "DisheDrink_Search"},
                   { "Dishe & Drink Delete", "DisheDrink_Delete"},
                   { "Dishe & Drink Edit", "DisheDrink_Edit"},

                   { "Photo Dishe & Drink Register", "Photo_Register"},
                   { "Photo Dishe & Drink Search", "Photo_Search"},
                   { "Photo Dishe & Drink Delete", "Photo_Delete"},

                   { "Table Register", "Table_Register"},
                   { "Table Search", "Table_Search"},
                   { "Table Delete", "Table_Delete"},
                   { "Table Edit", "Table_Edit"},

                   { "Order Register", "Order_Register"},
                   { "Order Search", "Order_Search"},
                   { "Order Delete", "Order_Delete"},
                   { "Order Edit", "Order_Edit"},

                   { "Item Register", "Item_Register"},
                   { "Item Search", "Item_Search"},
                   { "Item Delete", "Item_Delete"},
                   { "Item Edit", "Item_Edit"}
           });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
