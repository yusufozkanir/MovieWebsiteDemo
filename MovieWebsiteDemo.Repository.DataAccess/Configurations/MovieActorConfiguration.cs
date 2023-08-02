using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieWebsiteDemo.Core.Models;

namespace MovieWebsiteDemo.Repository.DataAccess.Configurations
{
    internal class MovieActorConfiguration : IEntityTypeConfiguration<MovieActor>
    {
        public void Configure(EntityTypeBuilder<MovieActor> builder)
        {
            //MovieActor İlişkisi
            //modelBuilder.Entity<MovieActor>()
            builder.HasKey(ma => new { ma.MovieId, ma.ActorId });

            //modelBuilder.Entity<MovieActor>()
            builder.HasOne(ma => ma.Movie)
            .WithMany(m => m.MovieActors)
            .HasForeignKey(ma => ma.MovieId)
            .OnDelete(DeleteBehavior.Restrict);

            //modelBuilder.Entity<MovieActor>()
            builder.HasOne(ma => ma.Actor)
            .WithMany(a => a.MovieActors)
            .HasForeignKey(ma => ma.ActorId)
            .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
