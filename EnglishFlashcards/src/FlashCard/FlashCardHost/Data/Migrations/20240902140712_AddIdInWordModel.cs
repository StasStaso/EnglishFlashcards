using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace FlashCard.Host.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddIdInWordModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExampleModel_Words_WordId",
                table: "ExampleModel");

            migrationBuilder.DropForeignKey(
                name: "FK_FlashCardModel_Words_WordId",
                table: "FlashCardModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Words",
                table: "Words");

            migrationBuilder.RenameColumn(
                name: "CountId",
                table: "ExampleModel",
                newName: "Index");

            migrationBuilder.AlterColumn<int>(
                name: "WordId",
                table: "Words",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Words",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Words",
                table: "Words",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ExampleModel_Words_WordId",
                table: "ExampleModel",
                column: "WordId",
                principalTable: "Words",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FlashCardModel_Words_WordId",
                table: "FlashCardModel",
                column: "WordId",
                principalTable: "Words",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExampleModel_Words_WordId",
                table: "ExampleModel");

            migrationBuilder.DropForeignKey(
                name: "FK_FlashCardModel_Words_WordId",
                table: "FlashCardModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Words",
                table: "Words");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Words");

            migrationBuilder.RenameColumn(
                name: "Index",
                table: "ExampleModel",
                newName: "CountId");

            migrationBuilder.AlterColumn<int>(
                name: "WordId",
                table: "Words",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Words",
                table: "Words",
                column: "WordId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExampleModel_Words_WordId",
                table: "ExampleModel",
                column: "WordId",
                principalTable: "Words",
                principalColumn: "WordId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FlashCardModel_Words_WordId",
                table: "FlashCardModel",
                column: "WordId",
                principalTable: "Words",
                principalColumn: "WordId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
