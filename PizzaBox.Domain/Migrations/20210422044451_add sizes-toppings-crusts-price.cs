﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace PizzaBox.Domain.Migrations
{
  public partial class addsizestoppingscrustsprice : Migration
  {
    protected override void Up(MigrationBuilder migrationBuilder)
    {
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
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
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
    }
  }
}