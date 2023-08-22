using MovieWebsiteDemo.Core.Models;

namespace MovieWebsiteDemo.Core.DTOs
{
    public class WatchedMovieDto
    {
        public string Id { get; set; }
        public int MovieId { get; set; }
        public DateTime WatchedDate { get; set; }

        public UserApp User { get; set; }
        public Movie Movie { get; set; }
    }
}
