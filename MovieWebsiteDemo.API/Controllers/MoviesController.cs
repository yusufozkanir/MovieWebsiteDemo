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
        private readonly IMapper _mapper;
        private readonly IMovieService _service;

        public MoviesController(IMapper mapper, IMovieService movieService)
        {
            _mapper = mapper;
            _service = movieService;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetMovieWithDirector()
        {
            //Ders 33
            return CreateActionResult(await _service.GetMovieWithDirector());
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var movies = await _service.GetAllAsync();
            var moviesDto = _mapper.Map<List<MovieDto>>(movies.ToList());
            return CreateActionResult(CustomResponseDto<List<MovieDto>>.Success(200, moviesDto));
        }

        [ServiceFilter(typeof(NotFoundFilter<Movie>))]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var movies = await _service.GetByIdAsync(id);
            var moviesDto = _mapper.Map<MovieDto>(movies);
            return CreateActionResult(CustomResponseDto<MovieDto>.Success(200, moviesDto));
        }

        [HttpPost()]
        public async Task<IActionResult> Save(MovieDto movieDto)
        {
            var movies = await _service.AddAsync(_mapper.Map<Movie>(movieDto));
            var moviesDto = _mapper.Map<MovieDto>(movies);
            return CreateActionResult(CustomResponseDto<MovieDto>.Success(201, moviesDto));
        }

        [HttpPut()]
        public async Task<IActionResult> Update(MovieUpdateDto movieDto)
        {
            await _service.UpdateAsync(_mapper.Map<Movie>(movieDto));
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var movies = await _service.GetByIdAsync(id);
            await _service.RemoveAsync(movies);

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }

        [HttpPost("{id}/watched")]
        public async Task<IActionResult> MarkAsWatched(int id)
        {
            await _service.MarkAsWatchedAsync(id);
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }
    }
}
