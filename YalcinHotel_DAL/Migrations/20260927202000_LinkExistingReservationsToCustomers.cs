using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using YalcinHotel_DAL.Concrete.EfCore;

#nullable disable

namespace YalcinHotel_DAL.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20260927202000_LinkExistingReservationsToCustomers")]
    public partial class LinkExistingReservationsToCustomers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                UPDATE reservation
                SET reservation.CustomerId = customer.Id
                FROM dbo.Reservations AS reservation
                CROSS APPLY
                (
                    SELECT TOP (1) Id
                    FROM dbo.Customers
                    WHERE LOWER(LTRIM(RTRIM(Email))) = LOWER(LTRIM(RTRIM(reservation.CustomerEmail)))
                    ORDER BY Id
                ) AS customer
                WHERE reservation.CustomerId IS NULL;
            ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // This migration only fills missing account links; reverting would
            // discard valid ownership data, so it intentionally leaves rows intact.
        }
    }
}
