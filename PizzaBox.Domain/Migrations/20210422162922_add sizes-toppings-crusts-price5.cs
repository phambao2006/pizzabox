using Microsoft.EntityFrameworkCore.Migrations;

namespace PizzaBox.Domain.Migrations
{
  public partial class addsizestoppingscrustsprice5 : Migration
  {
    protected override void Up(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.DropTable(
          name: "APizzaTopping");

      migrationBuilder.AddColumn<long>(
          name: "APizzaEntityID",
          table: "Toppings",
          type: "bigint",
          nullable: true);

      migrationBuilder.AddColumn<long>(
          name: "CrustEntityID1",
          table: "Pizzas",
          type: "bigint",
          nullable: true);

      migrationBuilder.AddColumn<long>(
          name: "SizeEntityID1",
          table: "Pizzas",
          type: "bigint",
          nullable: true);

      migrationBuilder.AddColumn<long>(
          name: "AStoreEntityID",
          table: "Order",
          type: "bigint",
          nullable: true);

      migrationBuilder.CreateIndex(
          name: "IX_Toppings_APizzaEntityID",
          table: "Toppings",
          column: "APizzaEntityID");

      migrationBuilder.CreateIndex(
          name: "IX_Pizzas_CrustEntityID1",
          table: "Pizzas",
          column: "CrustEntityID1");

      migrationBuilder.CreateIndex(
          name: "IX_Pizzas_SizeEntityID1",
          table: "Pizzas",
          column: "SizeEntityID1");

      migrationBuilder.CreateIndex(
          name: "IX_Order_AStoreEntityID",
          table: "Order",
          column: "AStoreEntityID");

      migrationBuilder.AddForeignKey(
          name: "FK_Order_Stores_AStoreEntityID",
          table: "Order",
          column: "AStoreEntityID",
          principalTable: "Stores",
          principalColumn: "EntityID",
          onDelete: ReferentialAction.Restrict);

      migrationBuilder.AddForeignKey(
          name: "FK_Pizzas_Crusts_CrustEntityID1",
          table: "Pizzas",
          column: "CrustEntityID1",
          principalTable: "Crusts",
          principalColumn: "EntityID",
          onDelete: ReferentialAction.Restrict);

      migrationBuilder.AddForeignKey(
          name: "FK_Pizzas_Sizes_SizeEntityID1",
          table: "Pizzas",
          column: "SizeEntityID1",
          principalTable: "Sizes",
          principalColumn: "EntityID",
          onDelete: ReferentialAction.Restrict);

      migrationBuilder.AddForeignKey(
          name: "FK_Toppings_Pizzas_APizzaEntityID",
          table: "Toppings",
          column: "APizzaEntityID",
          principalTable: "Pizzas",
          principalColumn: "EntityID",
          onDelete: ReferentialAction.Restrict);
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.DropForeignKey(
          name: "FK_Order_Stores_AStoreEntityID",
          table: "Order");

      migrationBuilder.DropForeignKey(
          name: "FK_Pizzas_Crusts_CrustEntityID1",
          table: "Pizzas");

      migrationBuilder.DropForeignKey(
          name: "FK_Pizzas_Sizes_SizeEntityID1",
          table: "Pizzas");

      migrationBuilder.DropForeignKey(
          name: "FK_Toppings_Pizzas_APizzaEntityID",
          table: "Toppings");

      migrationBuilder.DropIndex(
          name: "IX_Toppings_APizzaEntityID",
          table: "Toppings");

      migrationBuilder.DropIndex(
          name: "IX_Pizzas_CrustEntityID1",
          table: "Pizzas");

      migrationBuilder.DropIndex(
          name: "IX_Pizzas_SizeEntityID1",
          table: "Pizzas");

      migrationBuilder.DropIndex(
          name: "IX_Order_AStoreEntityID",
          table: "Order");

      migrationBuilder.DropColumn(
          name: "APizzaEntityID",
          table: "Toppings");

      migrationBuilder.DropColumn(
          name: "CrustEntityID1",
          table: "Pizzas");

      migrationBuilder.DropColumn(
          name: "SizeEntityID1",
          table: "Pizzas");

      migrationBuilder.DropColumn(
          name: "AStoreEntityID",
          table: "Order");

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
    }
  }
}
