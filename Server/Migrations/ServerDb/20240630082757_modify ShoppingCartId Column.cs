using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Server.Migrations.ServerDb
{
    /// <inheritdoc />
    public partial class modifyShoppingCartIdColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UsertId",
                table: "ProductAddedShCart",
                newName: "UserId");

            migrationBuilder.AlterColumn<string>(
                name: "ShoppingCartId",
                table: "ProductAddedShCart",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "ProductAddedShCart",
                newName: "UsertId");

            migrationBuilder.AlterColumn<int>(
                name: "ShoppingCartId",
                table: "ProductAddedShCart",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
