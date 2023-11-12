﻿// <auto-generated />
using System;
using Learn.FoodApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Learn.FoodApp.Infrastructure.Migrations
{
    [DbContext(typeof(LearnFoodAppDB))]
    [Migration("20231107161751_editAppusers2")]
    partial class editAppusers2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Learn.FoodApp.Core.Entities.ApplicationUsers", b =>
                {
                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("AgainPass")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Fullname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<string>("phone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Username");

                    b.ToTable("ApplicationUsers");
                });

            modelBuilder.Entity("Learn.FoodApp.Core.Entities.Food", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Count")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("CustomerName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomerUsername")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Ordered")
                        .HasColumnType("datetime2");

                    b.Property<string>("RestaurantSenderUsername")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CustomerUsername");

                    b.HasIndex("RestaurantSenderUsername");

                    b.ToTable("Foods");
                });

            modelBuilder.Entity("Learn.FoodApp.Core.Entities.Restaurant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ApproverUsername")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime?>("ApprowedTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsApproved")
                        .HasColumnType("bit");

                    b.Property<string>("OwnerUsername")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ApproverUsername");

                    b.HasIndex("OwnerUsername");

                    b.ToTable("restaurants");
                });

            modelBuilder.Entity("Learn.FoodApp.Core.Entities.Food", b =>
                {
                    b.HasOne("Learn.FoodApp.Core.Entities.ApplicationUsers", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerUsername");

                    b.HasOne("Learn.FoodApp.Core.Entities.ApplicationUsers", "RestaurantSender")
                        .WithMany()
                        .HasForeignKey("RestaurantSenderUsername");

                    b.Navigation("Customer");

                    b.Navigation("RestaurantSender");
                });

            modelBuilder.Entity("Learn.FoodApp.Core.Entities.Restaurant", b =>
                {
                    b.HasOne("Learn.FoodApp.Core.Entities.ApplicationUsers", "Approver")
                        .WithMany()
                        .HasForeignKey("ApproverUsername");

                    b.HasOne("Learn.FoodApp.Core.Entities.ApplicationUsers", "Owner")
                        .WithMany()
                        .HasForeignKey("OwnerUsername");

                    b.Navigation("Approver");

                    b.Navigation("Owner");
                });
#pragma warning restore 612, 618
        }
    }
}
