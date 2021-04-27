﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PizzaBox.Domain;

namespace PizzaBox.Domain.Migrations
{
    [DbContext(typeof(PizzaBoxContext))]
    [Migration("20210426185739_add-relationship")]
    partial class addrelationship
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("APizzaTopping", b =>
                {
                    b.Property<long>("PizzasEntityID")
                        .HasColumnType("bigint");

                    b.Property<long>("ToppingsEntityID")
                        .HasColumnType("bigint");

                    b.HasKey("PizzasEntityID", "ToppingsEntityID");

                    b.HasIndex("ToppingsEntityID");

                    b.ToTable("APizzaTopping");
                });

            modelBuilder.Entity("PizzaBox.Domain.Abstracts.APizza", b =>
                {
                    b.Property<long>("EntityID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("CrustEntityId")
                        .HasColumnType("bigint");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("OrderEntityId")
                        .HasColumnType("bigint");

                    b.Property<long>("SizeEntityId")
                        .HasColumnType("bigint");

                    b.HasKey("EntityID");

                    b.HasIndex("CrustEntityId");

                    b.HasIndex("OrderEntityId");

                    b.HasIndex("SizeEntityId");

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

                    b.ToTable("Crusts");

                    b.HasData(
                        new
                        {
                            EntityID = 1L,
                            Name = "Original",
                            Price = 2m
                        },
                        new
                        {
                            EntityID = 2L,
                            Name = "Thin Crust",
                            Price = 2m
                        },
                        new
                        {
                            EntityID = 3L,
                            Name = "Stuffed Crust",
                            Price = 3m
                        });
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

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("PizzaBox.Domain.Models.Order", b =>
                {
                    b.Property<long>("EntityID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("CustomerEntityID")
                        .HasColumnType("bigint");

                    b.Property<long>("StoreEntityID")
                        .HasColumnType("bigint");

                    b.HasKey("EntityID");

                    b.HasIndex("CustomerEntityID");

                    b.HasIndex("StoreEntityID");

                    b.ToTable("Orders");
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

                    b.ToTable("Sizes");

                    b.HasData(
                        new
                        {
                            EntityID = 1L,
                            Name = "Small",
                            Price = 2m
                        },
                        new
                        {
                            EntityID = 2L,
                            Name = "Medium",
                            Price = 3m
                        },
                        new
                        {
                            EntityID = 3L,
                            Name = "Large",
                            Price = 4m
                        });
                });

            modelBuilder.Entity("PizzaBox.Domain.Models.Topping", b =>
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

                    b.ToTable("Toppings");

                    b.HasData(
                        new
                        {
                            EntityID = 1L,
                            Name = "Chicken",
                            Price = 2m
                        },
                        new
                        {
                            EntityID = 2L,
                            Name = "Pork",
                            Price = 2m
                        },
                        new
                        {
                            EntityID = 3L,
                            Name = "Beef",
                            Price = 2m
                        },
                        new
                        {
                            EntityID = 4L,
                            Name = "Mushroom",
                            Price = 2m
                        },
                        new
                        {
                            EntityID = 5L,
                            Name = "Pineapple",
                            Price = 2m
                        },
                        new
                        {
                            EntityID = 6L,
                            Name = "Bell Pepper",
                            Price = 2m
                        });
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

                    b.HasData(
                        new
                        {
                            EntityID = 1L,
                            Name = "Downtown"
                        });
                });

            modelBuilder.Entity("PizzaBox.Domain.Models.NewYorkStore", b =>
                {
                    b.HasBaseType("PizzaBox.Domain.Abstracts.AStore");

                    b.HasDiscriminator().HasValue("NewYorkStore");

                    b.HasData(
                        new
                        {
                            EntityID = 2L,
                            Name = "Times Square"
                        });
                });

            modelBuilder.Entity("APizzaTopping", b =>
                {
                    b.HasOne("PizzaBox.Domain.Abstracts.APizza", null)
                        .WithMany()
                        .HasForeignKey("PizzasEntityID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PizzaBox.Domain.Models.Topping", null)
                        .WithMany()
                        .HasForeignKey("ToppingsEntityID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PizzaBox.Domain.Abstracts.APizza", b =>
                {
                    b.HasOne("PizzaBox.Domain.Models.Crust", "Crust")
                        .WithMany("Pizzas")
                        .HasForeignKey("CrustEntityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PizzaBox.Domain.Models.Order", null)
                        .WithMany("Pizzas")
                        .HasForeignKey("OrderEntityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PizzaBox.Domain.Models.Size", "Size")
                        .WithMany("Pizzas")
                        .HasForeignKey("SizeEntityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Crust");

                    b.Navigation("Size");
                });

            modelBuilder.Entity("PizzaBox.Domain.Models.Order", b =>
                {
                    b.HasOne("PizzaBox.Domain.Models.Customer", "Customer")
                        .WithMany("Orders")
                        .HasForeignKey("CustomerEntityID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PizzaBox.Domain.Abstracts.AStore", "Store")
                        .WithMany("Orders")
                        .HasForeignKey("StoreEntityID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Store");
                });

            modelBuilder.Entity("PizzaBox.Domain.Abstracts.AStore", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("PizzaBox.Domain.Models.Crust", b =>
                {
                    b.Navigation("Pizzas");
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
