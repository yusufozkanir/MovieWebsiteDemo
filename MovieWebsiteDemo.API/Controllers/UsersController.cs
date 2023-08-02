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
            var usersDto = _mapper.Map<List<UserDto>>(users.ToList());
            return CreateActionResult(CustomResponseDto<List<UserDto>>.Success(200, usersDto));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var users = await _userService.GetByIdAsync(id);
            var usersDto = _mapper.Map<UserDto>(users);
            return CreateActionResult(CustomResponseDto<UserDto>.Success(200, usersDto));
        }

        [HttpPost()]
        public async Task<IActionResult> SaveNewUser(UserDto userDto)
        {
            var users = await _userService.AddAsync(_mapper.Map<User>(userDto));
            var usersDto = _mapper.Map<UserDto>(users);
            return CreateActionResult(CustomResponseDto<UserDto>.Success(201, usersDto));
        }

        [HttpPut()]
        public async Task<IActionResult> Update(UserDto userDto)
        {
            await _userService.UpdateAsync(_mapper.Map<User>(userDto));
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }
    }
}
