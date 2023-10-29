using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hue_Festival_Online_Ticket.Migrations
{
    public partial class CreateDb_V0 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Doan",
                columns: table => new
                {
                    ID_doan = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nhom_doan = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doan", x => x.ID_doan);
                });

            migrationBuilder.CreateTable(
                name: "Hotro",
                columns: table => new
                {
                    ID_hotro = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Hotro_title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Hotro_content = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hotro", x => x.ID_hotro);
                });

            migrationBuilder.CreateTable(
                name: "Menu",
                columns: table => new
                {
                    ID_menu = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Menu_title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PathIcon = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menu", x => x.ID_menu);
                });

            migrationBuilder.CreateTable(
                name: "Nhom",
                columns: table => new
                {
                    ID_nhom = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nhom_name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nhom", x => x.ID_nhom);
                });

            migrationBuilder.CreateTable(
                name: "Tintuc",
                columns: table => new
                {
                    ID_tintuc = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tintuc_title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tintuc_content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tintuc_time = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tintuc", x => x.ID_tintuc);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    ID_user = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    User_password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    User_phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    User_role = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.ID_user);
                });

            migrationBuilder.CreateTable(
                name: "Submenu",
                columns: table => new
                {
                    ID_submenu = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Submenu_title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PathIcon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Menu_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Submenu", x => x.ID_submenu);
                    table.ForeignKey(
                        name: "FK_SubMenuDb_Menu",
                        column: x => x.Menu_id,
                        principalTable: "Menu",
                        principalColumn: "ID_menu",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TintucImage",
                columns: table => new
                {
                    ID_image = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Image_path = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tintuc_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TintucImage", x => x.ID_image);
                    table.ForeignKey(
                        name: "FK_TinTucImageDb_TinTuc",
                        column: x => x.Tintuc_id,
                        principalTable: "Tintuc",
                        principalColumn: "ID_tintuc",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HotroUser",
                columns: table => new
                {
                    ID_hotro_user = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User_id = table.Column<int>(type: "int", nullable: true),
                    Hotro_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotroUser", x => x.ID_hotro_user);
                    table.ForeignKey(
                        name: "FK_HoTroUserDb_Hotro",
                        column: x => x.Hotro_id,
                        principalTable: "Hotro",
                        principalColumn: "ID_hotro",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HoTroUserDb_User",
                        column: x => x.User_id,
                        principalTable: "User",
                        principalColumn: "ID_user",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TintucYeuthich",
                columns: table => new
                {
                    ID_wish_tintuc = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsWish = table.Column<bool>(type: "bit", nullable: true),
                    User_id = table.Column<int>(type: "int", nullable: true),
                    Tintuc_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TintucYeuthich", x => x.ID_wish_tintuc);
                    table.ForeignKey(
                        name: "FK_TinTucYeuThichDb_TinTuc",
                        column: x => x.Tintuc_id,
                        principalTable: "Tintuc",
                        principalColumn: "ID_tintuc",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TinTucYeuThichDb_User",
                        column: x => x.User_id,
                        principalTable: "User",
                        principalColumn: "ID_user",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Diadiem",
                columns: table => new
                {
                    ID_diadiem = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Diadiem_title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Diadiem_summary = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Diadiem_content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PathImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Longtitude = table.Column<double>(type: "float", nullable: true),
                    Latitude = table.Column<double>(type: "float", nullable: true),
                    Submenu_id = table.Column<int>(type: "int", nullable: true),
                    Number_phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Diachi = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diadiem", x => x.ID_diadiem);
                    table.ForeignKey(
                        name: "FK_DiaDiemDb_Submenu",
                        column: x => x.Submenu_id,
                        principalTable: "Submenu",
                        principalColumn: "ID_submenu",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Chuongtrinh",
                columns: table => new
                {
                    ID_chuongtrinh = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Chuongtrinh_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Chuongtrinh_content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type_inoff = table.Column<int>(type: "int", nullable: true),
                    Price = table.Column<int>(type: "int", nullable: true),
                    Type_program = table.Column<int>(type: "int", nullable: true),
                    Diadiem_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chuongtrinh", x => x.ID_chuongtrinh);
                    table.ForeignKey(
                        name: "FK_ChuongTrinhDb_Diadiem",
                        column: x => x.Diadiem_id,
                        principalTable: "Diadiem",
                        principalColumn: "ID_diadiem",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChuongtrinhImage",
                columns: table => new
                {
                    ID_image = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Image_path = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Chuongtrinh_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChuongtrinhImage", x => x.ID_image);
                    table.ForeignKey(
                        name: "FK_ChuongTrinhImageDb_Chuongtrinh",
                        column: x => x.Chuongtrinh_id,
                        principalTable: "Chuongtrinh",
                        principalColumn: "ID_chuongtrinh",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChuongtrinhYeuthich",
                columns: table => new
                {
                    ID_chuongtrinh_yeuthich = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsWish = table.Column<bool>(type: "bit", nullable: true),
                    User_id = table.Column<int>(type: "int", nullable: true),
                    Chuongtrinh_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChuongtrinhYeuthich", x => x.ID_chuongtrinh_yeuthich);
                    table.ForeignKey(
                        name: "FK_ChuongTrinhYeuThichDb_Chuongtrinh",
                        column: x => x.Chuongtrinh_id,
                        principalTable: "Chuongtrinh",
                        principalColumn: "ID_chuongtrinh",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChuongTrinhYeuThichDb_User",
                        column: x => x.User_id,
                        principalTable: "User",
                        principalColumn: "ID_user",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DiadiemSoatve",
                columns: table => new
                {
                    ID_diadiem_soatve = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Start_time = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    End_time = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Chuongtrinh_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiadiemSoatve", x => x.ID_diadiem_soatve);
                    table.ForeignKey(
                        name: "FK_DiaDiemSoatVeDb_Chuongtrinh",
                        column: x => x.Chuongtrinh_id,
                        principalTable: "Chuongtrinh",
                        principalColumn: "ID_chuongtrinh",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Lichdien",
                columns: table => new
                {
                    ID_lichdien = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Time = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fdate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Tdate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Chuongtrinh_id = table.Column<int>(type: "int", nullable: true),
                    Nhom_id = table.Column<int>(type: "int", nullable: true),
                    Doan_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lichdien", x => x.ID_lichdien);
                    table.ForeignKey(
                        name: "FK_LichDienDb_Chuongtrinh",
                        column: x => x.Chuongtrinh_id,
                        principalTable: "Chuongtrinh",
                        principalColumn: "ID_chuongtrinh",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LichDienDb_Doan",
                        column: x => x.Doan_id,
                        principalTable: "Doan",
                        principalColumn: "ID_doan",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LichDienDb_Nhom",
                        column: x => x.Nhom_id,
                        principalTable: "Nhom",
                        principalColumn: "ID_nhom",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ve",
                columns: table => new
                {
                    ID_ve = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<int>(type: "int", nullable: true),
                    User_id = table.Column<int>(type: "int", nullable: true),
                    Chuongtrinh_id = table.Column<int>(type: "int", nullable: true),
                    NV_soatve = table.Column<int>(type: "int", nullable: true),
                    Date_soatve = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ve", x => x.ID_ve);
                    table.ForeignKey(
                        name: "FK_VeDb_Chuongtrinh",
                        column: x => x.Chuongtrinh_id,
                        principalTable: "Chuongtrinh",
                        principalColumn: "ID_chuongtrinh",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VeDb_User",
                        column: x => x.User_id,
                        principalTable: "User",
                        principalColumn: "ID_user",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Chuongtrinh_Diadiem_id",
                table: "Chuongtrinh",
                column: "Diadiem_id");

            migrationBuilder.CreateIndex(
                name: "IX_ChuongtrinhImage_Chuongtrinh_id",
                table: "ChuongtrinhImage",
                column: "Chuongtrinh_id");

            migrationBuilder.CreateIndex(
                name: "IX_ChuongtrinhYeuthich_Chuongtrinh_id",
                table: "ChuongtrinhYeuthich",
                column: "Chuongtrinh_id");

            migrationBuilder.CreateIndex(
                name: "IX_ChuongtrinhYeuthich_User_id",
                table: "ChuongtrinhYeuthich",
                column: "User_id");

            migrationBuilder.CreateIndex(
                name: "IX_Diadiem_Submenu_id",
                table: "Diadiem",
                column: "Submenu_id");

            migrationBuilder.CreateIndex(
                name: "IX_DiadiemSoatve_Chuongtrinh_id",
                table: "DiadiemSoatve",
                column: "Chuongtrinh_id");

            migrationBuilder.CreateIndex(
                name: "IX_HotroUser_Hotro_id",
                table: "HotroUser",
                column: "Hotro_id");

            migrationBuilder.CreateIndex(
                name: "IX_HotroUser_User_id",
                table: "HotroUser",
                column: "User_id");

            migrationBuilder.CreateIndex(
                name: "IX_Lichdien_Chuongtrinh_id",
                table: "Lichdien",
                column: "Chuongtrinh_id");

            migrationBuilder.CreateIndex(
                name: "IX_Lichdien_Doan_id",
                table: "Lichdien",
                column: "Doan_id");

            migrationBuilder.CreateIndex(
                name: "IX_Lichdien_Nhom_id",
                table: "Lichdien",
                column: "Nhom_id");

            migrationBuilder.CreateIndex(
                name: "IX_Submenu_Menu_id",
                table: "Submenu",
                column: "Menu_id");

            migrationBuilder.CreateIndex(
                name: "IX_TintucImage_Tintuc_id",
                table: "TintucImage",
                column: "Tintuc_id");

            migrationBuilder.CreateIndex(
                name: "IX_TintucYeuthich_Tintuc_id",
                table: "TintucYeuthich",
                column: "Tintuc_id");

            migrationBuilder.CreateIndex(
                name: "IX_TintucYeuthich_User_id",
                table: "TintucYeuthich",
                column: "User_id");

            migrationBuilder.CreateIndex(
                name: "IX_Ve_Chuongtrinh_id",
                table: "Ve",
                column: "Chuongtrinh_id");

            migrationBuilder.CreateIndex(
                name: "IX_Ve_User_id",
                table: "Ve",
                column: "User_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChuongtrinhImage");

            migrationBuilder.DropTable(
                name: "ChuongtrinhYeuthich");

            migrationBuilder.DropTable(
                name: "DiadiemSoatve");

            migrationBuilder.DropTable(
                name: "HotroUser");

            migrationBuilder.DropTable(
                name: "Lichdien");

            migrationBuilder.DropTable(
                name: "TintucImage");

            migrationBuilder.DropTable(
                name: "TintucYeuthich");

            migrationBuilder.DropTable(
                name: "Ve");

            migrationBuilder.DropTable(
                name: "Hotro");

            migrationBuilder.DropTable(
                name: "Doan");

            migrationBuilder.DropTable(
                name: "Nhom");

            migrationBuilder.DropTable(
                name: "Tintuc");

            migrationBuilder.DropTable(
                name: "Chuongtrinh");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Diadiem");

            migrationBuilder.DropTable(
                name: "Submenu");

            migrationBuilder.DropTable(
                name: "Menu");
        }
    }
}
