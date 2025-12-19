using Internship.Application.Interfaces;
using Internship.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Internship.Infrastructure
{
    public class GenaricRepository<T> : IGenaricRepository<T> where T : class
    {

        private  readonly InternshipDbContext _context;
        public GenaricRepository(InternshipDbContext context) 
        {
            _context = context;
        }
        public async Task AddAsync(T entity)
            => await _context.Set<T>().AddAsync(entity);

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public async Task<IReadOnlyList<T>> GetAllAsync(params Expression<Func<T, object>>[] includs)
        { 
            var query = _context.Set<T>().AsQueryable();
            if (includs != null)
            {
                foreach (var include in includs)
                {
                    query = query.Include(include);
                }
            }
            return await query.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id, params Expression<Func<T, object>>[] includs)
        {
            var query = _context.Set<T>().AsQueryable();
            if (includs != null)
            {
                foreach (var include in includs)
                {
                    query = query.Include(include);
                }
            }
            return await query.FirstOrDefaultAsync(e => EF.Property<int>(e, "Id") == id);
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }
    }
}
