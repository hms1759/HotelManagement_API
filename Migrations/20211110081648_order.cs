using Microsoft.EntityFrameworkCore.Migrations;

namespace MyApplication.Migrations
{
    public partial class order : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DbOrder",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ScheduleDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ScheduleTimeIn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ScheduleTimeOut = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    vistorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbOrder", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DbOrder");
        }
    }
}
