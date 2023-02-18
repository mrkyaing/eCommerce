using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CMS.API.Migrations
{
    public partial class addNewColumnCouponModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AvailableQuantity",
                table: "Coupons",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AvailableQuantity",
                table: "Coupons");
        }
    }
}
