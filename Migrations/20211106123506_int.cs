using Microsoft.EntityFrameworkCore.Migrations;

namespace MyApplication.Migrations
{
    public partial class @int : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DbCashAdvance",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    requestBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    requestDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    approvedDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    approvedBY = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    requestStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Employee_Id = table.Column<int>(type: "int", nullable: false),
                    amount = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    department = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbCashAdvance", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DbDepartment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    hodName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbDepartment", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DbStaff",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NofKin = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NofKinPhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NofKinEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Relationship = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbStaff", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DbCashAdvance");

            migrationBuilder.DropTable(
                name: "DbDepartment");

            migrationBuilder.DropTable(
                name: "DbStaff");
        }
    }
}
