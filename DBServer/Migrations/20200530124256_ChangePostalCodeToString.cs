using Microsoft.EntityFrameworkCore.Migrations;

namespace DBServer.Migrations
{
    public partial class ChangePostalCodeToString : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PostalCode",
                table: "Suppliers",
                maxLength: 6,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 6);

            migrationBuilder.AlterColumn<string>(
                name: "PostalCode",
                table: "Customers",
                maxLength: 6,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 6);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "PostalCode",
                table: "Suppliers",
                type: "int",
                maxLength: 6,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 6);

            migrationBuilder.AlterColumn<int>(
                name: "PostalCode",
                table: "Customers",
                type: "int",
                maxLength: 6,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 6);
        }
    }
}
