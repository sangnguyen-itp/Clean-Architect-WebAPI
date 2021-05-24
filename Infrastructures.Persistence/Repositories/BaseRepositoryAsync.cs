using Application.Interfaces;
using Infrastructures.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructures.Persistence.Repositories
{
    public class BaseRepositoryAsync<T> : IBaseRepositoryAsync<T> where T : class
    {
        private readonly ApplicationDBContext _context;
        private readonly DbSet<T> entities;

        public BaseRepositoryAsync(ApplicationDBContext context)
        {
            _context = context;
            entities = _context.Set<T>();
        }

        public async Task<T> AddAsync(T entity)
        {
            await entities.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(T entity)
        {
            entities.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await entities.ToListAsync();
        }

        public async Task<IReadOnlyList<T>> GetByCondition(Expression<Func<T, bool>> expression)
        {
            return await entities.Where(expression).ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await entities.FindAsync(id);
        }

        public async Task<IReadOnlyList<T>> GetPagedReponseAsync(int pageNumber, int pageSize)
        {
            return await entities
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
