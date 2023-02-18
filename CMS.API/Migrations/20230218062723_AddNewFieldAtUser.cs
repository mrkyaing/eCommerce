using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CMS.API.Migrations
{
    public partial class AddNewFieldAtUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_memberCoupons_Coupons_CouponId",
                table: "memberCoupons");

            migrationBuilder.DropForeignKey(
                name: "FK_memberCoupons_Members_MemberId",
                table: "memberCoupons");

            migrationBuilder.DropPrimaryKey(
                name: "PK_memberCoupons",
                table: "memberCoupons");

            migrationBuilder.RenameTable(
                name: "memberCoupons",
                newName: "MemberCoupons");

            migrationBuilder.RenameIndex(
                name: "IX_memberCoupons_MemberId",
                table: "MemberCoupons",
                newName: "IX_MemberCoupons_MemberId");

            migrationBuilder.RenameIndex(
                name: "IX_memberCoupons_CouponId",
                table: "MemberCoupons",
                newName: "IX_MemberCoupons_CouponId");

            migrationBuilder.AddColumn<string>(
                name: "MemberId",
                table: "Users",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_MemberCoupons",
                table: "MemberCoupons",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Users_MemberId",
                table: "Users",
                column: "MemberId");

            migrationBuilder.AddForeignKey(
                name: "FK_MemberCoupons_Coupons_CouponId",
                table: "MemberCoupons",
                column: "CouponId",
                principalTable: "Coupons",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MemberCoupons_Members_MemberId",
                table: "MemberCoupons",
                column: "MemberId",
                principalTable: "Members",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Members_MemberId",
                table: "Users",
                column: "MemberId",
                principalTable: "Members",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MemberCoupons_Coupons_CouponId",
                table: "MemberCoupons");

            migrationBuilder.DropForeignKey(
                name: "FK_MemberCoupons_Members_MemberId",
                table: "MemberCoupons");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Members_MemberId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_MemberId",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MemberCoupons",
                table: "MemberCoupons");

            migrationBuilder.DropColumn(
                name: "MemberId",
                table: "Users");

            migrationBuilder.RenameTable(
                name: "MemberCoupons",
                newName: "memberCoupons");

            migrationBuilder.RenameIndex(
                name: "IX_MemberCoupons_MemberId",
                table: "memberCoupons",
                newName: "IX_memberCoupons_MemberId");

            migrationBuilder.RenameIndex(
                name: "IX_MemberCoupons_CouponId",
                table: "memberCoupons",
                newName: "IX_memberCoupons_CouponId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_memberCoupons",
                table: "memberCoupons",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_memberCoupons_Coupons_CouponId",
                table: "memberCoupons",
                column: "CouponId",
                principalTable: "Coupons",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_memberCoupons_Members_MemberId",
                table: "memberCoupons",
                column: "MemberId",
                principalTable: "Members",
                principalColumn: "Id");
        }
    }
}
