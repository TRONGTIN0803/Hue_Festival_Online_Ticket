using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hue_Festival_Online_Ticket.Migrations
{
    public partial class createDb_V3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Nhom_doan",
                table: "Doan",
                newName: "Doan_name");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Doan_name",
                table: "Doan",
                newName: "Nhom_doan");
        }
    }
}
