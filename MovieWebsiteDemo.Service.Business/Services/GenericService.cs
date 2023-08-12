using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using MovieWebsiteDemo.Core.DTOs;
using MovieWebsiteDemo.Core.IUnitOfWork;
using MovieWebsiteDemo.Core.Models;
using MovieWebsiteDemo.Core.Repositories;
using MovieWebsiteDemo.Core.Services;
using MovieWebsiteDemo.Service.Business.Exceptions;
using System.Linq.Expressions;

namespace MovieWebsiteDemo.Service.Business.Services
{
    public class GenericService<Entity, Dto> where Entity : BaseEntity where Dto : class
    {
        //Bu servis business kodlarımın olacağı yer. Bu servis repo ile haberleşecek ki veritabanı ile ilgili işlemleri yapacak
        //Ve aynı zamanda repo(dataaccess) katmanında savechange metodunu çağırmadım, savechange yapabilmem için yani veritabanına yansıtabilmem için UnitOfWork interfacesinide kullanıyorum.

        private readonly IGenericRepository<Entity> _repository;
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IMapper _mapper;
        public GenericService(IGenericRepository<Entity> repository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<CustomResponseDto<Dto>> AddAsync(Dto dto)
        {
            Entity newEntity = _mapper.Map<Entity>(dto);
            await _repository.AddAsync(newEntity);
            await _unitOfWork.CommitAsync();
            var newDto = _mapper.Map<Dto>(newEntity);
            return CustomResponseDto<Dto>.Success(StatusCodes.Status200OK, newDto);
        }

        public async Task<CustomResponseDto<IEnumerable<Dto>>> AddRangeAsync(IEnumerable<Dto> dtos)
        {
            var newEntities = _mapper.Map<IEnumerable<Entity>>(dtos);
            await _repository.AddRangeAsync(newEntities);
            await _unitOfWork.CommitAsync();
            var newDtos = _mapper.Map<IEnumerable<Dto>>(newEntities);
            return CustomResponseDto<IEnumerable<Dto>>.Success(StatusCodes.Status200OK, newDtos);
        }

        public async Task<CustomResponseDto<bool>> AnyAsync(Expression<Func<Entity, bool>> expression)
        {
            var anyEntity = await _repository.AnyAsync(expression);

            return CustomResponseDto<bool>.Success(StatusCodes.Status200OK, anyEntity);
        }

        public async Task<CustomResponseDto<IEnumerable<Dto>>> GetAllAsync()
        {
            var entities = await _repository.GetAll().ToListAsync();

            var dtos = _mapper.Map<IEnumerable<Dto>>(entities);

            return CustomResponseDto<IEnumerable<Dto>>.Success(StatusCodes.Status200OK, dtos);
        }

        public async Task<CustomResponseDto<Dto>> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);

            var dto = _mapper.Map<Dto>(entity);

            return CustomResponseDto<Dto>.Success(StatusCodes.Status200OK, dto);
        }

        public async Task<CustomResponseDto<NoContentDto>> RemoveAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);

            _repository.Remove(entity);
            await _unitOfWork.CommitAsync();

            return CustomResponseDto<NoContentDto>.Success(StatusCodes.Status204NoContent);
        }

        public async Task<CustomResponseDto<NoContentDto>> RemoveRangeAsync(IEnumerable<int> ids)
        {
            var entities = await _repository.Where(x => ids.Contains(x.Id)).ToListAsync();

            _repository.RemoveRange(entities);

            await _unitOfWork.CommitAsync();
            return CustomResponseDto<NoContentDto>.Success(StatusCodes.Status204NoContent);
        }

        public async Task<CustomResponseDto<NoContentDto>> UpdateAsync(Dto dto)
        {
            var entity = _mapper.Map<Entity>(dto);
            _repository.Update(entity);

            await _unitOfWork.CommitAsync();

            return CustomResponseDto<NoContentDto>.Success(StatusCodes.Status204NoContent);
        }

        public async Task<CustomResponseDto<IEnumerable<Dto>>> Where(Expression<Func<Entity, bool>> expression)
        {
            var entities = await _repository.Where(expression).ToListAsync();

            var dtos = _mapper.Map<IEnumerable<Dto>>(entities);

            return CustomResponseDto<IEnumerable<Dto>>.Success(StatusCodes.Status200OK, dtos);
        }
    }
}
