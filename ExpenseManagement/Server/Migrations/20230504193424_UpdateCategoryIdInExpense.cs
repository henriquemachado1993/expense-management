using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExpenseManagement.Server.Migrations
{
    public partial class UpdateCategoryIdInExpense : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Expense_Category_CategoryId1",
                table: "Expense");

            migrationBuilder.DropIndex(
                name: "IX_Expense_CategoryId1",
                table: "Expense");

            migrationBuilder.DropColumn(
                name: "CategoryId1",
                table: "Expense");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "Expense",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Expense_CategoryId",
                table: "Expense",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Expense_Category_CategoryId",
                table: "Expense",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Expense_Category_CategoryId",
                table: "Expense");

            migrationBuilder.DropIndex(
                name: "IX_Expense_CategoryId",
                table: "Expense");

            migrationBuilder.AlterColumn<string>(
                name: "CategoryId",
                table: "Expense",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId1",
                table: "Expense",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Expense_CategoryId1",
                table: "Expense",
                column: "CategoryId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Expense_Category_CategoryId1",
                table: "Expense",
                column: "CategoryId1",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
