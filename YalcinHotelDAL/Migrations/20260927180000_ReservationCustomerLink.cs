using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using YalcinHotel_DAL.Concrete.EfCore;

#nullable disable

namespace YalcinHotel_DAL.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20260927180000_ReservationCustomerLink")]
    public partial class ReservationCustomerLink : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "Reservations",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(name: "CustomerId", table: "Reservations");
        }
    }
}
