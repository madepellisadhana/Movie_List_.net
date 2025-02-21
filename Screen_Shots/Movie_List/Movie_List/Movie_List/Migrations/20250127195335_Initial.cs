using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Movie_List.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
            name: "Movies",
            columns: table => new {
                MovieId = table.Column<int>(nullable: false)
            .Annotation("SqlServer:ValueGenerationStrategy",
            SqlServerValueGenerationStrategy.IdentityColumn),
                Name = table.Column<string>(nullable: false),
                Year = table.Column<int>(nullable: false),
                Rating = table.Column<int>(nullable: false)
            },
            constraints: table => {
                table.PrimaryKey("PK_Movies", x => x.MovieId);
            });
            migrationBuilder.InsertData(
            table: "Movies",
            columns: new[] { "MovieId", "Name", "Rating", "Year" },
            values: new object[,]
{
    { 1, "Casablanca", 5, 1942 },
    { 2, "Wonder Woman", 3, 2017 },
    { 3, "Moonstruck", 4, 1988 }
});
        }
        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Movies");
        }
    }
}
