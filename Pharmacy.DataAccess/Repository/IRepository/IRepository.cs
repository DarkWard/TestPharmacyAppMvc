using System;
using System.Collections.Generic;

namespace Pharmacy.DataAccess.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        T GetFirstOrDefault(Func<T, bool> filter);
        IEnumerable<T> GetAll();
        void Add(T entity);
        void Remove(T entity);
    }
}