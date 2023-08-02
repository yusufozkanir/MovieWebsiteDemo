using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieWebsiteDemo.Core.Models;

namespace MovieWebsiteDemo.Repository.DataAccess.Configurations
{
    internal class UserMovieConfiguration : IEntityTypeConfiguration<UserMovie>
    {
        public void Configure(EntityTypeBuilder<UserMovie> builder)
        {

            //UserMovie İlişkisi
            //modelBuilder.Entity<UserMovie>()
            builder.HasKey(um => new { um.UserId, um.MovieId });

            //modelBuilder.Entity<UserMovie>()
            builder.HasOne(um => um.User)
            .WithMany(u => u.Movies)
            .HasForeignKey(um => um.UserId)
            .OnDelete(DeleteBehavior.Restrict);

            //modelBuilder.Entity<UserMovie>()
            builder.HasOne(um => um.Movie)
            .WithMany(m => m.Users)
            .HasForeignKey(um => um.MovieId)
            .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
