using DemoProject.Data;
using DemoProject.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoProject.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly MyDBContext _dbContext;

        public Repository(MyDBContext dbContext) { 
            _dbContext = dbContext;
        }
        public async Task<T> CreateAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> DeleteAsync(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            int rows = await _dbContext.SaveChangesAsync();
            return rows > 0;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
           return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int Id)
        {
           return await _dbContext.Set<T>().FindAsync(Id);
        }

        public async Task<T> UpdateAsync(T entity)
        {
            _dbContext.Set<T>().Update(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }
    }
}
