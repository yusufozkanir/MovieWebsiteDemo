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
        private readonly IMapper _mapper;

        public DirectorsController(IDirectorService directorService, IMapper mapper)
        {
            _directorService = directorService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var directors = await _directorService.GetAllAsync();
            var directorsDto = _mapper.Map<List<DirectorDto>>(directors.ToList());
            return CreateActionResult(CustomResponseDto<List<DirectorDto>>.Success(200, directorsDto));
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetSingleDirectorByIdWithMovies(int directorId)
        {
            return CreateActionResult(await _directorService.GetSingleDirectorByIdWithMoviesAsync(directorId));
        }
    }
}
