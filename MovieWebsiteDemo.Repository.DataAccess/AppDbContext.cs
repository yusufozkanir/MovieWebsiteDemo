using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MovieWebsiteDemo.Core.Models;
using System.Reflection;

namespace MovieWebsiteDemo.Repository.DataAccess
{
    public class AppDbContext : IdentityDbContext<UserApp, IdentityRole, string>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Actor> Actors { get; set; }
        public DbSet<Director> Directors { get; set; }
        public DbSet<Movie> Movies { get; set; }
        //public DbSet<UserApp> UserApps { get; set; }
        public DbSet<UserRefreshToken> UserRefreshTokens { get; set; }

        //public DbSet<UserMovie> UserMovies { get; set; }
        //public DbSet<MovieActor> MovieActors { get; set; }
        //public DbSet<WatchedMovie> WatchedMovies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }
    }
}
