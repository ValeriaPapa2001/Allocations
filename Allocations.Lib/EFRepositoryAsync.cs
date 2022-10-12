using Allocations.Lib.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Allocations.Lib
{
    public abstract class EFRepositoryAsync<T> : IRepositoryAsync<T> where T : class
    {
        private readonly DbContext _dbContext;
        private readonly Func<DbSet<T>> _dbSet;
        public EFRepositoryAsync(DbContext dbContext, Func<DbSet<T>> dbSet)
        {
            _dbContext = dbContext;
            _dbSet = dbSet;
        }

        public async Task<CudResult> DeleteAsync(object id)
        {
            T entity = await GetByIdAsync(id);
            if (entity == null)
                return new CudResult($"Entity {id} is null");

            _dbSet().Remove(entity);
            try
            {
                await _dbContext.SaveChangesAsync();
                return new CudResult();
            }
            catch (Exception e)
            {
                return new CudResult(e);
            }
        }

        public async Task<IEnumerable<T>> FetchAsync(Func<T, bool> filter = null)
        {
            if (filter==null)
            {
                return await _dbSet().ToListAsync();
            }
            return _dbSet().Where(filter).ToList();
        }

        public async Task<T> GetByIdAsync(object id)
        {
            return await _dbSet().FindAsync(id);
        }

        public async Task<CudResult> InsertAsync(T entity)
        {
            if(entity==null)
            {
                return new CudResult("Entity is null");
            }
            _dbSet().Add(entity);
            try
            {
                await _dbContext.SaveChangesAsync();
                return new CudResult();
            }
            catch(Exception ex)
            {
                return new CudResult(ex);
            }
        }

        public async Task<CudResult> UpdateAsync(T entity)
        {
            if(entity == null)
            {
                return new CudResult("Entity is null");
            }
            _dbSet().Attach(entity).State = EntityState.Modified;
            try
            {
                await _dbContext.SaveChangesAsync();
                return new CudResult();
            }
            catch(Exception ex)
            {
                return new CudResult(ex);
            }

        }
    }
}
