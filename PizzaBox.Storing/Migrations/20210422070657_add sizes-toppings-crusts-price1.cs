using Microsoft.EntityFrameworkCore.Migrations;

namespace PizzaBox.Storing.Migrations
{
    public partial class addsizestoppingscrustsprice1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pizzas_Sizes_SizeEntityID",
                table: "Pizzas");

            migrationBuilder.DropForeignKey(
                name: "FK_Toppings_Pizzas_APizzaEntityID",
                table: "Toppings");

            migrationBuilder.DropIndex(
                name: "IX_Toppings_APizzaEntityID",
                table: "Toppings");

            migrationBuilder.DeleteData(
                table: "Crusts",
                keyColumn: "EntityID",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Crusts",
                keyColumn: "EntityID",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Crusts",
                keyColumn: "EntityID",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "EntityID",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "EntityID",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "EntityID",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Toppings",
                keyColumn: "EntityID",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Toppings",
                keyColumn: "EntityID",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Toppings",
                keyColumn: "EntityID",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Toppings",
                keyColumn: "EntityID",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "Toppings",
                keyColumn: "EntityID",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "Toppings",
                keyColumn: "EntityID",
                keyValue: 6L);

            migrationBuilder.DropColumn(
                name: "APizzaEntityID",
                table: "Toppings");

            migrationBuilder.AlterColumn<long>(
                name: "SizeEntityID",
                table: "Pizzas",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.CreateTable(
                name: "APizzaTopping",
                columns: table => new
                {
                    PizzasEntityID = table.Column<long>(type: "bigint", nullable: false),
                    ToppingsEntityID = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_APizzaTopping", x => new { x.PizzasEntityID, x.ToppingsEntityID });
                    table.ForeignKey(
                        name: "FK_APizzaTopping_Pizzas_PizzasEntityID",
                        column: x => x.PizzasEntityID,
                        principalTable: "Pizzas",
                        principalColumn: "EntityID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_APizzaTopping_Toppings_ToppingsEntityID",
                        column: x => x.ToppingsEntityID,
                        principalTable: "Toppings",
                        principalColumn: "EntityID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_APizzaTopping_ToppingsEntityID",
                table: "APizzaTopping",
                column: "ToppingsEntityID");

            migrationBuilder.AddForeignKey(
                name: "FK_Pizzas_Sizes_SizeEntityID",
                table: "Pizzas",
                column: "SizeEntityID",
                principalTable: "Sizes",
                principalColumn: "EntityID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pizzas_Sizes_SizeEntityID",
                table: "Pizzas");

            migrationBuilder.DropTable(
                name: "APizzaTopping");

            migrationBuilder.AddColumn<long>(
                name: "APizzaEntityID",
                table: "Toppings",
                type: "bigint",
                nullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "SizeEntityID",
                table: "Pizzas",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Crusts",
                columns: new[] { "EntityID", "Name", "Price" },
                values: new object[,]
                {
                    { 1L, "Original", 2m },
                    { 2L, "Thin Crust", 2m },
                    { 3L, "Stuffed Crust", 3m }
                });

            migrationBuilder.InsertData(
                table: "Sizes",
                columns: new[] { "EntityID", "Name", "Price" },
                values: new object[,]
                {
                    { 1L, "Small", 2m },
                    { 2L, "Medium", 3m },
                    { 3L, "Large", 4m }
                });

            migrationBuilder.InsertData(
                table: "Toppings",
                columns: new[] { "EntityID", "APizzaEntityID", "Name", "Price" },
                values: new object[,]
                {
                    { 1L, null, "Chicken", 2m },
                    { 2L, null, "Pork", 2m },
                    { 3L, null, "Beef", 2m },
                    { 4L, null, "Mushroom", 2m },
                    { 5L, null, "Pineapple", 2m },
                    { 6L, null, "Bell Pepper", 2m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Toppings_APizzaEntityID",
                table: "Toppings",
                column: "APizzaEntityID");

            migrationBuilder.AddForeignKey(
                name: "FK_Pizzas_Sizes_SizeEntityID",
                table: "Pizzas",
                column: "SizeEntityID",
                principalTable: "Sizes",
                principalColumn: "EntityID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Toppings_Pizzas_APizzaEntityID",
                table: "Toppings",
                column: "APizzaEntityID",
                principalTable: "Pizzas",
                principalColumn: "EntityID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
