using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MottuApi.Repository.Migrations
{
    /// <inheritdoc />
    public partial class AddRentalPlanForeignKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RentalPlanId",
                table: "Rentals",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Rentals_RentalPlanId",
                table: "Rentals",
                column: "RentalPlanId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Rentals_RentalsPlan_RentalPlanId",
                table: "Rentals",
                column: "RentalPlanId",
                principalTable: "RentalsPlan",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rentals_RentalsPlan_RentalPlanId",
                table: "Rentals");

            migrationBuilder.DropIndex(
                name: "IX_Rentals_RentalPlanId",
                table: "Rentals");

            migrationBuilder.DropColumn(
                name: "RentalPlanId",
                table: "Rentals");
        }
    }
}
