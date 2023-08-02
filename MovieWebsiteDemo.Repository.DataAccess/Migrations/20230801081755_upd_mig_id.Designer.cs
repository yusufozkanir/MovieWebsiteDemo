﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MovieWebsiteDemo.Repository.DataAccess;

#nullable disable

namespace MovieWebsiteDemo.Repository.DataAccess.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230801081755_upd_mig_id")]
    partial class upd_mig_id
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MovieWebsiteDemo.Core.Models.Actor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ActorBiography")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ActorBirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ActorFilmography")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ActorName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ActorPhoto")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Actors");
                });

            modelBuilder.Entity("MovieWebsiteDemo.Core.Models.Director", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("DirectorBiography")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DirectorBirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("DirectorName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DirectorPhoto")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Directors");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DirectorBiography = "Jonathan Kolia Favreau, kısaca Jon Favreau, Amerikalı oyuncu ve yönetmendir. En iyi Şef filmi ve Iron Man serisi dahil olmak üzere Marvel Sinematik Evreni'nde canlandırdığı Happy karakteri ile bilinir. Ayrıca yönetmenliğini yaptığı filmler arasında Iron Man ve Iron Man 2 bulunur. Aynı zamanda ünlü komedi dizisi Friends de Monica'nını milyoner erkek arkadaşı Pete Becker'ı canlandırmıştır.",
                            DirectorBirthDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DirectorName = "Jon Favreau",
                            DirectorPhoto = "-"
                        });
                });

            modelBuilder.Entity("MovieWebsiteDemo.Core.Models.Movie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DirectorId")
                        .HasColumnType("int");

                    b.Property<decimal>("MovieDuration")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("MovieRating")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("MovieReleaseDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("MovieSummary")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MovieTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MovieTrailer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MovieType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Producer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ScreenWriter")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DirectorId");

                    b.ToTable("Movies");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DirectorId = 1,
                            MovieDuration = 0m,
                            MovieRating = 0m,
                            MovieReleaseDate = new DateTime(2008, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            MovieTitle = "Iron Man"
                        });
                });

            modelBuilder.Entity("MovieWebsiteDemo.Core.Models.MovieActor", b =>
                {
                    b.Property<int>("MovieId")
                        .HasColumnType("int");

                    b.Property<int>("ActorId")
                        .HasColumnType("int");

                    b.HasKey("MovieId", "ActorId");

                    b.HasIndex("ActorId");

                    b.ToTable("MovieActor");
                });

            modelBuilder.Entity("MovieWebsiteDemo.Core.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("UserMail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserPassword")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            UserMail = "yusuf@gmail.com",
                            UserName = "Yusuf",
                            UserPassword = 123
                        });
                });

            modelBuilder.Entity("MovieWebsiteDemo.Core.Models.UserMovie", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("MovieId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "MovieId");

                    b.HasIndex("MovieId");

                    b.ToTable("UserMovie");
                });

            modelBuilder.Entity("MovieWebsiteDemo.Core.Models.WatchedMovie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("MovieId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<DateTime>("WatchedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("MovieId");

                    b.HasIndex("UserId");

                    b.ToTable("WatchedMovie");
                });

            modelBuilder.Entity("MovieWebsiteDemo.Core.Models.Movie", b =>
                {
                    b.HasOne("MovieWebsiteDemo.Core.Models.Director", "Director")
                        .WithMany("Movies")
                        .HasForeignKey("DirectorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Director");
                });

            modelBuilder.Entity("MovieWebsiteDemo.Core.Models.MovieActor", b =>
                {
                    b.HasOne("MovieWebsiteDemo.Core.Models.Actor", "Actor")
                        .WithMany("MovieActors")
                        .HasForeignKey("ActorId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("MovieWebsiteDemo.Core.Models.Movie", "Movie")
                        .WithMany("MovieActors")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Actor");

                    b.Navigation("Movie");
                });

            modelBuilder.Entity("MovieWebsiteDemo.Core.Models.UserMovie", b =>
                {
                    b.HasOne("MovieWebsiteDemo.Core.Models.Movie", "Movie")
                        .WithMany("Users")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("MovieWebsiteDemo.Core.Models.User", "User")
                        .WithMany("Movies")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Movie");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MovieWebsiteDemo.Core.Models.WatchedMovie", b =>
                {
                    b.HasOne("MovieWebsiteDemo.Core.Models.Movie", "Movie")
                        .WithMany("WatchedMovies")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MovieWebsiteDemo.Core.Models.User", "User")
                        .WithMany("WatchedMovies")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Movie");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MovieWebsiteDemo.Core.Models.Actor", b =>
                {
                    b.Navigation("MovieActors");
                });

            modelBuilder.Entity("MovieWebsiteDemo.Core.Models.Director", b =>
                {
                    b.Navigation("Movies");
                });

            modelBuilder.Entity("MovieWebsiteDemo.Core.Models.Movie", b =>
                {
                    b.Navigation("MovieActors");

                    b.Navigation("Users");

                    b.Navigation("WatchedMovies");
                });

            modelBuilder.Entity("MovieWebsiteDemo.Core.Models.User", b =>
                {
                    b.Navigation("Movies");

                    b.Navigation("WatchedMovies");
                });
#pragma warning restore 612, 618
        }
    }
}
