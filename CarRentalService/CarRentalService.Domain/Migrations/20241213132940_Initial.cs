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
                name: "rental_point",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    address = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rental_point", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "vehicle",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    model = table.Column<string>(type: "text", nullable: false),
                    color = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vehicle", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "rental_record",
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
                    table.PrimaryKey("PK_rental_record", x => x.id);
                    table.ForeignKey(
                        name: "FK_rental_record_client_client",
                        column: x => x.client,
                        principalTable: "client",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_rental_record_rental_point_rental_point",
                        column: x => x.rental_point,
                        principalTable: "rental_point",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_rental_record_rental_point_return_point",
                        column: x => x.return_point,
                        principalTable: "rental_point",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_rental_record_vehicle_vehicle",
                        column: x => x.vehicle,
                        principalTable: "vehicle",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_rental_record_client",
                table: "rental_record",
                column: "client");

            migrationBuilder.CreateIndex(
                name: "IX_rental_record_rental_point",
                table: "rental_record",
                column: "rental_point");

            migrationBuilder.CreateIndex(
                name: "IX_rental_record_return_point",
                table: "rental_record",
                column: "return_point");

            migrationBuilder.CreateIndex(
                name: "IX_rental_record_vehicle",
                table: "rental_record",
                column: "vehicle");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "rental_record");

            migrationBuilder.DropTable(
                name: "client");

            migrationBuilder.DropTable(
                name: "rental_point");

            migrationBuilder.DropTable(
                name: "vehicle");
        }
    }
}
