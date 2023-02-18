using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CMS.API.Migrations
{
    public partial class AddNewFieldAtCoupon : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "Coupons",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Code",
                table: "Coupons");
        }
    }
}
