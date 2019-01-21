using System;
using System.Collections.Generic;

namespace TestApp.Core.Interfaces
{
    public interface IDataStoreProvider<T> where T : class
    {
        IEnumerable<T> GetAll();
        T Get(T entity);
        void Create(T entity);
        void Delete(T entity);
        void Update(T newEntity);
        
    }
}
