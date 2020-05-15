using Microsoft.EntityFrameworkCore.Migrations;

namespace JavaGameAPI.Migrations
{
    public partial class required_fields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Level_User_Creatorid",
                table: "Level");

            migrationBuilder.DropForeignKey(
                name: "FK_Score_Level_ScoredOnID",
                table: "Score");

            migrationBuilder.DropForeignKey(
                name: "FK_Score_User_Userid",
                table: "Score");

            migrationBuilder.AlterColumn<int>(
                name: "Userid",
                table: "Score",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ScoredOnID",
                table: "Score",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Creatorid",
                table: "Level",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Level_User_Creatorid",
                table: "Level",
                column: "Creatorid",
                principalTable: "User",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Score_Level_ScoredOnID",
                table: "Score",
                column: "ScoredOnID",
                principalTable: "Level",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Score_User_Userid",
                table: "Score",
                column: "Userid",
                principalTable: "User",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Level_User_Creatorid",
                table: "Level");

            migrationBuilder.DropForeignKey(
                name: "FK_Score_Level_ScoredOnID",
                table: "Score");

            migrationBuilder.DropForeignKey(
                name: "FK_Score_User_Userid",
                table: "Score");

            migrationBuilder.AlterColumn<int>(
                name: "Userid",
                table: "Score",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "ScoredOnID",
                table: "Score",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "Creatorid",
                table: "Level",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Level_User_Creatorid",
                table: "Level",
                column: "Creatorid",
                principalTable: "User",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Score_Level_ScoredOnID",
                table: "Score",
                column: "ScoredOnID",
                principalTable: "Level",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Score_User_Userid",
                table: "Score",
                column: "Userid",
                principalTable: "User",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
