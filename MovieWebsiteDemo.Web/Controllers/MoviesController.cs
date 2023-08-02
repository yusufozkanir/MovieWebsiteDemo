using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MovieWebsiteDemo.Core.DTOs;
using MovieWebsiteDemo.Core.Models;
using MovieWebsiteDemo.Web.Services;

namespace MovieWebsiteDemo.Web.Controllers
{
    public class MoviesController : Controller
    {
        private readonly MovieApiService _movieApiService;
        private readonly DirectorApiService _directorApiService;

        public MoviesController(MovieApiService movieApiService, DirectorApiService directorApiService)
        {
            _movieApiService = movieApiService;
            _directorApiService = directorApiService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _movieApiService.GetMovieWithDirectorAsync());
        }

        public async Task<IActionResult> Save()
        {
            //Dropdown List
            var directorsDto = await _directorApiService.GetAllAsync();
            ViewBag.directors = new SelectList(directorsDto, "Id", "DirectorName");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Save(MovieDto movieDto)
        {
            //Ders 46
            if (ModelState.IsValid)
            {
                await _movieApiService.SaveAsync(movieDto);
                return RedirectToAction(nameof(Index));
            }

            var directorsDto = await _directorApiService.GetAllAsync();
            ViewBag.directors = new SelectList(directorsDto, "Id", "DirectorName");
            return View();
        }

        [ServiceFilter(typeof(NotFoundFilter<Movie>))]
        public async Task<IActionResult> Update(int id)
        {
            //Ders 50
            var movie = await _movieApiService.GetByIdAsync(id);

            var directorsDto = await _directorApiService.GetAllAsync();

            ViewBag.directors = new SelectList(directorsDto, "Id", "DirectorName", movie.DirectorId);

            return View(movie);
        }

        [HttpPost]
        public async Task<IActionResult> Update(MovieDto movieDto)
        {
            //Ders 50
            if (ModelState.IsValid)
            {
                await _movieApiService.UpdateAsync(movieDto);
                return RedirectToAction(nameof(Index));
            }

            var directorsDto = await _directorApiService.GetAllAsync();

            ViewBag.directors = new SelectList(directorsDto, "Id", "DirectorName", movieDto.DirectorId);
            return View(movieDto);
        }

        public async Task<IActionResult> Remove(int id)
        {
            await _movieApiService.RemoveAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
