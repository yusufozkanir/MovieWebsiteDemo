using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieWebsiteDemo.Repository.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class mig_deneme1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WatchedMovie_AspNetUsers_Id",
                table: "WatchedMovie");

            migrationBuilder.DropForeignKey(
                name: "FK_WatchedMovie_Movies_MovieId",
                table: "WatchedMovie");

            migrationBuilder.DropIndex(
                name: "IX_WatchedMovie_MovieId",
                table: "WatchedMovie");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserRefreshToken",
                table: "UserRefreshToken");

            migrationBuilder.DropColumn(
                name: "MovieId",
                table: "WatchedMovie");

            migrationBuilder.DropColumn(
                name: "WatchedDate",
                table: "WatchedMovie");

            migrationBuilder.RenameTable(
                name: "UserRefreshToken",
                newName: "UserRefreshTokens");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "WatchedMovie",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserRefreshTokens",
                table: "UserRefreshTokens",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserRefreshTokens",
                table: "UserRefreshTokens");

            migrationBuilder.RenameTable(
                name: "UserRefreshTokens",
                newName: "UserRefreshToken");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "WatchedMovie",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "MovieId",
                table: "WatchedMovie",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "WatchedDate",
                table: "WatchedMovie",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserRefreshToken",
                table: "UserRefreshToken",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_WatchedMovie_MovieId",
                table: "WatchedMovie",
                column: "MovieId");

            migrationBuilder.AddForeignKey(
                name: "FK_WatchedMovie_AspNetUsers_Id",
                table: "WatchedMovie",
                column: "Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WatchedMovie_Movies_MovieId",
                table: "WatchedMovie",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
