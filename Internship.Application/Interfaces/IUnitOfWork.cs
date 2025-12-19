using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internship.Application.Interfaces
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        IGenaricRepository<T> Repository<T>() where T : class;
        Task<int> CompleteAsync();
    }
}
