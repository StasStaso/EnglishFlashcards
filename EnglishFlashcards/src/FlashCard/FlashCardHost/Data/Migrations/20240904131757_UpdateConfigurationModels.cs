using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlashCard.Host.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateConfigurationModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FlashCards_StatusModels_StatusId",
                table: "FlashCards");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StatusModels",
                table: "StatusModels");

            migrationBuilder.RenameTable(
                name: "StatusModels",
                newName: "Status");

            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "Words",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "PronunciationUkMp3",
                table: "Words",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneticsUk",
                table: "Words",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Level",
                table: "Words",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<int>(
                name: "StatusId",
                table: "FlashCards",
                type: "integer",
                nullable: false,
                defaultValue: 1,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<string>(
                name: "StatusName",
                table: "Status",
                type: "character varying(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Status",
                table: "Status",
                column: "StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_FlashCards_Status_StatusId",
                table: "FlashCards",
                column: "StatusId",
                principalTable: "Status",
                principalColumn: "StatusId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FlashCards_Status_StatusId",
                table: "FlashCards");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Status",
                table: "Status");

            migrationBuilder.RenameTable(
                name: "Status",
                newName: "StatusModels");

            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "Words",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PronunciationUkMp3",
                table: "Words",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PhoneticsUk",
                table: "Words",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Level",
                table: "Words",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "StatusId",
                table: "FlashCards",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer",
                oldDefaultValue: 1);

            migrationBuilder.AlterColumn<string>(
                name: "StatusName",
                table: "StatusModels",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(30)",
                oldMaxLength: 30);

            migrationBuilder.AddPrimaryKey(
                name: "PK_StatusModels",
                table: "StatusModels",
                column: "StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_FlashCards_StatusModels_StatusId",
                table: "FlashCards",
                column: "StatusId",
                principalTable: "StatusModels",
                principalColumn: "StatusId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
