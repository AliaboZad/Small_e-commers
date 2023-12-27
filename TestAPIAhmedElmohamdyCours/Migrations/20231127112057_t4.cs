using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestAPIAhmedElmohamdyCours.Migrations
{
    public partial class t4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_items_category_CategoryId",
                table: "items");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "items",
                newName: "categoryId");

            migrationBuilder.RenameIndex(
                name: "IX_items_CategoryId",
                table: "items",
                newName: "IX_items_categoryId");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "items",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "category",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AddForeignKey(
                name: "FK_items_category_categoryId",
                table: "items",
                column: "categoryId",
                principalTable: "category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_items_category_categoryId",
                table: "items");

            migrationBuilder.RenameColumn(
                name: "categoryId",
                table: "items",
                newName: "CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_items_categoryId",
                table: "items",
                newName: "IX_items_CategoryId");

            migrationBuilder.AlterColumn<double>(
                name: "Price",
                table: "items",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<double>(
                name: "Price",
                table: "category",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddForeignKey(
                name: "FK_items_category_CategoryId",
                table: "items",
                column: "CategoryId",
                principalTable: "category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
