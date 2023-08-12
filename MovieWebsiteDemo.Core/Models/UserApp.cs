using Microsoft.AspNetCore.Identity;

namespace MovieWebsiteDemo.Core.Models
{
    public class UserApp : IdentityUser
    {
        public ICollection<UserMovie> Movies { get; set; }

        public List<WatchedMovie> WatchedMovies { get; set; }
    }
}
