﻿using AutoMapper;
using MovieWebsiteDemo.Core.DTOs;
using MovieWebsiteDemo.Core.Models;

namespace MovieWebsiteDemo.Service.Business.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Movie, MovieDto>().ReverseMap();
            CreateMap<Director, DirectorDto>().ReverseMap();
            CreateMap<Actor, ActorDto>().ReverseMap();
            CreateMap<UserApp, UserAppDto>().ReverseMap();
            CreateMap<MovieUpdateDto, Movie>();
            CreateMap<Movie, MovieWithDirectorDto>();
            CreateMap<Director, DirectorWithMoviesDto>();
            CreateMap<MovieCreateDto, Movie>();
            CreateMap<WatchedMovie, WatchedMovieDto>();
        }
    }
}
