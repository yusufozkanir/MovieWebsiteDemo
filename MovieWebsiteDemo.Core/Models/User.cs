namespace MovieWebsiteDemo.Core.Models
{
    public class User : BaseEntity
    {
        public string UserName { get; set; }
        public string UserMail { get; set; }
        public int UserPassword { get; set; }

        public ICollection<UserMovie> Movies { get; set; }

        public List<WatchedMovie> WatchedMovies { get; set; }
    }
}
