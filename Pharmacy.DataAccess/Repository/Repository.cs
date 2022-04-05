using Pharmacy.DataAccess.Data;
using Pharmacy.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Pharmacy.DataAccess.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DataProcessor _dp;

        public Repository(string connectionString)
        {
            _dp = new DataProcessor(connectionString);
        }

        public void Add(T entity)
        {
            _dp.Add(entity);
        }

        public IEnumerable<T> GetAll()
        {
            return _dp.GetAll<T>();
        }

        public T GetFirstOrDefault(Func<T, bool> filter)
        {
            return _dp.GetAll<T>().FirstOrDefault(filter);
        }

        public void Remove(T entity)
        {
            _dp.Remove(entity);
        }
    }
}