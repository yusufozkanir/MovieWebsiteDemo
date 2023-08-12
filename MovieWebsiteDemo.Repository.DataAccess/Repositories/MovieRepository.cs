using Microsoft.EntityFrameworkCore;
using MovieWebsiteDemo.Core.Models;
using MovieWebsiteDemo.Core.Repositories;

namespace MovieWebsiteDemo.Repository.DataAccess.Repositories
{
    //Ders 33
    public class MovieRepository : GenericRepository<Movie>, IMovieRepository
    {
        public MovieRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<List<Movie>> GetMovieWithDirector()
        {
            //Eager Loading yani Datayı çekerken yönetmenlerin alınmasını istedim
            return await _context.Movies.Include(p => p.Director).ToListAsync();
        }

        public async Task MarkAsWatchedAsync(int movieId)
        {
            var film = await _context.Movies.FindAsync(movieId);
            if (film != null)
            {
                film.IsWatched = true;
                //await _context.SaveChangesAsync();
            }
        }
    }
}
