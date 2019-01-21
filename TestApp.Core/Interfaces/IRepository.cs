using System;
using System.Collections.Generic;
using System.Text;

namespace TestApp.Core.Interfaces
{
    public interface IRepository<T> where T: class
    {
        IEnumerable<T> GetAll();
        T Get(T entity);

        void Create(T entity);

        void Update(T newEntity);

        void Delete(T entity);
    }
}
