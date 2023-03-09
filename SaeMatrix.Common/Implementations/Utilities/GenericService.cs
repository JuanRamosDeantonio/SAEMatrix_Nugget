using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Net;

namespace SAE.Matrix.Common.Implementations.Utilities
{
    using Contracts.Utilities;
    using Entities;

    public class GenericService<TEntity, TContext> : IGenericService<TEntity, TContext>
                where TEntity : class
                where TContext : DbContext
    {
        private readonly IGenericRepository<TEntity, TContext> _repository;
        /// <summary>
        /// Inicializa el repositorio y el log de telemetria para el aplicationinsigth
        /// </summary>
        /// <param name="repository"></param>
        public GenericService(IGenericRepository<TEntity, TContext> repository)
        {
            _repository = repository;
        }
        public async Task<ResponseBase<TEntity>> Create(TEntity entity)
        {
            ResponseBase<TEntity> response = new ResponseBase<TEntity>();
            try
            {
                response.Data = await _repository.Create(entity).ConfigureAwait(true);
                return response;
            }
            catch (Exception ex)
            {
                return GenericUtility.ResponseBaseCatch<TEntity>(true, ex, HttpStatusCode.InternalServerError);
            }
        }
        public async Task<ResponseBase<bool>> Delete(Expression<Func<TEntity, bool>> expression)
        {
            ResponseBase<bool> response = new ResponseBase<bool>();
            try
            {
                IEnumerable<TEntity> toRemove = await _repository.Read(expression).ConfigureAwait(true);
                response.Data = await _repository.Delete(toRemove).ConfigureAwait(true);
                return response;
            }
            catch (Exception ex)
            {
                return GenericUtility.ResponseBaseCatch<bool>(true, ex, HttpStatusCode.InternalServerError);
            }

        }
        public async Task<ResponseBase<PagedResult<TEntity>>> Read(Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy, int page = 0, int size = 0)
        {
            ResponseBase<PagedResult<TEntity>> response = new ResponseBase<PagedResult<TEntity>>();
            try
            {
                response.Data = await _repository.Read(orderBy, page, size).ConfigureAwait(true);
                return response;
            }
            catch (Exception ex)
            {
                return GenericUtility.ResponseBaseCatch<PagedResult<TEntity>>(true, ex, HttpStatusCode.InternalServerError);
            }
        }
        public async Task<ResponseBase<PagedResult<TEntity>>> Read(Expression<Func<TEntity, bool>> expression, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy, int page = 0, int size = 0)
        {
            ResponseBase<PagedResult<TEntity>> response = new ResponseBase<PagedResult<TEntity>>();
            try
            {
                response.Data = await _repository.Read(expression, include, orderBy, page, size).ConfigureAwait(true);
                return response;
            }
            catch (Exception ex)
            {
                return GenericUtility.ResponseBaseCatch<PagedResult<TEntity>>(true, ex, HttpStatusCode.InternalServerError);
            }
        }
        public async Task<ResponseBase<List<TEntity>>> Read(Expression<Func<TEntity, bool>> expression)
        {
            ResponseBase<List<TEntity>> response = new ResponseBase<List<TEntity>>();
            try
            {
                response.Data = await _repository.Read(expression).ConfigureAwait(true);
                return response;
            }
            catch (Exception ex)
            {
                return GenericUtility.ResponseBaseCatch<List<TEntity>>(true, ex, HttpStatusCode.InternalServerError);
            }
        }
        public async Task<ResponseBase<PagedResult<TEntity>>> ReadWithInclude(Expression<Func<TEntity, bool>> expression, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include)
        {
            ResponseBase<PagedResult<TEntity>> response = new ResponseBase<PagedResult<TEntity>>();
            try
            {
                response.Data = await _repository.Read(expression, include, null).ConfigureAwait(true);
                return response;
            }
            catch (Exception ex)
            {
                return GenericUtility.ResponseBaseCatch<PagedResult<TEntity>>(true, ex, HttpStatusCode.InternalServerError);
            }
        }
        public async Task<ResponseBase<List<TEntity>>> ReadAll()
        {
            ResponseBase<List<TEntity>> response = new ResponseBase<List<TEntity>>();
            try
            {
                response.Data = await _repository.ReadAll().ConfigureAwait(true);
                return response;
            }
            catch (Exception ex)
            {
                return GenericUtility.ResponseBaseCatch<List<TEntity>>(true, ex, HttpStatusCode.InternalServerError);
            }
        }
        public async Task<ResponseBase<PagedOneResult<TEntity>>> ReadOne(Expression<Func<TEntity, bool>> expression)
        {
            ResponseBase<PagedOneResult<TEntity>> response = new ResponseBase<PagedOneResult<TEntity>>();
            try
            {
                response.Data = await _repository.ReadOne(expression);
                return response;
            }
            catch (Exception ex)
            {
                return GenericUtility.ResponseBaseCatch<PagedOneResult<TEntity>>(true, ex, HttpStatusCode.InternalServerError);
            }
        }
        public async Task<ResponseBase<PagedOneResult<TEntity>>> ReadOne(Expression<Func<TEntity, bool>> expression, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy)
        {
            ResponseBase<PagedOneResult<TEntity>> response = new ResponseBase<PagedOneResult<TEntity>>();
            try
            {
                response.Data = await _repository.ReadOne(expression, orderBy);
                return response;
            }
            catch (Exception ex)
            {
                return GenericUtility.ResponseBaseCatch<PagedOneResult<TEntity>>(true, ex, HttpStatusCode.InternalServerError);
            }
        }
        public async Task<ResponseBase<bool>> Update(TEntity newEntity, TEntity oldEntity)
        {
            ResponseBase<bool> response = new ResponseBase<bool>();
            try
            {
                response.Data = await _repository.Update(newEntity).ConfigureAwait(true);
                return response;
            }
            catch (Exception ex)
            {
                return GenericUtility.ResponseBaseCatch<bool>(true, ex, HttpStatusCode.InternalServerError);
            }
        }
    }
}