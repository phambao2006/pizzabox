using Microsoft.EntityFrameworkCore.Migrations;

namespace PizzaBox.Domain.Migrations
{
  public partial class addPizzarelations : Migration
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
          nullable: true,
          oldClrType: typeof(long),
          oldType: "bigint");

      migrationBuilder.AddColumn<long>(
          name: "SizeEntityID1",
          table: "Pizzas",
          type: "bigint",
          nullable: true);

      migrationBuilder.AddColumn<long>(
          name: "SizeEntityID2",
          table: "Pizzas",
          type: "bigint",
          nullable: true);

      migrationBuilder.CreateIndex(
          name: "IX_Pizzas_SizeEntityID1",
          table: "Pizzas",
          column: "SizeEntityID1");

      migrationBuilder.CreateIndex(
          name: "IX_Pizzas_SizeEntityID2",
          table: "Pizzas",
          column: "SizeEntityID2");

      migrationBuilder.AddForeignKey(
          name: "FK_Pizzas_Size_SizeEntityID",
          table: "Pizzas",
          column: "SizeEntityID",
          principalTable: "Size",
          principalColumn: "EntityID",
          onDelete: ReferentialAction.Restrict);

      migrationBuilder.AddForeignKey(
          name: "FK_Pizzas_Size_SizeEntityID1",
          table: "Pizzas",
          column: "SizeEntityID1",
          principalTable: "Size",
          principalColumn: "EntityID",
          onDelete: ReferentialAction.Restrict);

      migrationBuilder.AddForeignKey(
          name: "FK_Pizzas_Size_SizeEntityID2",
          table: "Pizzas",
          column: "SizeEntityID2",
          principalTable: "Size",
          principalColumn: "EntityID",
          onDelete: ReferentialAction.Restrict);
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.DropForeignKey(
          name: "FK_Pizzas_Size_SizeEntityID",
          table: "Pizzas");

      migrationBuilder.DropForeignKey(
          name: "FK_Pizzas_Size_SizeEntityID1",
          table: "Pizzas");

      migrationBuilder.DropForeignKey(
          name: "FK_Pizzas_Size_SizeEntityID2",
          table: "Pizzas");

      migrationBuilder.DropIndex(
          name: "IX_Pizzas_SizeEntityID1",
          table: "Pizzas");

      migrationBuilder.DropIndex(
          name: "IX_Pizzas_SizeEntityID2",
          table: "Pizzas");

      migrationBuilder.DropColumn(
          name: "SizeEntityID1",
          table: "Pizzas");

      migrationBuilder.DropColumn(
          name: "SizeEntityID2",
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
  }
}
