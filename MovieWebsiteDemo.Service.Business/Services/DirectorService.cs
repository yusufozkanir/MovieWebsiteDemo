using AutoMapper;
using MovieWebsiteDemo.Core.DTOs;
using MovieWebsiteDemo.Core.IUnitOfWork;
using MovieWebsiteDemo.Core.Models;
using MovieWebsiteDemo.Core.Repositories;
using MovieWebsiteDemo.Core.Services;

namespace MovieWebsiteDemo.Service.Business.Services
{
    //Ders 34
    public class DirectorService : GenericService<Director>, IDirectorService
    {
        private readonly IDirectorRepository _directorRepository;
        private readonly IMapper _mapper;
        public DirectorService(IGenericRepository<Director> repository, IUnitOfWork unitOfWork, IMapper mapper, IDirectorRepository directorRepository) : base(repository, unitOfWork)
        {
            _mapper = mapper;
            _directorRepository = directorRepository;
        }

        public async Task<CustomResponseDto<DirectorWithMoviesDto>> GetSingleDirectorByIdWithMoviesAsync(int directorId)
        {
            var director = await _directorRepository.GetSingleDirectorByIdWithMoviesAsync(directorId);
            var directorDto = _mapper.Map<DirectorWithMoviesDto>(director);
            return CustomResponseDto<DirectorWithMoviesDto>.Success(200, directorDto);
        }
    }
}
