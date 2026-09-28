using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using YalcinHotel_DAL.Concrete.EfCore;

#nullable disable

namespace YalcinHotel_DAL.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20260927130000_CustomerProfileAndRole")]
    public partial class CustomerProfileAndRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "Customers",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "Customer");

            migrationBuilder.AddColumn<string>(
                name: "ProfileImageUrl",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(name: "Role", table: "Customers");
            migrationBuilder.DropColumn(name: "ProfileImageUrl", table: "Customers");
        }
    }
}
