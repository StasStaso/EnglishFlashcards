using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace FlashCard.Host.Data.Migrations
{
    /// <inheritdoc />
    public partial class RemoveExample : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FlashCardModel_StatusModels_StatusId",
                table: "FlashCardModel");

            migrationBuilder.DropForeignKey(
                name: "FK_FlashCardModel_Words_WordId",
                table: "FlashCardModel");

            migrationBuilder.DropTable(
                name: "ExampleModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FlashCardModel",
                table: "FlashCardModel");

            migrationBuilder.RenameTable(
                name: "FlashCardModel",
                newName: "FlashCards");

            migrationBuilder.RenameIndex(
                name: "IX_FlashCardModel_WordId",
                table: "FlashCards",
                newName: "IX_FlashCards_WordId");

            migrationBuilder.RenameIndex(
                name: "IX_FlashCardModel_StatusId",
                table: "FlashCards",
                newName: "IX_FlashCards_StatusId");

            migrationBuilder.AddColumn<List<string>>(
                name: "Examples",
                table: "Words",
                type: "text[]",
                nullable: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_FlashCards",
                table: "FlashCards",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FlashCards_StatusModels_StatusId",
                table: "FlashCards",
                column: "StatusId",
                principalTable: "StatusModels",
                principalColumn: "StatusId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FlashCards_Words_WordId",
                table: "FlashCards",
                column: "WordId",
                principalTable: "Words",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FlashCards_StatusModels_StatusId",
                table: "FlashCards");

            migrationBuilder.DropForeignKey(
                name: "FK_FlashCards_Words_WordId",
                table: "FlashCards");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FlashCards",
                table: "FlashCards");

            migrationBuilder.DropColumn(
                name: "Examples",
                table: "Words");

            migrationBuilder.RenameTable(
                name: "FlashCards",
                newName: "FlashCardModel");

            migrationBuilder.RenameIndex(
                name: "IX_FlashCards_WordId",
                table: "FlashCardModel",
                newName: "IX_FlashCardModel_WordId");

            migrationBuilder.RenameIndex(
                name: "IX_FlashCards_StatusId",
                table: "FlashCardModel",
                newName: "IX_FlashCardModel_StatusId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FlashCardModel",
                table: "FlashCardModel",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "ExampleModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    WordId = table.Column<int>(type: "integer", nullable: false),
                    ExampleText = table.Column<string>(type: "text", nullable: false),
                    Index = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExampleModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExampleModel_Words_WordId",
                        column: x => x.WordId,
                        principalTable: "Words",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExampleModel_WordId",
                table: "ExampleModel",
                column: "WordId");

            migrationBuilder.AddForeignKey(
                name: "FK_FlashCardModel_StatusModels_StatusId",
                table: "FlashCardModel",
                column: "StatusId",
                principalTable: "StatusModels",
                principalColumn: "StatusId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FlashCardModel_Words_WordId",
                table: "FlashCardModel",
                column: "WordId",
                principalTable: "Words",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
