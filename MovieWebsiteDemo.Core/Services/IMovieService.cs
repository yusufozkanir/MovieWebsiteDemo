using MovieWebsiteDemo.Core.DTOs;
using MovieWebsiteDemo.Core.Models;

namespace MovieWebsiteDemo.Core.Services
{
    //Ders 33
    public interface IMovieService : IGenericService<Movie, MovieDto>
    {
        Task<CustomResponseDto<List<MovieWithDirectorDto>>> GetMovieWithDirector();

        Task<CustomResponseDto<NoContentDto>> UpdateAsync(MovieUpdateDto dto);

        Task<CustomResponseDto<MovieDto>> AddAsync(MovieCreateDto dto);

        Task <CustomResponseDto<NoContentDto>> MarkAsWatchedAsync(int movieId);



    }
}
