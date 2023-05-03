using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExpenseManagement.Server.Migrations
{
    public partial class UpdateFieldRequiredAudited : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserIdentifier",
                table: "Expense",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "UserIdentifier",
                table: "Category",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "UserIdentifier",
                table: "BankAccounts",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Expense",
                keyColumn: "UserIdentifier",
                keyValue: null,
                column: "UserIdentifier",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "UserIdentifier",
                table: "Expense",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "UserIdentifier",
                keyValue: null,
                column: "UserIdentifier",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "UserIdentifier",
                table: "Category",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "BankAccounts",
                keyColumn: "UserIdentifier",
                keyValue: null,
                column: "UserIdentifier",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "UserIdentifier",
                table: "BankAccounts",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }
    }
}
