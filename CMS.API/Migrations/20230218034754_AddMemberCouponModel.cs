using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CMS.API.Migrations
{
    public partial class AddMemberCouponModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "memberCoupons",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CouponId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    MemberId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ReceiptNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UsedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_memberCoupons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_memberCoupons_Coupons_CouponId",
                        column: x => x.CouponId,
                        principalTable: "Coupons",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_memberCoupons_Members_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Members",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_memberCoupons_CouponId",
                table: "memberCoupons",
                column: "CouponId");

            migrationBuilder.CreateIndex(
                name: "IX_memberCoupons_MemberId",
                table: "memberCoupons",
                column: "MemberId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "memberCoupons");
        }
    }
}
