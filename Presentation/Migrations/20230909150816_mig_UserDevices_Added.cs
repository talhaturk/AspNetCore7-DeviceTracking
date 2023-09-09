using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Presentation.Migrations
{
    /// <inheritdoc />
    public partial class mig_UserDevices_Added : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "UserDevices",
                columns: new[] { "UserDevicesId", "AppUserId", "DeviceId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 2 },
                    { 3, 3, 3 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserDevices",
                keyColumn: "UserDevicesId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "UserDevices",
                keyColumn: "UserDevicesId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "UserDevices",
                keyColumn: "UserDevicesId",
                keyValue: 3);
        }
    }
}
