using AutoMapper;
using AutoMapper.Internal.Mappers;
using Azure;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using MovieWebsiteDemo.Core.DTOs;
using MovieWebsiteDemo.Core.Models;
using MovieWebsiteDemo.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using MovieWebsiteDemo.Core.Repositories;
using MovieWebsiteDemo.Repository.DataAccess.Repositories;
using MovieWebsiteDemo.Core.IUnitOfWork;

namespace MovieWebsiteDemo.Service.Business.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<UserApp> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IGenericRepository<WatchedMovie> _watchedMovieRepository;
        private readonly IMovieRepository _movieRepository;
        private readonly IUnitOfWork _unitOfWork;

        private readonly IMapper _mapper;

        public UserService(UserManager<UserApp> userManager, RoleManager<IdentityRole> roleManager, IMapper mapper, IMovieRepository movieRepository, IUnitOfWork unitOfWork, IGenericRepository<WatchedMovie> watchedMovieRepository)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _mapper = mapper;
            _movieRepository = movieRepository;
            _unitOfWork = unitOfWork;
            _watchedMovieRepository = watchedMovieRepository;
        }

        public async Task<CustomResponseDto<UserAppDto>> CreateUserAsync(CreateUserDto createUserDto)
        {
            var user = new UserApp { Email = createUserDto.Email, UserName = createUserDto.UserName };

            var result = await _userManager.CreateAsync(user, createUserDto.Password);

            if (result.Succeeded)
            {
                var errors = result.Errors.Select(x => x.Description).ToList();

                return CustomResponseDto<UserAppDto>.Fail(400, new ErrorDto(errors, true));
            }

            return CustomResponseDto<UserAppDto>.Success(200, _mapper.Map<UserAppDto>(user));
        }

        public async Task<CustomResponseDto<NoContentDto>> CreateUserRoles(string userName)
        {
            if (!await _roleManager.RoleExistsAsync("admin"))
            {
                await _roleManager.CreateAsync(new() { Name = "admin" });
                await _roleManager.CreateAsync(new() { Name = "manager" });
                await _roleManager.CreateAsync(new() { Name = "customer" });
            }

            var user = await _userManager.FindByNameAsync(userName);
            _userManager.AddToRoleAsync(user, "admin");
            _userManager.AddToRoleAsync(user, "manager");
            _userManager.AddToRoleAsync(user, "customer");

            return CustomResponseDto<NoContentDto>.Success(StatusCodes.Status201Created);
        }

        public async Task<CustomResponseDto<UserAppDto>> GetUserByNameAsync(string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);

            if (user == null)
            {
                return CustomResponseDto<UserAppDto>.Fail(404, "UserName not found", true);
            }
            return CustomResponseDto<UserAppDto>.Success(200, _mapper.Map<UserAppDto>(user));
        }

        public async Task<CustomResponseDto<NoContentDto>> MarkAsWatchedAsync(int movieId, string userId)
        {

            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
            {
                return CustomResponseDto<NoContentDto>.Fail(StatusCodes.Status404NotFound, "User not found", true);
            }

            var movie = await _movieRepository.GetByIdAsync(movieId);
            if (movie != null)
            {
                movie.IsWatched = true;
                movie.WatchedByUserId = userId; // Kullanıcı kimliği eklendi
                await _unitOfWork.CommitAsync();
                return CustomResponseDto<NoContentDto>.Success(StatusCodes.Status204NoContent);
            }
            return CustomResponseDto<NoContentDto>.Fail(StatusCodes.Status404NotFound, "Movie not found", true);
        }



        public async Task<CustomResponseDto<IEnumerable<WatchedMovieDto>>> GetWatchedMoviesForUserAsync(string userId)
        {
            //var watchedMovies = await _watchedMovieRepository.Where(x => x.Id == userId).ToListAsync();

            //var watchedMovieDtos = watchedMovies.Select(wm => new WatchedMovieDto
            //{
            //    Id = wm.UserId,
            //    MovieId = wm.MovieId,
            //    WatchedDate = wm.WatchedDate,
            //}).ToList();
            //return CustomResponseDto<IEnumerable<WatchedMovieDto>>.Success(200, watchedMovies);

            var watchedMovies = await _watchedMovieRepository.GetAll().ToListAsync();
            var userWatchedMovies = watchedMovies
                .Where(wm => wm.Id == userId)
                .Select(wm => new WatchedMovieDto
                {
                    MovieId = wm.MovieId,
                    WatchedDate = wm.WatchedDate
                }).ToList();

            return CustomResponseDto<IEnumerable<WatchedMovieDto>>.Success(200, userWatchedMovies);

        }
    }
}
