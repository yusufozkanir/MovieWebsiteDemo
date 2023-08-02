using Microsoft.EntityFrameworkCore;
using MovieWebsiteDemo.Core.IUnitOfWork;
using MovieWebsiteDemo.Core.Repositories;
using MovieWebsiteDemo.Core.Services;
using MovieWebsiteDemo.Service.Business.Exceptions;
using System.Linq.Expressions;

namespace MovieWebsiteDemo.Service.Business.Services
{
    public class GenericService<T> : IGenericService<T> where T : class
    {
        //Bu servis business kodlarımın olacağı yer. Bu servis repo ile haberleşecek ki veritabanı ile ilgili işlemleri yapacak
        //Ve aynı zamanda repo(dataaccess) katmanında savechange metodunu çağırmadım, savechange yapabilmem için yani veritabanına yansıtabilmem için UnitOfWork interfacesinide kullanıyorum.

        private readonly IGenericRepository<T> _repository;
        private readonly IUnitOfWork _unitOfWork;
        public GenericService(IGenericRepository<T> repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<T> AddAsync(T entity)
        {
            await _repository.AddAsync(entity);
            await _unitOfWork.CommitAsync();
            return entity;
        }

        public async Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities)
        {
            await _repository.AddRangeAsync(entities);
            await _unitOfWork.CommitAsync();
            return entities;
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> expression)
        {
            return await _repository.AnyAsync(expression);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _repository.GetAll().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            //Ders 39
            var hasProduct = await _repository.GetByIdAsync(id);
            if (hasProduct == null)
            {
                throw new NotFoundException($"{typeof(T).Name}({id}) not found");
            }
            return hasProduct;
            //return await _repository.GetByIdAsync(id);
        }

        public async Task RemoveAsync(T entity)
        {
            _repository.Remove(entity);
            await _unitOfWork.CommitAsync();
        }

        public async Task RemoveRangeAsync(IEnumerable<T> entities)
        {
            _repository.RemoveRange(entities);
            await _unitOfWork.CommitAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _repository.Update(entity);
            await _unitOfWork.CommitAsync();
        }

        public IQueryable<T> Where(Expression<Func<T, bool>> expression)
        {
            return _repository.Where(expression);
        }
    }
}
