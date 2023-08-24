﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProductandReviewAPI.Data;

#nullable disable

namespace ProductandReview.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("ProductandReviewAPI.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<double>("Price")
                        .HasColumnType("double");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Wok Pan",
                            Price = 29.989999999999998
                        },
                        new
                        {
                            Id = 2,
                            Name = "Heavy Duty Spatula",
                            Price = 4.9900000000000002
                        },
                        new
                        {
                            Id = 3,
                            Name = "Rice Cooker",
                            Price = 49.990000000000002
                        },
                        new
                        {
                            Id = 4,
                            Name = "Bamboo Steamer",
                            Price = 14.99
                        },
                        new
                        {
                            Id = 5,
                            Name = "Chopsticks Set",
                            Price = 9.9900000000000002
                        });
                });

            modelBuilder.Entity("ProductandReviewAPI.Models.Review", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("Reviews");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ProductId = 1,
                            Rating = 5,
                            Text = "Great wok for stir-frying!"
                        },
                        new
                        {
                            Id = 2,
                            ProductId = 2,
                            Rating = 4,
                            Text = "Good quality product."
                        },
                        new
                        {
                            Id = 3,
                            ProductId = 3,
                            Rating = 5,
                            Text = "Makes perfect rice every time."
                        },
                        new
                        {
                            Id = 4,
                            ProductId = 4,
                            Rating = 4,
                            Text = "Perfect for steaming vegetables."
                        },
                        new
                        {
                            Id = 5,
                            ProductId = 5,
                            Rating = 4,
                            Text = "Nice chopsticks set for casual usage."
                        },
                        new
                        {
                            Id = 6,
                            ProductId = 1,
                            Rating = 3,
                            Text = "Decent wok, but could be better."
                        },
                        new
                        {
                            Id = 7,
                            ProductId = 2,
                            Rating = 2,
                            Text = "Melted on my stovetop."
                        },
                        new
                        {
                            Id = 8,
                            ProductId = 3,
                            Rating = 2,
                            Text = "Not very durable, broke after a few uses."
                        },
                        new
                        {
                            Id = 9,
                            ProductId = 4,
                            Rating = 3,
                            Text = "Steamer works well but could use more compartments."
                        },
                        new
                        {
                            Id = 10,
                            ProductId = 5,
                            Rating = 2,
                            Text = "Chopsticks are too slippery to hold properly."
                        },
                        new
                        {
                            Id = 11,
                            ProductId = 1,
                            Rating = 3,
                            Text = "Average wok, nothing special."
                        },
                        new
                        {
                            Id = 12,
                            ProductId = 2,
                            Rating = 3,
                            Text = "Standard spatula, everything you need."
                        },
                        new
                        {
                            Id = 13,
                            ProductId = 3,
                            Rating = 4,
                            Text = "Good value for the price."
                        },
                        new
                        {
                            Id = 14,
                            ProductId = 4,
                            Rating = 5,
                            Text = "Convenient for steaming various dishes."
                        },
                        new
                        {
                            Id = 15,
                            ProductId = 5,
                            Rating = 5,
                            Text = "Comfortable chopsticks to use."
                        });
                });

            modelBuilder.Entity("ProductandReviewAPI.Models.Review", b =>
                {
                    b.HasOne("ProductandReviewAPI.Models.Product", "Product")
                        .WithMany("Reviews")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("ProductandReviewAPI.Models.Product", b =>
                {
                    b.Navigation("Reviews");
                });
#pragma warning restore 612, 618
        }
    }
}
