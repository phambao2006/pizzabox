using Microsoft.EntityFrameworkCore.Migrations;

namespace PizzaBox.Domain.Migrations
{
    public partial class addrelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Customers_CustomerEntityID",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Stores_StoreEntityID",
                table: "Orders");

            migrationBuilder.AlterColumn<long>(
                name: "StoreEntityID",
                table: "Orders",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "CustomerEntityID",
                table: "Orders",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Customers_CustomerEntityID",
                table: "Orders",
                column: "CustomerEntityID",
                principalTable: "Customers",
                principalColumn: "EntityID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Stores_StoreEntityID",
                table: "Orders",
                column: "StoreEntityID",
                principalTable: "Stores",
                principalColumn: "EntityID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Customers_CustomerEntityID",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Stores_StoreEntityID",
                table: "Orders");

            migrationBuilder.AlterColumn<long>(
                name: "StoreEntityID",
                table: "Orders",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "CustomerEntityID",
                table: "Orders",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Customers_CustomerEntityID",
                table: "Orders",
                column: "CustomerEntityID",
                principalTable: "Customers",
                principalColumn: "EntityID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Stores_StoreEntityID",
                table: "Orders",
                column: "StoreEntityID",
                principalTable: "Stores",
                principalColumn: "EntityID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
