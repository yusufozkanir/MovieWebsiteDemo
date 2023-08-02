using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieWebsiteDemo.Repository.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class watchedmovie_table_add : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WatchedMovie",
                columns: table => new
                {
                    WatchedFilmId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    MovieId = table.Column<int>(type: "int", nullable: false),
                    WatchedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WatchedMovie", x => x.WatchedFilmId);
                    table.ForeignKey(
                        name: "FK_WatchedMovie_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "MovieId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WatchedMovie_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WatchedMovie_MovieId",
                table: "WatchedMovie",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_WatchedMovie_UserId",
                table: "WatchedMovie",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WatchedMovie");
        }
    }
}
