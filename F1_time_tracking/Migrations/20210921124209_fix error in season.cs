using Microsoft.EntityFrameworkCore.Migrations;

namespace F1_time_tracking.Migrations
{
    public partial class fixerrorinseason : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SeasionId",
                table: "Races");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SeasionId",
                table: "Races",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
