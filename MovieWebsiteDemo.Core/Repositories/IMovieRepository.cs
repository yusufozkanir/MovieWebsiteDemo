using MovieWebsiteDemo.Core.Models;

namespace MovieWebsiteDemo.Core.Repositories
{
    //Ders 33
    public interface IMovieRepository : IGenericRepository<Movie>
    {
        Task<List<Movie>> GetMovieWithDirector();

        Task MarkAsWatchedAsync(int movieId);
    }
}
