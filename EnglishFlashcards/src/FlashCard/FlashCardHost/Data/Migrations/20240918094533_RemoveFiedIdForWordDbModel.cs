using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlashCard.Host.Data.Migrations
{
    /// <inheritdoc />
    public partial class RemoveFiedIdForWordDbModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WordId",
                table: "Words");

            migrationBuilder.AlterColumn<int>(
                name: "StatusId",
                table: "FlashCards",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer",
                oldDefaultValue: 1);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "WordId",
                table: "Words",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "StatusId",
                table: "FlashCards",
                type: "integer",
                nullable: false,
                defaultValue: 1,
                oldClrType: typeof(int),
                oldType: "integer");
        }
    }
}
