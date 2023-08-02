using AutoMapper;
using MovieWebsiteDemo.Core.DTOs;
using MovieWebsiteDemo.Core.IUnitOfWork;
using MovieWebsiteDemo.Core.Models;
using MovieWebsiteDemo.Core.Repositories;
using MovieWebsiteDemo.Core.Services;
using MovieWebsiteDemo.Repository.DataAccess.UnitOfWork;

namespace MovieWebsiteDemo.Service.Business.Services
{
    //Ders 33
    public class MovieService : GenericService<Movie>, IMovieService
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public MovieService(IGenericRepository<Movie> repository, IUnitOfWork unitOfWork, IMovieRepository movieRepository, IMapper mapper) : base(repository, unitOfWork)
        {
            _movieRepository = movieRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<CustomResponseDto<List<MovieWithDirectorDto>>> GetMovieWithDirector()
        {
            var movies = await _movieRepository.GetMovieWithDirector();
            var moviesDto = _mapper.Map<List<MovieWithDirectorDto>>(movies);
            return CustomResponseDto<List<MovieWithDirectorDto>>.Success(200, moviesDto);
        }

        public async Task MarkAsWatchedAsync(int movieId)
        {
            var film = await _movieRepository.GetByIdAsync(movieId);
            if (film != null)
            {
                film.IsWatched = true;
                await _unitOfWork.CommitAsync();
            }
        }
    }
}
