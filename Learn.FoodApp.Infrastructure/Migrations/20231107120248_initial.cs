using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Learn.FoodApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApplicationUsers",
                columns: table => new
                {
                    Username = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    againPass = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fullname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    phone = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUsers", x => x.Username);
                });

            migrationBuilder.CreateTable(
                name: "Foods",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Count = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerUsername = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    RestaurantSenderUsername = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Ordered = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Foods", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Foods_ApplicationUsers_CustomerUsername",
                        column: x => x.CustomerUsername,
                        principalTable: "ApplicationUsers",
                        principalColumn: "Username");
                    table.ForeignKey(
                        name: "FK_Foods_ApplicationUsers_RestaurantSenderUsername",
                        column: x => x.RestaurantSenderUsername,
                        principalTable: "ApplicationUsers",
                        principalColumn: "Username");
                });

            migrationBuilder.CreateTable(
                name: "restaurants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OwnerUsername = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IsApproved = table.Column<bool>(type: "bit", nullable: false),
                    ApproverUsername = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ApprowedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_restaurants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_restaurants_ApplicationUsers_ApproverUsername",
                        column: x => x.ApproverUsername,
                        principalTable: "ApplicationUsers",
                        principalColumn: "Username");
                    table.ForeignKey(
                        name: "FK_restaurants_ApplicationUsers_OwnerUsername",
                        column: x => x.OwnerUsername,
                        principalTable: "ApplicationUsers",
                        principalColumn: "Username");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Foods_CustomerUsername",
                table: "Foods",
                column: "CustomerUsername");

            migrationBuilder.CreateIndex(
                name: "IX_Foods_RestaurantSenderUsername",
                table: "Foods",
                column: "RestaurantSenderUsername");

            migrationBuilder.CreateIndex(
                name: "IX_restaurants_ApproverUsername",
                table: "restaurants",
                column: "ApproverUsername");

            migrationBuilder.CreateIndex(
                name: "IX_restaurants_OwnerUsername",
                table: "restaurants",
                column: "OwnerUsername");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Foods");

            migrationBuilder.DropTable(
                name: "restaurants");

            migrationBuilder.DropTable(
                name: "ApplicationUsers");
        }
    }
}
