using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using YalcinHotel_DAL.Concrete.EfCore;

#nullable disable

namespace YalcinHotel_DAL.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20260927150000_AdminBootstrapSeed")]
    public partial class AdminBootstrapSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsAdminBootstrapped",
                table: "Customers",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(name: "IsAdminBootstrapped", table: "Customers");
        }
    }
}
