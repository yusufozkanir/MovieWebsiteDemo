using AutoMapper;
using Microsoft.AspNetCore.Http;
using MovieWebsiteDemo.Core.DTOs;
using MovieWebsiteDemo.Core.IUnitOfWork;
using MovieWebsiteDemo.Core.Models;
using MovieWebsiteDemo.Core.Repositories;
using MovieWebsiteDemo.Core.Services;
using MovieWebsiteDemo.Repository.DataAccess.UnitOfWork;

namespace MovieWebsiteDemo.Service.Business.Services
{
    //Ders 33
    public class MovieService : GenericService<Movie, MovieDto>, IMovieService
    {
        private readonly IMovieRepository _movieRepository;


        public MovieService(IGenericRepository<Movie> repository, IUnitOfWork unitOfWork, IMovieRepository movieRepository, IMapper mapper) : base(repository, unitOfWork, mapper)
        {
            _movieRepository = movieRepository;
        }

        public async Task<CustomResponseDto<MovieDto>> AddAsync(MovieCreateDto dto)
        {
            var newEntity = _mapper.Map<Movie>(dto);
            await _movieRepository.AddAsync(newEntity);
            await _unitOfWork.CommitAsync();

            var newDto = _mapper.Map<MovieDto>(newEntity);
            return CustomResponseDto<MovieDto>.Success(StatusCodes.Status200OK, newDto);
        }

        public async Task<CustomResponseDto<List<MovieWithDirectorDto>>> GetMovieWithDirector()
        {
            var movies = await _movieRepository.GetMovieWithDirector();
            var moviesDto = _mapper.Map<List<MovieWithDirectorDto>>(movies);
            return CustomResponseDto<List<MovieWithDirectorDto>>.Success(200, moviesDto);
        }
        public async Task<CustomResponseDto<NoContentDto>> UpdateAsync(MovieUpdateDto dto)
        {
            var entity = _mapper.Map<Movie>(dto);
            _movieRepository.Update(entity);

            await _unitOfWork.CommitAsync();

            return CustomResponseDto<NoContentDto>.Success(StatusCodes.Status204NoContent);
        }

        public async Task<CustomResponseDto<NoContentDto>> MarkAsWatchedAsync(int movieId)
        {
            var movie = await _movieRepository.GetByIdAsync(movieId);
            if (movie != null)
            {
                movie.IsWatched = true;
                await _unitOfWork.CommitAsync();
                return CustomResponseDto<NoContentDto>.Success(StatusCodes.Status204NoContent);
            }
            return CustomResponseDto<NoContentDto>.Fail(StatusCodes.Status404NotFound, "Movie not found", true);
        }
    }
}
