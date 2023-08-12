using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MovieWebsiteDemo.Core.DTOs;
using MovieWebsiteDemo.Core.Models;
using MovieWebsiteDemo.Core.Services;

namespace MovieWebsiteDemo.API.Controllers
{
    public class UsersController : CustomBaseController
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UsersController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var users = await _userService.GetAllAsync();
            var usersDto = _mapper.Map<List<UserAppDto>>(users.ToList());
            return CreateActionResult(CustomResponseDto<List<UserAppDto>>.Success(200, usersDto));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var users = await _userService.GetByIdAsync(id);
            var usersDto = _mapper.Map<UserAppDto>(users);
            return CreateActionResult(CustomResponseDto<UserAppDto>.Success(200, usersDto));
        }

        [HttpPost()]
        public async Task<IActionResult> SaveNewUser(UserAppDto userDto)
        {
            var users = await _userService.AddAsync(_mapper.Map<UserApp>(userDto));
            var usersDto = _mapper.Map<UserAppDto>(users);
            return CreateActionResult(CustomResponseDto<UserAppDto>.Success(201, usersDto));
        }

        [HttpPut()]
        public async Task<IActionResult> Update(UserAppDto userDto)
        {
            await _userService.UpdateAsync(_mapper.Map<UserApp>(userDto));
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }
    }
}
