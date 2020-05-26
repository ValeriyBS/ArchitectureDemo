﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistence.Shared;

namespace Persistence.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Domain.Categories.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2020, 5, 26, 6, 24, 59, 195, DateTimeKind.Utc).AddTicks(4933));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LastModified")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2020, 5, 26, 6, 24, 59, 200, DateTimeKind.Utc).AddTicks(3674));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Fancy items for men",
                            Name = "Men"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Fancy items for Women",
                            Name = "Women"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Fancy items for kids",
                            Name = "Kids"
                        });
                });

            modelBuilder.Entity("Domain.Customers.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AddressLine1")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("AddressLine2")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<DateTime>("Created")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2020, 5, 26, 6, 24, 59, 200, DateTimeKind.Utc).AddTicks(5099));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<DateTime>("LastModified")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2020, 5, 26, 6, 24, 59, 200, DateTimeKind.Utc).AddTicks(5979));

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(25)")
                        .HasMaxLength(25);

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.Property<string>("ZipCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.HasKey("Id");

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AddressLine1 = "",
                            AddressLine2 = "",
                            City = "Washington",
                            Country = "USA",
                            Email = "Gordon.Freeman@Gmail.com",
                            FirstName = "Gordon",
                            LastName = "Freeman",
                            PhoneNumber = "",
                            State = "Washington",
                            ZipCode = ""
                        });
                });

            modelBuilder.Entity("Domain.OrderDetails.OrderDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<DateTime>("Created")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2020, 5, 26, 6, 24, 59, 200, DateTimeKind.Utc).AddTicks(6874));

                    b.Property<DateTime>("LastModified")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2020, 5, 26, 6, 24, 59, 200, DateTimeKind.Utc).AddTicks(7684));

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ShopItemId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("ShopItemId");

                    b.ToTable("OrderDetails");
                });

            modelBuilder.Entity("Domain.Orders.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2020, 5, 26, 6, 24, 59, 200, DateTimeKind.Utc).AddTicks(8543));

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("LastModified")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2020, 5, 26, 6, 24, 59, 200, DateTimeKind.Utc).AddTicks(9428));

                    b.Property<DateTime>("OrderPlaced")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("OrderTotal")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Domain.ShopItems.ShopItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Created")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2020, 5, 26, 6, 24, 59, 201, DateTimeKind.Utc).AddTicks(387));

                    b.Property<string>("ImageThumbnailUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("InStock")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LastModified")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2020, 5, 26, 6, 24, 59, 201, DateTimeKind.Utc).AddTicks(1468));

                    b.Property<string>("LongDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Notes")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("ShortDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("ShopItems");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            ImageThumbnailUrl = "",
                            ImageUrl = "",
                            InStock = true,
                            LongDescription = "Very very sleek trousers",
                            Name = "Sleek Trousers",
                            Notes = "It is a fine item to have!",
                            Price = 5.99m,
                            ShortDescription = "Very Sleek Trousers"
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 1,
                            ImageThumbnailUrl = "",
                            ImageUrl = "",
                            InStock = true,
                            LongDescription = "Very heavy duty trousers",
                            Name = "Work Trousers",
                            Notes = "It is a fine item to have!",
                            Price = 28.99m,
                            ShortDescription = "Heavy Duty Trousers"
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 2,
                            ImageThumbnailUrl = "",
                            ImageUrl = "",
                            InStock = true,
                            LongDescription = "Very very sleek dress",
                            Name = "Sleek Dress",
                            Notes = "It is a fine item to have!",
                            Price = 0.99m,
                            ShortDescription = "Very Sleek dress"
                        },
                        new
                        {
                            Id = 4,
                            CategoryId = 2,
                            ImageThumbnailUrl = "",
                            ImageUrl = "",
                            InStock = true,
                            LongDescription = "Very heavy duty work dress",
                            Name = "Work Dress",
                            Notes = "It is a fine item to have!",
                            Price = 15.99m,
                            ShortDescription = "Heavy duty work dress"
                        },
                        new
                        {
                            Id = 5,
                            CategoryId = 3,
                            ImageThumbnailUrl = "",
                            ImageUrl = "",
                            InStock = true,
                            LongDescription = "Very very sleek diapers",
                            Name = "Sleek Diapers",
                            Notes = "It is a fine item to have!",
                            Price = 0.99m,
                            ShortDescription = "Very sleek diapers"
                        },
                        new
                        {
                            Id = 6,
                            CategoryId = 3,
                            ImageThumbnailUrl = "",
                            ImageUrl = "",
                            InStock = true,
                            LongDescription = "Very heavy duty diapers",
                            Name = "Work diapers",
                            Notes = "It is a fine item to have!",
                            Price = 15.99m,
                            ShortDescription = "Heavy duty work diapers"
                        });
                });

            modelBuilder.Entity("Domain.ShoppingCartItems.ShoppingCartItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<DateTime>("Created")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2020, 5, 26, 6, 24, 59, 201, DateTimeKind.Utc).AddTicks(2218));

                    b.Property<DateTime>("LastModified")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2020, 5, 26, 6, 24, 59, 201, DateTimeKind.Utc).AddTicks(3116));

                    b.Property<int>("ShopItemId")
                        .HasColumnType("int");

                    b.Property<string>("ShoppingCartId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ShopItemId");

                    b.ToTable("ShoppingCartItems");
                });

            modelBuilder.Entity("Domain.OrderDetails.OrderDetail", b =>
                {
                    b.HasOne("Domain.Orders.Order", "Order")
                        .WithMany("OrderDetails")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.ShopItems.ShopItem", "ShopItem")
                        .WithMany()
                        .HasForeignKey("ShopItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Orders.Order", b =>
                {
                    b.HasOne("Domain.Customers.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.ShopItems.ShopItem", b =>
                {
                    b.HasOne("Domain.Categories.Category", "Category")
                        .WithMany("ShopItems")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.ShoppingCartItems.ShoppingCartItem", b =>
                {
                    b.HasOne("Domain.ShopItems.ShopItem", "ShopItem")
                        .WithMany()
                        .HasForeignKey("ShopItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
