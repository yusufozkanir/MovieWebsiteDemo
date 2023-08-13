using Autofac.Core;
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
            return CreateActionResult(await _userService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return CreateActionResult(await _userService.GetByIdAsync(id));
        }

        [HttpPost()]
        public async Task<IActionResult> SaveNewUser(UserAppDto userDto)
        {

            return CreateActionResult(await _userService.AddAsync(userDto));
        }

        [HttpPut()]
        public async Task<IActionResult> Update(UserAppDto userDto)
        {
            return CreateActionResult(await _userService.UpdateAsync(userDto));
        }
    }
}
