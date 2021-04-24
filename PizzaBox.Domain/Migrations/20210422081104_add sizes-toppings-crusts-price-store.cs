using Microsoft.EntityFrameworkCore.Migrations;

namespace PizzaBox.Domain.Migrations
{
  public partial class addsizestoppingscrustspricestore : Migration
  {
    protected override void Up(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.InsertData(
          table: "Stores",
          columns: new[] { "EntityID", "Discriminator", "Name" },
          values: new object[] { 1L, "ChicagoStore", "Downtown" });

      migrationBuilder.InsertData(
          table: "Stores",
          columns: new[] { "EntityID", "Discriminator", "Name" },
          values: new object[] { 2L, "NewYorkStore", "Times Square" });
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.DeleteData(
          table: "Stores",
          keyColumn: "EntityID",
          keyValue: 1L);

      migrationBuilder.DeleteData(
          table: "Stores",
          keyColumn: "EntityID",
          keyValue: 2L);
    }
  }
}
