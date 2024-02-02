using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MottuApi.Repository.Migrations
{
    /// <inheritdoc />
    public partial class AddRentalPlansSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "RentalsPlan",
                columns: new[] { "Id", "DailyFinePercentage", "DailyPrice", "Days", "ExtraDayPrice" },
                values: new object[,]
                {
                    { 1, 20, 3000, 7, 5000 },
                    { 2, 40, 2800, 15, 5000 },
                    { 3, 60, 2200, 30, 5000 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RentalsPlan",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "RentalsPlan",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "RentalsPlan",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
