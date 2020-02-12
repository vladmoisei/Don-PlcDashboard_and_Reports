using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Don_PlcDashboard_and_Reports.Migrations
{
    public partial class AddDefectModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Defects",
                columns: table => new
                {
                    DefectID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlcModelID = table.Column<int>(maxLength: 50, nullable: false),
                    TimpStartDefect = table.Column<DateTime>(nullable: false),
                    TimpStopDefect = table.Column<DateTime>(nullable: false),
                    IntervalStationare = table.Column<TimeSpan>(nullable: false),
                    MotivStationare = table.Column<string>(maxLength: 50, nullable: true),
                    DefectFinalizat = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Defects", x => x.DefectID);
                    table.ForeignKey(
                        name: "FK_Defects_Plcs_PlcModelID",
                        column: x => x.PlcModelID,
                        principalTable: "Plcs",
                        principalColumn: "PlcModelID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Defects_PlcModelID",
                table: "Defects",
                column: "PlcModelID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Defects");
        }
    }
}
