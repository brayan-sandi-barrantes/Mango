using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mango.Services.CouponAPI.Migrations
{
    /// <inheritdoc />
    public partial class SeedCoupn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Coupons",
                keyColumn: "CouponId",
                keyValue: 1,
                column: "MinAmount",
                value: 20);

            migrationBuilder.UpdateData(
                table: "Coupons",
                keyColumn: "CouponId",
                keyValue: 2,
                column: "MinAmount",
                value: 40);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Coupons",
                keyColumn: "CouponId",
                keyValue: 1,
                column: "MinAmount",
                value: 100);

            migrationBuilder.UpdateData(
                table: "Coupons",
                keyColumn: "CouponId",
                keyValue: 2,
                column: "MinAmount",
                value: 200);
        }
    }
}
