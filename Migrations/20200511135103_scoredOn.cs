using Microsoft.EntityFrameworkCore.Migrations;

namespace JavaGameAPI.Migrations
{
    public partial class scoredOn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ScoredOnID",
                table: "Score",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Achievement",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext CHARACTER SET utf8mb4",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Score_ScoredOnID",
                table: "Score",
                column: "ScoredOnID");

            migrationBuilder.AddForeignKey(
                name: "FK_Score_Level_ScoredOnID",
                table: "Score",
                column: "ScoredOnID",
                principalTable: "Level",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Score_Level_ScoredOnID",
                table: "Score");

            migrationBuilder.DropIndex(
                name: "IX_Score_ScoredOnID",
                table: "Score");

            migrationBuilder.DropColumn(
                name: "ScoredOnID",
                table: "Score");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Achievement",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
