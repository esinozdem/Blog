using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class mig_notificition_add_table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Notificitions",
                columns: table => new
                {
                    NotificitionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NotificitionType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NotificitionTypeSymbol = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NotificitionDetails = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NotificitionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NotificitionStatus = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notificitions", x => x.NotificitionID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Notificitions");
        }
    }
}
