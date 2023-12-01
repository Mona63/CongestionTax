using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CongestionTax.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddTravel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tolls_Vehicles_VehicleId",
                table: "Tolls");

            migrationBuilder.RenameColumn(
                name: "VehicleId",
                table: "Tolls",
                newName: "TravelId");

            migrationBuilder.RenameColumn(
                name: "ActionAt",
                table: "Tolls",
                newName: "EvaluateAt");

            migrationBuilder.RenameIndex(
                name: "IX_Tolls_VehicleId",
                table: "Tolls",
                newName: "IX_Tolls_TravelId");

            migrationBuilder.CreateTable(
                name: "Travels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TravelAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    VehicleId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Travels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Travels_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Travels_VehicleId",
                table: "Travels",
                column: "VehicleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tolls_Travels_TravelId",
                table: "Tolls",
                column: "TravelId",
                principalTable: "Travels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tolls_Travels_TravelId",
                table: "Tolls");

            migrationBuilder.DropTable(
                name: "Travels");

            migrationBuilder.RenameColumn(
                name: "TravelId",
                table: "Tolls",
                newName: "VehicleId");

            migrationBuilder.RenameColumn(
                name: "EvaluateAt",
                table: "Tolls",
                newName: "ActionAt");

            migrationBuilder.RenameIndex(
                name: "IX_Tolls_TravelId",
                table: "Tolls",
                newName: "IX_Tolls_VehicleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tolls_Vehicles_VehicleId",
                table: "Tolls",
                column: "VehicleId",
                principalTable: "Vehicles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
