﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PizzaBox.Domain;

namespace PizzaBox.Domain.Migrations
{
  [DbContext(typeof(PizzaBoxContext))]
  [Migration("20210421195947_add Pizza-DbSet")]
  partial class addPizzaDbSet
  {
    protected override void BuildTargetModel(ModelBuilder modelBuilder)
    {
#pragma warning disable 612, 618
      modelBuilder
          .HasAnnotation("Relational:MaxIdentifierLength", 128)
          .HasAnnotation("ProductVersion", "5.0.5")
          .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

      modelBuilder.Entity("PizzaBox.Domain.Abstracts.APizza", b =>
          {
            b.Property<long>("EntityID")
                      .ValueGeneratedOnAdd()
                      .HasColumnType("bigint")
                      .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            b.Property<long?>("CrustEntityID")
                      .HasColumnType("bigint");

            b.Property<string>("Discriminator")
                      .IsRequired()
                      .HasColumnType("nvarchar(max)");

            b.Property<string>("Name")
                      .HasColumnType("nvarchar(max)");

            b.Property<long?>("OrderEntityID")
                      .HasColumnType("bigint");

            b.Property<long?>("SizeEntityID")
                      .HasColumnType("bigint");

            b.HasKey("EntityID");

            b.HasIndex("CrustEntityID");

            b.HasIndex("OrderEntityID");

            b.HasIndex("SizeEntityID");

            b.ToTable("Pizzas");

            b.HasDiscriminator<string>("Discriminator").HasValue("APizza");
          });

      modelBuilder.Entity("PizzaBox.Domain.Abstracts.AStore", b =>
          {
            b.Property<long>("EntityID")
                      .ValueGeneratedOnAdd()
                      .HasColumnType("bigint")
                      .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            b.Property<string>("Discriminator")
                      .IsRequired()
                      .HasColumnType("nvarchar(max)");

            b.Property<string>("Name")
                      .HasColumnType("nvarchar(max)");

            b.HasKey("EntityID");

            b.ToTable("Stores");

            b.HasDiscriminator<string>("Discriminator").HasValue("AStore");
          });

      modelBuilder.Entity("PizzaBox.Domain.Models.Crust", b =>
          {
            b.Property<long>("EntityID")
                      .ValueGeneratedOnAdd()
                      .HasColumnType("bigint")
                      .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            b.Property<string>("Name")
                      .HasColumnType("nvarchar(max)");

            b.Property<decimal>("Price")
                      .HasColumnType("decimal(18,2)");

            b.HasKey("EntityID");

            b.ToTable("Crust");
          });

      modelBuilder.Entity("PizzaBox.Domain.Models.Customer", b =>
          {
            b.Property<long>("EntityID")
                      .ValueGeneratedOnAdd()
                      .HasColumnType("bigint")
                      .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            b.Property<string>("Name")
                      .HasColumnType("nvarchar(max)");

            b.HasKey("EntityID");

            b.ToTable("Customer");
          });

      modelBuilder.Entity("PizzaBox.Domain.Models.Order", b =>
          {
            b.Property<long>("EntityID")
                      .ValueGeneratedOnAdd()
                      .HasColumnType("bigint")
                      .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            b.Property<long?>("CustomerEntityID")
                      .HasColumnType("bigint");

            b.Property<long?>("StoreEntityID")
                      .HasColumnType("bigint");

            b.HasKey("EntityID");

            b.HasIndex("CustomerEntityID");

            b.HasIndex("StoreEntityID");

            b.ToTable("Order");
          });

      modelBuilder.Entity("PizzaBox.Domain.Models.Size", b =>
          {
            b.Property<long>("EntityID")
                      .ValueGeneratedOnAdd()
                      .HasColumnType("bigint")
                      .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            b.Property<string>("Name")
                      .HasColumnType("nvarchar(max)");

            b.Property<decimal>("Price")
                      .HasColumnType("decimal(18,2)");

            b.HasKey("EntityID");

            b.ToTable("Size");
          });

      modelBuilder.Entity("PizzaBox.Domain.Models.Topping", b =>
          {
            b.Property<long>("EntityID")
                      .ValueGeneratedOnAdd()
                      .HasColumnType("bigint")
                      .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            b.Property<long?>("APizzaEntityID")
                      .HasColumnType("bigint");

            b.Property<string>("Name")
                      .HasColumnType("nvarchar(max)");

            b.Property<decimal>("Price")
                      .HasColumnType("decimal(18,2)");

            b.HasKey("EntityID");

            b.HasIndex("APizzaEntityID");

            b.ToTable("Topping");
          });

      modelBuilder.Entity("PizzaBox.Domain.Models.CustomPizza", b =>
          {
            b.HasBaseType("PizzaBox.Domain.Abstracts.APizza");

            b.HasDiscriminator().HasValue("CustomPizza");
          });

      modelBuilder.Entity("PizzaBox.Domain.Models.MeatPizza", b =>
          {
            b.HasBaseType("PizzaBox.Domain.Abstracts.APizza");

            b.HasDiscriminator().HasValue("MeatPizza");
          });

      modelBuilder.Entity("PizzaBox.Domain.Models.VeggiePizza", b =>
          {
            b.HasBaseType("PizzaBox.Domain.Abstracts.APizza");

            b.HasDiscriminator().HasValue("VeggiePizza");
          });

      modelBuilder.Entity("PizzaBox.Domain.Models.ChicagoStore", b =>
          {
            b.HasBaseType("PizzaBox.Domain.Abstracts.AStore");

            b.HasDiscriminator().HasValue("ChicagoStore");
          });

      modelBuilder.Entity("PizzaBox.Domain.Models.NewYorkStore", b =>
          {
            b.HasBaseType("PizzaBox.Domain.Abstracts.AStore");

            b.HasDiscriminator().HasValue("NewYorkStore");
          });

      modelBuilder.Entity("PizzaBox.Domain.Abstracts.APizza", b =>
          {
            b.HasOne("PizzaBox.Domain.Models.Crust", "Crust")
                      .WithMany()
                      .HasForeignKey("CrustEntityID");

            b.HasOne("PizzaBox.Domain.Models.Order", null)
                      .WithMany("Pizzas")
                      .HasForeignKey("OrderEntityID");

            b.HasOne("PizzaBox.Domain.Models.Size", "Size")
                      .WithMany("Pizzas")
                      .HasForeignKey("SizeEntityID");

            b.Navigation("Crust");

            b.Navigation("Size");
          });

      modelBuilder.Entity("PizzaBox.Domain.Models.Order", b =>
          {
            b.HasOne("PizzaBox.Domain.Models.Customer", "Customer")
                      .WithMany("Orders")
                      .HasForeignKey("CustomerEntityID");

            b.HasOne("PizzaBox.Domain.Abstracts.AStore", "Store")
                      .WithMany("Orders")
                      .HasForeignKey("StoreEntityID");

            b.Navigation("Customer");

            b.Navigation("Store");
          });

      modelBuilder.Entity("PizzaBox.Domain.Models.Topping", b =>
          {
            b.HasOne("PizzaBox.Domain.Abstracts.APizza", null)
                      .WithMany("Toppings")
                      .HasForeignKey("APizzaEntityID");
          });

      modelBuilder.Entity("PizzaBox.Domain.Abstracts.APizza", b =>
          {
            b.Navigation("Toppings");
          });

      modelBuilder.Entity("PizzaBox.Domain.Abstracts.AStore", b =>
          {
            b.Navigation("Orders");
          });

      modelBuilder.Entity("PizzaBox.Domain.Models.Customer", b =>
          {
            b.Navigation("Orders");
          });

      modelBuilder.Entity("PizzaBox.Domain.Models.Order", b =>
          {
            b.Navigation("Pizzas");
          });

      modelBuilder.Entity("PizzaBox.Domain.Models.Size", b =>
          {
            b.Navigation("Pizzas");
          });
#pragma warning restore 612, 618
    }
  }
}
