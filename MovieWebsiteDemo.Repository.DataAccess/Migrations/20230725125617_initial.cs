using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieWebsiteDemo.Repository.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class İnitial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Actors",
                columns: table => new
                {
                    ActorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ActorName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ActorBirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ActorPhoto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ActorBiography = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ActorFilmography = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actors", x => x.ActorId);
                });

            migrationBuilder.CreateTable(
                name: "Directors",
                columns: table => new
                {
                    DirectorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DirectorName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DirectorBirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DirectorPhoto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DirectorBiography = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Directors", x => x.DirectorId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserMail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserPassword = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    MovieId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MovieTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Producer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ScreenWriter = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MovieType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MovieDuration = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MovieReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MovieSummary = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MovieRating = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MovieTrailer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DirectorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.MovieId);
                    table.ForeignKey(
                        name: "FK_Movies_Directors_DirectorId",
                        column: x => x.DirectorId,
                        principalTable: "Directors",
                        principalColumn: "DirectorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MovieActor",
                columns: table => new
                {
                    MovieId = table.Column<int>(type: "int", nullable: false),
                    ActorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieActor", x => new { x.MovieId, x.ActorId });
                    table.ForeignKey(
                        name: "FK_MovieActor_Actors_ActorId",
                        column: x => x.ActorId,
                        principalTable: "Actors",
                        principalColumn: "ActorId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MovieActor_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "MovieId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserMovie",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    MovieId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserMovie", x => new { x.UserId, x.MovieId });
                    table.ForeignKey(
                        name: "FK_UserMovie_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "MovieId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserMovie_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Directors",
                columns: new[] { "DirectorId", "DirectorBiography", "DirectorBirthDate", "DirectorName", "DirectorPhoto" },
                values: new object[] { 1, "Jonathan Kolia Favreau, kısaca Jon Favreau, Amerikalı oyuncu ve yönetmendir. En iyi Şef filmi ve Iron Man serisi dahil olmak üzere Marvel Sinematik Evreni'nde canlandırdığı Happy karakteri ile bilinir. Ayrıca yönetmenliğini yaptığı filmler arasında Iron Man ve Iron Man 2 bulunur. Aynı zamanda ünlü komedi dizisi Friends de Monica'nını milyoner erkek arkadaşı Pete Becker'ı canlandırmıştır.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jon Favreau", "-" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "UserMail", "UserName", "UserPassword" },
                values: new object[] { 1, "yusuf@gmail.com", "Yusuf", 123 });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "MovieId", "DirectorId", "MovieDuration", "MovieRating", "MovieReleaseDate", "MovieSummary", "MovieTitle", "MovieTrailer", "MovieType", "Producer", "ScreenWriter" },
                values: new object[] { 1, 1, 0m, 0m, new DateTime(2008, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Iron Man", null, null, null, null });

            migrationBuilder.CreateIndex(
                name: "IX_MovieActor_ActorId",
                table: "MovieActor",
                column: "ActorId");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_DirectorId",
                table: "Movies",
                column: "DirectorId");

            migrationBuilder.CreateIndex(
                name: "IX_UserMovie_MovieId",
                table: "UserMovie",
                column: "MovieId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MovieActor");

            migrationBuilder.DropTable(
                name: "UserMovie");

            migrationBuilder.DropTable(
                name: "Actors");

            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Directors");
        }
    }
}
