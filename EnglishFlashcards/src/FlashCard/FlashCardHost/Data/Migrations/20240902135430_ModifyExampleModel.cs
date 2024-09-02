using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlashCard.Host.Data.Migrations
{
    /// <inheritdoc />
    public partial class ModifyExampleModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CountId",
                table: "ExampleModel",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CountId",
                table: "ExampleModel");
        }
    }
}
