using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CarRentalService.Domain.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "client",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    passport_number = table.Column<string>(type: "text", nullable: false),
                    full_name = table.Column<string>(type: "text", nullable: false),
                    birth_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_client", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "RentalPoints",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    address = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RentalPoints", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    model = table.Column<string>(type: "text", nullable: false),
                    color = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "RentalRecords",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    vehicle = table.Column<int>(type: "integer", nullable: false),
                    client = table.Column<int>(type: "integer", nullable: false),
                    rental_point = table.Column<int>(type: "integer", nullable: false),
                    rental_start = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    rental_end = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    return_point = table.Column<int>(type: "integer", nullable: false),
                    rental_duration_days = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RentalRecords", x => x.id);
                    table.ForeignKey(
                        name: "FK_RentalRecords_RentalPoints_rental_point",
                        column: x => x.rental_point,
                        principalTable: "RentalPoints",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RentalRecords_RentalPoints_return_point",
                        column: x => x.return_point,
                        principalTable: "RentalPoints",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RentalRecords_Vehicles_vehicle",
                        column: x => x.vehicle,
                        principalTable: "Vehicles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RentalRecords_client_client",
                        column: x => x.client,
                        principalTable: "client",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RentalRecords_client",
                table: "RentalRecords",
                column: "client");

            migrationBuilder.CreateIndex(
                name: "IX_RentalRecords_rental_point",
                table: "RentalRecords",
                column: "rental_point");

            migrationBuilder.CreateIndex(
                name: "IX_RentalRecords_return_point",
                table: "RentalRecords",
                column: "return_point");

            migrationBuilder.CreateIndex(
                name: "IX_RentalRecords_vehicle",
                table: "RentalRecords",
                column: "vehicle");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RentalRecords");

            migrationBuilder.DropTable(
                name: "RentalPoints");

            migrationBuilder.DropTable(
                name: "Vehicles");

            migrationBuilder.DropTable(
                name: "client");
        }
    }
}
