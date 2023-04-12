using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Api_Restaurant_Order.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreateBase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DisheDrinks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Kind = table.Column<int>(type: "integer", nullable: false),
                    Title = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    Descript = table.Column<string>(type: "character varying(350)", maxLength: 350, nullable: false),
                    Origin = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    Type = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    Volume = table.Column<decimal>(type: "numeric(10,2)", nullable: true),
                    Price = table.Column<decimal>(type: "numeric(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DisheDrinks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tables",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    AmountPeople = table.Column<int>(type: "integer", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tables", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PhotoDisheDrinks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DisheDrinkId = table.Column<int>(type: "integer", nullable: false),
                    Url = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhotoDisheDrinks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PhotoDisheDrinks_DisheDrinks_DisheDrinkId",
                        column: x => x.DisheDrinkId,
                        principalTable: "DisheDrinks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TableID = table.Column<int>(type: "integer", nullable: false),
                    Requester = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Note = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Tables_TableID",
                        column: x => x.TableID,
                        principalTable: "Tables",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ItemOrders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DisheDrinkId = table.Column<int>(type: "integer", nullable: false),
                    OrderId = table.Column<int>(type: "integer", nullable: false),
                    Price = table.Column<decimal>(type: "numeric(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemOrders_DisheDrinks_DisheDrinkId",
                        column: x => x.DisheDrinkId,
                        principalTable: "DisheDrinks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemOrders_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ItemOrders_DisheDrinkId",
                table: "ItemOrders",
                column: "DisheDrinkId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemOrders_OrderId",
                table: "ItemOrders",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_TableID",
                table: "Orders",
                column: "TableID");

            migrationBuilder.CreateIndex(
                name: "IX_PhotoDisheDrinks_DisheDrinkId",
                table: "PhotoDisheDrinks",
                column: "DisheDrinkId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemOrders");

            migrationBuilder.DropTable(
                name: "PhotoDisheDrinks");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "DisheDrinks");

            migrationBuilder.DropTable(
                name: "Tables");
        }
    }
}
