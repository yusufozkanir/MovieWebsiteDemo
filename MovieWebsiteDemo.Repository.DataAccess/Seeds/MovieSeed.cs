using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieWebsiteDemo.Core.Models;

namespace MovieWebsiteDemo.Repository.DataAccess.Seeds
{
    internal class MovieSeed : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder.HasData(
                new Movie { Id = 1, MovieTitle = "Iron Man", DirectorId = 1, MovieReleaseDate = new(2008, 5, 2) }
                );
        }
    }
}
