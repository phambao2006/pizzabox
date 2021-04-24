using Microsoft.EntityFrameworkCore.Migrations;

namespace PizzaBox.Domain.Migrations
{
  public partial class addPizzaDbSet : Migration
  {
    protected override void Up(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.DropForeignKey(
          name: "FK_APizza_Crust_CrustEntityID",
          table: "APizza");

      migrationBuilder.DropForeignKey(
          name: "FK_APizza_Order_OrderEntityID",
          table: "APizza");

      migrationBuilder.DropForeignKey(
          name: "FK_APizza_Size_SizeEntityID",
          table: "APizza");

      migrationBuilder.DropForeignKey(
          name: "FK_Topping_APizza_APizzaEntityID",
          table: "Topping");

      migrationBuilder.DropPrimaryKey(
          name: "PK_APizza",
          table: "APizza");

      migrationBuilder.DeleteData(
          table: "Stores",
          keyColumn: "EntityID",
          keyValue: 1L);

      migrationBuilder.DeleteData(
          table: "Stores",
          keyColumn: "EntityID",
          keyValue: 2L);

      migrationBuilder.RenameTable(
          name: "APizza",
          newName: "Pizzas");

      migrationBuilder.RenameIndex(
          name: "IX_APizza_SizeEntityID",
          table: "Pizzas",
          newName: "IX_Pizzas_SizeEntityID");

      migrationBuilder.RenameIndex(
          name: "IX_APizza_OrderEntityID",
          table: "Pizzas",
          newName: "IX_Pizzas_OrderEntityID");

      migrationBuilder.RenameIndex(
          name: "IX_APizza_CrustEntityID",
          table: "Pizzas",
          newName: "IX_Pizzas_CrustEntityID");

      migrationBuilder.AddPrimaryKey(
          name: "PK_Pizzas",
          table: "Pizzas",
          column: "EntityID");

      migrationBuilder.AddForeignKey(
          name: "FK_Pizzas_Crust_CrustEntityID",
          table: "Pizzas",
          column: "CrustEntityID",
          principalTable: "Crust",
          principalColumn: "EntityID",
          onDelete: ReferentialAction.Restrict);

      migrationBuilder.AddForeignKey(
          name: "FK_Pizzas_Order_OrderEntityID",
          table: "Pizzas",
          column: "OrderEntityID",
          principalTable: "Order",
          principalColumn: "EntityID",
          onDelete: ReferentialAction.Restrict);

      migrationBuilder.AddForeignKey(
          name: "FK_Pizzas_Size_SizeEntityID",
          table: "Pizzas",
          column: "SizeEntityID",
          principalTable: "Size",
          principalColumn: "EntityID",
          onDelete: ReferentialAction.Restrict);

      migrationBuilder.AddForeignKey(
          name: "FK_Topping_Pizzas_APizzaEntityID",
          table: "Topping",
          column: "APizzaEntityID",
          principalTable: "Pizzas",
          principalColumn: "EntityID",
          onDelete: ReferentialAction.Restrict);
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.DropForeignKey(
          name: "FK_Pizzas_Crust_CrustEntityID",
          table: "Pizzas");

      migrationBuilder.DropForeignKey(
          name: "FK_Pizzas_Order_OrderEntityID",
          table: "Pizzas");

      migrationBuilder.DropForeignKey(
          name: "FK_Pizzas_Size_SizeEntityID",
          table: "Pizzas");

      migrationBuilder.DropForeignKey(
          name: "FK_Topping_Pizzas_APizzaEntityID",
          table: "Topping");

      migrationBuilder.DropPrimaryKey(
          name: "PK_Pizzas",
          table: "Pizzas");

      migrationBuilder.RenameTable(
          name: "Pizzas",
          newName: "APizza");

      migrationBuilder.RenameIndex(
          name: "IX_Pizzas_SizeEntityID",
          table: "APizza",
          newName: "IX_APizza_SizeEntityID");

      migrationBuilder.RenameIndex(
          name: "IX_Pizzas_OrderEntityID",
          table: "APizza",
          newName: "IX_APizza_OrderEntityID");

      migrationBuilder.RenameIndex(
          name: "IX_Pizzas_CrustEntityID",
          table: "APizza",
          newName: "IX_APizza_CrustEntityID");

      migrationBuilder.AddPrimaryKey(
          name: "PK_APizza",
          table: "APizza",
          column: "EntityID");

      migrationBuilder.InsertData(
          table: "Stores",
          columns: new[] { "EntityID", "Discriminator", "Name" },
          values: new object[] { 1L, "ChicagoStore", "ChicagoStore" });

      migrationBuilder.InsertData(
          table: "Stores",
          columns: new[] { "EntityID", "Discriminator", "Name" },
          values: new object[] { 2L, "NewYorkStore", "NewYorkStore" });

      migrationBuilder.AddForeignKey(
          name: "FK_APizza_Crust_CrustEntityID",
          table: "APizza",
          column: "CrustEntityID",
          principalTable: "Crust",
          principalColumn: "EntityID",
          onDelete: ReferentialAction.Restrict);

      migrationBuilder.AddForeignKey(
          name: "FK_APizza_Order_OrderEntityID",
          table: "APizza",
          column: "OrderEntityID",
          principalTable: "Order",
          principalColumn: "EntityID",
          onDelete: ReferentialAction.Restrict);

      migrationBuilder.AddForeignKey(
          name: "FK_APizza_Size_SizeEntityID",
          table: "APizza",
          column: "SizeEntityID",
          principalTable: "Size",
          principalColumn: "EntityID",
          onDelete: ReferentialAction.Restrict);

      migrationBuilder.AddForeignKey(
          name: "FK_Topping_APizza_APizzaEntityID",
          table: "Topping",
          column: "APizzaEntityID",
          principalTable: "APizza",
          principalColumn: "EntityID",
          onDelete: ReferentialAction.Restrict);
    }
  }
}
