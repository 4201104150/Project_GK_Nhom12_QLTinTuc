using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ProjectGKNhom12_QuanLyTinTuc.Migrations
{
    public partial class version02 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NguoiDungs",
                columns: table => new
                {
                    MaNguoiDung = table.Column<string>(nullable: false),
                    HoTen = table.Column<string>(nullable: true),
                    KieuNguoiDung = table.Column<int>(nullable: false),
                    MatKhau = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NguoiDungs", x => x.MaNguoiDung);
                });

            migrationBuilder.CreateTable(
                name: "TheLoais",
                columns: table => new
                {
                    MaTheLoai = table.Column<string>(nullable: false),
                    TenTheLoai = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TheLoais", x => x.MaTheLoai);
                });

            migrationBuilder.CreateTable(
                name: "TinTucs",
                columns: table => new
                {
                    MaTin = table.Column<string>(nullable: false),
                    Anh = table.Column<string>(nullable: true),
                    MaNguoiDung = table.Column<string>(nullable: true),
                    MaTheLoai = table.Column<string>(nullable: true),
                    NgayDang = table.Column<DateTime>(nullable: false),
                    NoiDung = table.Column<string>(nullable: true),
                    TieuDe = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TinTucs", x => x.MaTin);
                    table.ForeignKey(
                        name: "FK_TinTucs_NguoiDungs_MaNguoiDung",
                        column: x => x.MaNguoiDung,
                        principalTable: "NguoiDungs",
                        principalColumn: "MaNguoiDung",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TinTucs_TheLoais_MaTheLoai",
                        column: x => x.MaTheLoai,
                        principalTable: "TheLoais",
                        principalColumn: "MaTheLoai",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TinTucs_MaNguoiDung",
                table: "TinTucs",
                column: "MaNguoiDung");

            migrationBuilder.CreateIndex(
                name: "IX_TinTucs_MaTheLoai",
                table: "TinTucs",
                column: "MaTheLoai");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TinTucs");

            migrationBuilder.DropTable(
                name: "NguoiDungs");

            migrationBuilder.DropTable(
                name: "TheLoais");
        }
    }
}
