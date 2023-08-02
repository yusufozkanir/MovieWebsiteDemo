using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieWebsiteDemo.Core.Models;

namespace MovieWebsiteDemo.Repository.DataAccess.Configurations
{
    internal class WatchedMovieConfiguration : IEntityTypeConfiguration<WatchedMovie>
    {
        public void Configure(EntityTypeBuilder<WatchedMovie> builder)
        {
            //modelBuilder.Entity<WatchedFilm>()
            builder.HasKey(wf => wf.Id);

            //modelBuilder.Entity<WatchedFilm>()
            builder.HasOne(wf => wf.User)
                .WithMany(u => u.WatchedMovies)
                .HasForeignKey(wf => wf.UserId);

            //modelBuilder.Entity<WatchedFilm>()
            builder.HasOne(wf => wf.Movie)
                .WithMany(f => f.WatchedMovies)
                .HasForeignKey(wf => wf.MovieId);
        }
    }
}
