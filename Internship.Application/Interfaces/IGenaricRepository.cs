using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Internship.Application.Interfaces
{
    public interface IGenaricRepository<T> where T : class
    {
        Task<T> GetByIdAsync(int id, params Expression<Func<T,object>>[] includs);
        Task<IReadOnlyList<T>> GetAllAsync( params Expression<Func<T, object>>[] includs);
        Task AddAsync(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
