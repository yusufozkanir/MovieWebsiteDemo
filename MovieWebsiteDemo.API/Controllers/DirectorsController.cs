using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MovieWebsiteDemo.Core.DTOs;
using MovieWebsiteDemo.Core.Services;

namespace MovieWebsiteDemo.API.Controllers
{
    //Ders 34
    public class DirectorsController : CustomBaseController
    {
        private readonly IDirectorService _directorService;

        public DirectorsController(IDirectorService directorService)
        {
            _directorService = directorService;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetSingleDirectorByIdWithMovies(int directorId)
        {
            return CreateActionResult(await _directorService.GetSingleDirectorByIdWithMoviesAsync(directorId));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return CreateActionResult(await _directorService.GetAllAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Get(DirectorDto director)
        {
            return CreateActionResult(await _directorService.AddAsync(director));
        }
    }
}
