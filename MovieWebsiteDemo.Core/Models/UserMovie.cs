namespace MovieWebsiteDemo.Core.Models
{
    public class UserMovie
    {
        public string Id { get; set; }
        public UserApp User { get; set; }

        public int MovieId { get; set; }
        public Movie Movie { get; set; }
    }
}
