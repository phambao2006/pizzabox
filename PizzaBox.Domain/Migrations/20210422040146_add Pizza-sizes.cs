using Microsoft.EntityFrameworkCore.Migrations;

namespace PizzaBox.Domain.Migrations
{
    public partial class addPizzasizes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pizzas_Crust_CrustEntityID",
                table: "Pizzas");

            migrationBuilder.DropForeignKey(
                name: "FK_Pizzas_Size_SizeEntityID",
                table: "Pizzas");

            migrationBuilder.DropForeignKey(
                name: "FK_Pizzas_Size_SizeEntityID1",
                table: "Pizzas");

            migrationBuilder.DropForeignKey(
                name: "FK_Pizzas_Size_SizeEntityID2",
                table: "Pizzas");

            migrationBuilder.DropForeignKey(
                name: "FK_Topping_Pizzas_APizzaEntityID",
                table: "Topping");

            migrationBuilder.DropIndex(
                name: "IX_Pizzas_SizeEntityID1",
                table: "Pizzas");

            migrationBuilder.DropIndex(
                name: "IX_Pizzas_SizeEntityID2",
                table: "Pizzas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Topping",
                table: "Topping");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Size",
                table: "Size");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Crust",
                table: "Crust");

            migrationBuilder.DropColumn(
                name: "SizeEntityID1",
                table: "Pizzas");

            migrationBuilder.DropColumn(
                name: "SizeEntityID2",
                table: "Pizzas");

            migrationBuilder.RenameTable(
                name: "Topping",
                newName: "Toppings");

            migrationBuilder.RenameTable(
                name: "Size",
                newName: "Sizes");

            migrationBuilder.RenameTable(
                name: "Crust",
                newName: "Crusts");

            migrationBuilder.RenameIndex(
                name: "IX_Topping_APizzaEntityID",
                table: "Toppings",
                newName: "IX_Toppings_APizzaEntityID");

            migrationBuilder.AlterColumn<long>(
                name: "SizeEntityID",
                table: "Pizzas",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Toppings",
                table: "Toppings",
                column: "EntityID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sizes",
                table: "Sizes",
                column: "EntityID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Crusts",
                table: "Crusts",
                column: "EntityID");

            migrationBuilder.AddForeignKey(
                name: "FK_Pizzas_Crusts_CrustEntityID",
                table: "Pizzas",
                column: "CrustEntityID",
                principalTable: "Crusts",
                principalColumn: "EntityID",
                onDelete: ReferentialAction.Restrict);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pizzas_Crusts_CrustEntityID",
                table: "Pizzas");

            migrationBuilder.DropForeignKey(
                name: "FK_Pizzas_Sizes_SizeEntityID",
                table: "Pizzas");

            migrationBuilder.DropForeignKey(
                name: "FK_Toppings_Pizzas_APizzaEntityID",
                table: "Toppings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Toppings",
                table: "Toppings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Sizes",
                table: "Sizes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Crusts",
                table: "Crusts");

            migrationBuilder.RenameTable(
                name: "Toppings",
                newName: "Topping");

            migrationBuilder.RenameTable(
                name: "Sizes",
                newName: "Size");

            migrationBuilder.RenameTable(
                name: "Crusts",
                newName: "Crust");

            migrationBuilder.RenameIndex(
                name: "IX_Toppings_APizzaEntityID",
                table: "Topping",
                newName: "IX_Topping_APizzaEntityID");

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

            migrationBuilder.AddPrimaryKey(
                name: "PK_Topping",
                table: "Topping",
                column: "EntityID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Size",
                table: "Size",
                column: "EntityID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Crust",
                table: "Crust",
                column: "EntityID");

            migrationBuilder.CreateIndex(
                name: "IX_Pizzas_SizeEntityID1",
                table: "Pizzas",
                column: "SizeEntityID1");

            migrationBuilder.CreateIndex(
                name: "IX_Pizzas_SizeEntityID2",
                table: "Pizzas",
                column: "SizeEntityID2");

            migrationBuilder.AddForeignKey(
                name: "FK_Pizzas_Crust_CrustEntityID",
                table: "Pizzas",
                column: "CrustEntityID",
                principalTable: "Crust",
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

            migrationBuilder.AddForeignKey(
                name: "FK_Topping_Pizzas_APizzaEntityID",
                table: "Topping",
                column: "APizzaEntityID",
                principalTable: "Pizzas",
                principalColumn: "EntityID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
