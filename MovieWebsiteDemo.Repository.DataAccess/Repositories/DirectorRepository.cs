using Microsoft.EntityFrameworkCore;
using MovieWebsiteDemo.Core.Models;
using MovieWebsiteDemo.Core.Repositories;

namespace MovieWebsiteDemo.Repository.DataAccess.Repositories
{
    //Ders 34
    public class DirectorRepository : GenericRepository<Director>, IDirectorRepository
    {
        public DirectorRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<Director> GetSingleDirectorByIdWithMoviesAsync(int directorId)
        {
            return await _context.Directors.Include(x => x.Movies).Where(x => x.Id == directorId).SingleOrDefaultAsync();
        }
    }
}
