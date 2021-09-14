using Microsoft.EntityFrameworkCore.Migrations;

namespace ABNAmro.Database.Migrations
{
    public partial class AddCalculationResult : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "CalculationResult",
                table: "Progresses",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CalculationResult",
                table: "Progresses");
        }
    }
}
