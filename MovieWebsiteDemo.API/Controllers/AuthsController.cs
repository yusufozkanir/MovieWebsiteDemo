using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieWebsiteDemo.Core.DTOs;
using MovieWebsiteDemo.Core.Services;

namespace MovieWebsiteDemo.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthsController : CustomBaseController
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthsController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateToken(LoginDto loginDto)
        {
            return CreateActionResult(await _authenticationService.CreateTokenAsync(loginDto));
        }

        [HttpPost]
        public IActionResult CreateTokenByClient(ClientLoginDto clientLoginDto)
        {
            return CreateActionResult(_authenticationService.CreateTokenByClient(clientLoginDto));
        }

        [HttpPost]
        public async Task<IActionResult> RevokeRefreshToken(RefreshTokenDto refreshTokenDto)
        {
            return CreateActionResult(await _authenticationService.RevokeRefreshToken(refreshTokenDto.Token));
        }

        [HttpPost]
        public async Task<IActionResult> CreateTokenByRefreshToken(RefreshTokenDto refreshTokenDto)
        {
            return CreateActionResult(await _authenticationService.CreateTokenByRefreshToken(refreshTokenDto.Token));
        }
    }
}
