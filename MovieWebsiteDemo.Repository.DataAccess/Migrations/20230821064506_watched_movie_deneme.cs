using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieWebsiteDemo.Repository.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class watched_movie_deneme : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_WatchedMovie",
                table: "WatchedMovie");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WatchedMovie",
                table: "WatchedMovie",
                columns: new[] { "Id", "MovieId" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_WatchedMovie",
                table: "WatchedMovie");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WatchedMovie",
                table: "WatchedMovie",
                column: "Id");
        }
    }
}
