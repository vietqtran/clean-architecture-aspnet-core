using Microsoft.EntityFrameworkCore;
using Solution.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Persistence.Repositories {

    public class GenericRepository<T> : IGenericRepository<T> where T : class {

        private readonly SolutionDbContext _dbContext;

        public GenericRepository (SolutionDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<T> Add (T entity)
        {
            await _dbContext.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task Delete (T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<bool> Exists (int id)
        {
            var entity = await GetAsync(id);
            return entity != null;
        }

        public async Task<IReadOnlyList<T>> GetAll ( )
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task<T> GetAsync (int id)
        {
            var entity = await _dbContext.Set<T>().FindAsync(id);
            return entity;
        }

        public async Task Update (T entity)
        {
            var updatedEntity = _dbContext.Set<T>().Update(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
