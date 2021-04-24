using Microsoft.EntityFrameworkCore.Migrations;

namespace PizzaBox.Domain.Migrations
{
  public partial class addPizzaSizeEmtityID : Migration
  {
    protected override void Up(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.DropForeignKey(
          name: "FK_Pizzas_Size_SizeEntityID",
          table: "Pizzas");

      migrationBuilder.AlterColumn<long>(
          name: "SizeEntityID",
          table: "Pizzas",
          type: "bigint",
          nullable: false,
          defaultValue: 0L,
          oldClrType: typeof(long),
          oldType: "bigint",
          oldNullable: true);

      migrationBuilder.AddForeignKey(
          name: "FK_Pizzas_Size_SizeEntityID",
          table: "Pizzas",
          column: "SizeEntityID",
          principalTable: "Size",
          principalColumn: "EntityID",
          onDelete: ReferentialAction.Cascade);
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.DropForeignKey(
          name: "FK_Pizzas_Size_SizeEntityID",
          table: "Pizzas");

      migrationBuilder.AlterColumn<long>(
          name: "SizeEntityID",
          table: "Pizzas",
          type: "bigint",
          nullable: true,
          oldClrType: typeof(long),
          oldType: "bigint");

      migrationBuilder.AddForeignKey(
          name: "FK_Pizzas_Size_SizeEntityID",
          table: "Pizzas",
          column: "SizeEntityID",
          principalTable: "Size",
          principalColumn: "EntityID",
          onDelete: ReferentialAction.Restrict);
    }
  }
}
