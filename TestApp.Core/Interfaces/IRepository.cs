using System;
using System.Collections.Generic;

namespace TestApp.Core.Interfaces
{
    public interface IRepository<T>:IDisposable where T: class
    {
        IEnumerable<T> GetAll();
        T Get(int id);

        void Create(T entity);

        void Update(T newEntity);

        void Delete(int id);
    }
}
