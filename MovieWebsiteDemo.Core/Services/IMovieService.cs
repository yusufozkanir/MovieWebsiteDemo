using MovieWebsiteDemo.Core.DTOs;
using MovieWebsiteDemo.Core.Models;

namespace MovieWebsiteDemo.Core.Services
{
    //Ders 33
    public interface IMovieService : IGenericService<Movie>
    {
        Task<CustomResponseDto<List<MovieWithDirectorDto>>> GetMovieWithDirector();
        //Task<CustomResponseDto<bool>> MarkMovieAsWatched(int movieId);
        Task MarkAsWatchedAsync(int movieId);

    }
}
