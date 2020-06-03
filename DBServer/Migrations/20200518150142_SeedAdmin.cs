using Microsoft.EntityFrameworkCore.Migrations;

namespace DBServer.Migrations
{
    public partial class SeedAdmin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Employees_EmployeeId",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_EmployeeId",
                table: "User");

            migrationBuilder.AlterColumn<long>(
                name: "EmployeeId",
                table: "User",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "EmployeeId", "Login", "Password", "Permissions" },
                values: new object[] { 1L, null, "admin", "admin", (short)0 });

            migrationBuilder.CreateIndex(
                name: "IX_User_EmployeeId",
                table: "User",
                column: "EmployeeId",
                unique: true,
                filter: "[EmployeeId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Employees_EmployeeId",
                table: "User",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Employees_EmployeeId",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_EmployeeId",
                table: "User");

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.AlterColumn<long>(
                name: "EmployeeId",
                table: "User",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_EmployeeId",
                table: "User",
                column: "EmployeeId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_User_Employees_EmployeeId",
                table: "User",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
