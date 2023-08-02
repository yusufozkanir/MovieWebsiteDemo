using MovieWebsiteDemo.Core.Models;

namespace MovieWebsiteDemo.Core.Repositories
{
    //Ders 34
    public interface IDirectorRepository : IGenericRepository<Director>
    {
        Task<Director> GetSingleDirectorByIdWithMoviesAsync(int directorId);
    }
}
