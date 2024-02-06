using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Forum.Migrations
{
    public partial class UserPostJoinEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserPostJoinEntity_Posts_PostId",
                table: "UserPostJoinEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_UserPostJoinEntity_Users_UserId",
                table: "UserPostJoinEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserPostJoinEntity",
                table: "UserPostJoinEntity");

            migrationBuilder.RenameTable(
                name: "UserPostJoinEntity",
                newName: "UserPostJoinEntities");

            migrationBuilder.RenameIndex(
                name: "IX_UserPostJoinEntity_UserId",
                table: "UserPostJoinEntities",
                newName: "IX_UserPostJoinEntities_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserPostJoinEntity_PostId",
                table: "UserPostJoinEntities",
                newName: "IX_UserPostJoinEntities_PostId");

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Title",
                keyValue: null,
                column: "Title",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Posts",
                type: "varchar(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Body",
                keyValue: null,
                column: "Body",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Body",
                table: "Posts",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserPostJoinEntities",
                table: "UserPostJoinEntities",
                column: "UserPostJoinEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserPostJoinEntities_Posts_PostId",
                table: "UserPostJoinEntities",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "PostId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserPostJoinEntities_Users_UserId",
                table: "UserPostJoinEntities",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserPostJoinEntities_Posts_PostId",
                table: "UserPostJoinEntities");

            migrationBuilder.DropForeignKey(
                name: "FK_UserPostJoinEntities_Users_UserId",
                table: "UserPostJoinEntities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserPostJoinEntities",
                table: "UserPostJoinEntities");

            migrationBuilder.RenameTable(
                name: "UserPostJoinEntities",
                newName: "UserPostJoinEntity");

            migrationBuilder.RenameIndex(
                name: "IX_UserPostJoinEntities_UserId",
                table: "UserPostJoinEntity",
                newName: "IX_UserPostJoinEntity_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserPostJoinEntities_PostId",
                table: "UserPostJoinEntity",
                newName: "IX_UserPostJoinEntity_PostId");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Posts",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldMaxLength: 255)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Body",
                table: "Posts",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserPostJoinEntity",
                table: "UserPostJoinEntity",
                column: "UserPostJoinEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserPostJoinEntity_Posts_PostId",
                table: "UserPostJoinEntity",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "PostId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserPostJoinEntity_Users_UserId",
                table: "UserPostJoinEntity",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
