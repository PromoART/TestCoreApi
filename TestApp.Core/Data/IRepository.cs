using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TestApp.Core.Data
{
    public interface IRepository<T> where T: class
    {
        Task<IEnumerable<T>> GetAll();

        Task Create(T entity);

        Task Update(T entity);

        Task Delete(string id);
    }
}
