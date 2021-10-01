using Microsoft.EntityFrameworkCore.Migrations;

namespace F1_time_tracking.Migrations
{
    public partial class ntom_Driver_Team : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Drivers_Teams_TeamId",
                table: "Drivers");

            migrationBuilder.DropIndex(
                name: "IX_Drivers_TeamId",
                table: "Drivers");

            migrationBuilder.CreateTable(
                name: "DriverTeam",
                columns: table => new
                {
                    DriversId = table.Column<int>(type: "int", nullable: false),
                    TeamId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DriverTeam", x => new { x.DriversId, x.TeamId });
                    table.ForeignKey(
                        name: "FK_DriverTeam_Drivers_DriversId",
                        column: x => x.DriversId,
                        principalTable: "Drivers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DriverTeam_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DriverTeam_TeamId",
                table: "DriverTeam",
                column: "TeamId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DriverTeam");

            migrationBuilder.CreateIndex(
                name: "IX_Drivers_TeamId",
                table: "Drivers",
                column: "TeamId");

            migrationBuilder.AddForeignKey(
                name: "FK_Drivers_Teams_TeamId",
                table: "Drivers",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
