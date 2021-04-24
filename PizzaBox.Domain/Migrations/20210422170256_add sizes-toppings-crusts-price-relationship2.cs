using Microsoft.EntityFrameworkCore.Migrations;

namespace PizzaBox.Domain.Migrations
{
  public partial class addsizestoppingscrustspricerelationship2 : Migration
  {
    protected override void Up(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.DropForeignKey(
          name: "FK_Pizzas_Crusts_CrustEntityID1",
          table: "Pizzas");

      migrationBuilder.DropForeignKey(
          name: "FK_Pizzas_Sizes_SizeEntityID1",
          table: "Pizzas");

      migrationBuilder.DropIndex(
          name: "IX_Pizzas_CrustEntityID1",
          table: "Pizzas");

      migrationBuilder.DropIndex(
          name: "IX_Pizzas_SizeEntityID1",
          table: "Pizzas");

      migrationBuilder.DropColumn(
          name: "CrustEntityID1",
          table: "Pizzas");

      migrationBuilder.DropColumn(
          name: "SizeEntityID1",
          table: "Pizzas");
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
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

      migrationBuilder.CreateIndex(
          name: "IX_Pizzas_CrustEntityID1",
          table: "Pizzas",
          column: "CrustEntityID1");

      migrationBuilder.CreateIndex(
          name: "IX_Pizzas_SizeEntityID1",
          table: "Pizzas",
          column: "SizeEntityID1");

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
    }
  }
}
