using Microsoft.EntityFrameworkCore.Migrations;

namespace DBServer.Migrations
{
    public partial class SetAdminPermissions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Permissions",
                value: (short)31);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Permissions",
                value: (short)0);
        }
    }
}
