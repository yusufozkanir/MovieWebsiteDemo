namespace MovieWebsiteDemo.Core.Models
{
    public class Movie : BaseEntity
    {
        public string MovieTitle { get; set; }
        public string Producer { get; set; }
        public string ScreenWriter { get; set; }
        public string MovieType { get; set; }
        public decimal MovieDuration { get; set; }
        public DateTime MovieReleaseDate { get; set; }
        public string MovieSummary { get; set; }
        public decimal MovieRating { get; set; }
        public string MovieTrailer { get; set; }
        public bool IsWatched { get; set; }
        public int DirectorId { get; set; }
        public Director Director { get; set; }

        public ICollection<MovieActor> MovieActors { get; set; }
        public ICollection<UserMovie> Users { get; set; }

        public List<WatchedMovie> WatchedMovies { get; set; }

    }
}
