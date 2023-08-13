using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MovieWebsiteDemo.API.Filters;
using MovieWebsiteDemo.Core.DTOs;
using MovieWebsiteDemo.Core.Models;
using MovieWebsiteDemo.Core.Services;

namespace MovieWebsiteDemo.API.Controllers
{
    //Ders 31
    public class MoviesController : CustomBaseController
    {
        private readonly IMovieService _service;

        public MoviesController(IMovieService movieService)
        {
            _service = movieService;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetMovieWithDirector()
        {
            return CreateActionResult(await _service.GetMovieWithDirector());
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            return CreateActionResult(await _service.GetAllAsync());
        }

        //[ServiceFilter(typeof(NotFoundFilter<Movie>))]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {

            return CreateActionResult(await _service.GetByIdAsync(id));
        }

        [HttpPost()]
        public async Task<IActionResult> Save(MovieCreateDto movieDto)
        {
            return CreateActionResult(await _service.AddAsync(movieDto));
        }

        [HttpPut()]
        public async Task<IActionResult> Update(MovieUpdateDto movieDto)
        {
            return CreateActionResult(await _service.UpdateAsync(movieDto));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            return CreateActionResult(await _service.RemoveAsync(id));
        }

        [HttpPost("SaveAll")]
        public async Task<IActionResult> SaveAll(List<MovieDto> movieDtos)
        {
            return CreateActionResult(await _service.AddRangeAsync(movieDtos));
        }

        [HttpDelete("RemoveAll")]
        public async Task<IActionResult> RemoveAll(List<int> ids)
        {
            return CreateActionResult(await _service.RemoveRangeAsync(ids));
        }

        [HttpDelete("Any/{id}")]
        public async Task<IActionResult> Any(int id)
        {
            return CreateActionResult(await _service.AnyAsync(x => x.Id == id));
        }


        [HttpPost("{id}/watched")]
        public async Task<IActionResult> MarkAsWatched(int id)
        {
            await _service.MarkAsWatchedAsync(id);
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }
    }
}
