using Microsoft.EntityFrameworkCore.Migrations;

namespace GoodApple.Migrations
{
    public partial class secMig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProjectId",
                table: "users",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "projects",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "projects",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_users_ProjectId",
                table: "users",
                column: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_users_projects_ProjectId",
                table: "users",
                column: "ProjectId",
                principalTable: "projects",
                principalColumn: "ProjectId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_users_projects_ProjectId",
                table: "users");

            migrationBuilder.DropIndex(
                name: "IX_users_ProjectId",
                table: "users");

            migrationBuilder.DropColumn(
                name: "ProjectId",
                table: "users");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "projects",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "projects",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
