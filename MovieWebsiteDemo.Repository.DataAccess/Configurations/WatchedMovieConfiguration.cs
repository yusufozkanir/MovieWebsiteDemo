using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieWebsiteDemo.Core.Models;
using System.Reflection.Emit;

namespace MovieWebsiteDemo.Repository.DataAccess.Configurations
{
    internal class WatchedMovieConfiguration : IEntityTypeConfiguration<WatchedMovie>
    {
        public void Configure(EntityTypeBuilder<WatchedMovie> builder)
        {
            ////modelBuilder.Entity<WatchedMovie>()
            //builder.HasKey(wf => wf.Id);

            ////modelBuilder.Entity<WatchedMovie>()
            //builder.HasOne(wf => wf.User)
            //    .WithMany(u => u.WatchedMovies)
            //    .HasForeignKey(wf => wf.Id);

            ////modelBuilder.Entity<WatchedMovie>()
            //builder.HasOne(wf => wf.Movie)
            //    .WithMany(f => f.WatchedMovies)
            //    .HasForeignKey(wf => wf.MovieId);



            // WatchedMovie tablosunun composite primary key'i
            //modelBuilder.Entity<WatchedMovie>()
            builder.HasKey(wm => new { wm.Id, wm.MovieId });

            //modelBuilder.Entity<User>()
            builder.HasOne(u => u.User)
            .WithMany(wm => wm.WatchedMovies)
            .HasForeignKey(wm => wm.Id);

            // Movie - WatchedMovie ilişkisi
            //modelBuilder.Entity<Movie>()
            builder.HasOne(wm => wm.Movie)
            .WithMany(m => m.WatchedMovies)
            .HasForeignKey(wm => wm.MovieId);


        }
    }
}
