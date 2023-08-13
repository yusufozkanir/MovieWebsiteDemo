using MovieWebsiteDemo.Core.DTOs;
using MovieWebsiteDemo.Core.Models;

namespace MovieWebsiteDemo.Core.Services
{
    public interface IUserService : IGenericService<UserApp, UserAppDto>
    {
        Task<CustomResponseDto<UserAppDto>> CreateUserAsync(CreateUserDto createUserDto);
        Task<CustomResponseDto<UserAppDto>> GetUserByNameAsync(string userName);
    }
}
