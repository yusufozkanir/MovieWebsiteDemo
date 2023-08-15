using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieWebsiteDemo.Repository.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class mig_deneme2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WatchedMovie");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WatchedMovie",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WatchedMovie", x => x.Id);
                });
        }
    }
}
