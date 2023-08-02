﻿using MovieWebsiteDemo.Core.DTOs;
using MovieWebsiteDemo.Core.Models;

namespace MovieWebsiteDemo.Core.Services
{
    //Ders 34
    public interface IDirectorService : IGenericService<Director>
    {
        public Task<CustomResponseDto<DirectorWithMoviesDto>> GetSingleDirectorByIdWithMoviesAsync(int directorId);

    }
}
