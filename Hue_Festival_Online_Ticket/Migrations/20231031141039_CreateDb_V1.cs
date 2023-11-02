using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hue_Festival_Online_Ticket.Migrations
{
    public partial class CreateDb_V1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DiaDiemYeuThichDb",
                columns: table => new
                {
                    ID_diadiem_yeuthich = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsWish = table.Column<bool>(type: "bit", nullable: true),
                    User_id = table.Column<int>(type: "int", nullable: true),
                    Diadiem_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiaDiemYeuThichDb", x => x.ID_diadiem_yeuthich);
                    table.ForeignKey(
                        name: "FK_DiaDiemYeuThichDb_Diadiem",
                        column: x => x.Diadiem_id,
                        principalTable: "Diadiem",
                        principalColumn: "ID_diadiem",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DiaDiemYeuThichDb_User",
                        column: x => x.User_id,
                        principalTable: "User",
                        principalColumn: "ID_user",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DiaDiemYeuThichDb_Diadiem_id",
                table: "DiaDiemYeuThichDb",
                column: "Diadiem_id");

            migrationBuilder.CreateIndex(
                name: "IX_DiaDiemYeuThichDb_User_id",
                table: "DiaDiemYeuThichDb",
                column: "User_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DiaDiemYeuThichDb");
        }
    }
}
