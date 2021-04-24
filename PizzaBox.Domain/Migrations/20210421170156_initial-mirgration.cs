using Microsoft.EntityFrameworkCore.Migrations;

namespace PizzaBox.Domain.Migrations
{
  public partial class initialmirgration : Migration
  {
    protected override void Up(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.CreateTable(
          name: "Crust",
          columns: table => new
          {
            EntityID = table.Column<long>(type: "bigint", nullable: false)
                  .Annotation("SqlServer:Identity", "1, 1"),
            Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
            Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_Crust", x => x.EntityID);
          });

      migrationBuilder.CreateTable(
          name: "Customer",
          columns: table => new
          {
            EntityID = table.Column<long>(type: "bigint", nullable: false)
                  .Annotation("SqlServer:Identity", "1, 1"),
            Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_Customer", x => x.EntityID);
          });

      migrationBuilder.CreateTable(
          name: "Size",
          columns: table => new
          {
            EntityID = table.Column<long>(type: "bigint", nullable: false)
                  .Annotation("SqlServer:Identity", "1, 1"),
            Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
            Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_Size", x => x.EntityID);
          });

      migrationBuilder.CreateTable(
          name: "Stores",
          columns: table => new
          {
            EntityID = table.Column<long>(type: "bigint", nullable: false)
                  .Annotation("SqlServer:Identity", "1, 1"),
            Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
            Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_Stores", x => x.EntityID);
          });

      migrationBuilder.CreateTable(
          name: "Order",
          columns: table => new
          {
            EntityID = table.Column<long>(type: "bigint", nullable: false)
                  .Annotation("SqlServer:Identity", "1, 1"),
            StoreEntityID = table.Column<long>(type: "bigint", nullable: true),
            CustomerEntityID = table.Column<long>(type: "bigint", nullable: true)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_Order", x => x.EntityID);
            table.ForeignKey(
                      name: "FK_Order_Customer_CustomerEntityID",
                      column: x => x.CustomerEntityID,
                      principalTable: "Customer",
                      principalColumn: "EntityID",
                      onDelete: ReferentialAction.Restrict);
            table.ForeignKey(
                      name: "FK_Order_Stores_StoreEntityID",
                      column: x => x.StoreEntityID,
                      principalTable: "Stores",
                      principalColumn: "EntityID",
                      onDelete: ReferentialAction.Restrict);
          });

      migrationBuilder.CreateTable(
          name: "APizza",
          columns: table => new
          {
            EntityID = table.Column<long>(type: "bigint", nullable: false)
                  .Annotation("SqlServer:Identity", "1, 1"),
            Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
            CrustEntityID = table.Column<long>(type: "bigint", nullable: true),
            SizeEntityID = table.Column<long>(type: "bigint", nullable: true),
            Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
            OrderEntityID = table.Column<long>(type: "bigint", nullable: true)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_APizza", x => x.EntityID);
            table.ForeignKey(
                      name: "FK_APizza_Crust_CrustEntityID",
                      column: x => x.CrustEntityID,
                      principalTable: "Crust",
                      principalColumn: "EntityID",
                      onDelete: ReferentialAction.Restrict);
            table.ForeignKey(
                      name: "FK_APizza_Order_OrderEntityID",
                      column: x => x.OrderEntityID,
                      principalTable: "Order",
                      principalColumn: "EntityID",
                      onDelete: ReferentialAction.Restrict);
            table.ForeignKey(
                      name: "FK_APizza_Size_SizeEntityID",
                      column: x => x.SizeEntityID,
                      principalTable: "Size",
                      principalColumn: "EntityID",
                      onDelete: ReferentialAction.Restrict);
          });

      migrationBuilder.CreateTable(
          name: "Topping",
          columns: table => new
          {
            EntityID = table.Column<long>(type: "bigint", nullable: false)
                  .Annotation("SqlServer:Identity", "1, 1"),
            APizzaEntityID = table.Column<long>(type: "bigint", nullable: true),
            Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
            Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_Topping", x => x.EntityID);
            table.ForeignKey(
                      name: "FK_Topping_APizza_APizzaEntityID",
                      column: x => x.APizzaEntityID,
                      principalTable: "APizza",
                      principalColumn: "EntityID",
                      onDelete: ReferentialAction.Restrict);
          });

      migrationBuilder.InsertData(
          table: "Stores",
          columns: new[] { "EntityID", "Discriminator", "Name" },
          values: new object[] { 1L, "ChicagoStore", "ChicagoStore" });

      migrationBuilder.InsertData(
          table: "Stores",
          columns: new[] { "EntityID", "Discriminator", "Name" },
          values: new object[] { 2L, "NewYorkStore", "NewYorkStore" });

      migrationBuilder.CreateIndex(
          name: "IX_APizza_CrustEntityID",
          table: "APizza",
          column: "CrustEntityID");

      migrationBuilder.CreateIndex(
          name: "IX_APizza_OrderEntityID",
          table: "APizza",
          column: "OrderEntityID");

      migrationBuilder.CreateIndex(
          name: "IX_APizza_SizeEntityID",
          table: "APizza",
          column: "SizeEntityID");

      migrationBuilder.CreateIndex(
          name: "IX_Order_CustomerEntityID",
          table: "Order",
          column: "CustomerEntityID");

      migrationBuilder.CreateIndex(
          name: "IX_Order_StoreEntityID",
          table: "Order",
          column: "StoreEntityID");

      migrationBuilder.CreateIndex(
          name: "IX_Topping_APizzaEntityID",
          table: "Topping",
          column: "APizzaEntityID");
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.DropTable(
          name: "Topping");

      migrationBuilder.DropTable(
          name: "APizza");

      migrationBuilder.DropTable(
          name: "Crust");

      migrationBuilder.DropTable(
          name: "Order");

      migrationBuilder.DropTable(
          name: "Size");

      migrationBuilder.DropTable(
          name: "Customer");

      migrationBuilder.DropTable(
          name: "Stores");
    }
  }
}
