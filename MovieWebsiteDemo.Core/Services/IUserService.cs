using MovieWebsiteDemo.Core.DTOs;
using MovieWebsiteDemo.Core.Models;

namespace MovieWebsiteDemo.Core.Services
{
    public interface IUserService 
    {
        Task<CustomResponseDto<UserAppDto>> CreateUserAsync(CreateUserDto createUserDto);
        Task<CustomResponseDto<UserAppDto>> GetUserByNameAsync(string userName);
        Task<CustomResponseDto<NoContentDto>> CreateUserRoles(string userName);
        Task<CustomResponseDto<NoContentDto>> MarkAsWatchedAsync(int movieId, string userId);

        Task<CustomResponseDto<IEnumerable<WatchedMovieDto>>> GetWatchedMoviesForUserAsync(string userId);
    }
}
