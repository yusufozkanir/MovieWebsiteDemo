using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MovieWebsiteDemo.Core.DTOs;
using MovieWebsiteDemo.Core.Models;
using MovieWebsiteDemo.Core.Services;
using MovieWebsiteDemo.Service.Business.Services;

namespace MovieWebsiteDemo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : CustomBaseController
    {
        private readonly IUserService _userService;
        private readonly IMovieService _movieService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUserDto createUserDto)
        {

            return CreateActionResult(await _userService.CreateUserAsync(createUserDto));
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetUser()
        {
            return CreateActionResult(await _userService.GetUserByNameAsync(HttpContext.User.Identity.Name));
        }

        [HttpPost("CreateUserRoles/{userName}")]
        public async Task<IActionResult> CreateUserRoles(string userName)
        {
            return CreateActionResult(await _userService.CreateUserRoles(userName));
        }


        [HttpPost("{userId}/mark-watched/{movieId}")]
        public async Task<IActionResult> MarkAsWatched(int movieId, string userId)
        {
            return CreateActionResult(await _userService.MarkAsWatchedAsync(movieId, userId));
        }

        [HttpGet("{userId}/watched")]
        public async Task<IActionResult> GetWatchedMoviesForUser(string userId)
        {
            return CreateActionResult(await _userService.GetWatchedMoviesForUserAsync(userId));
        }
    }
}
