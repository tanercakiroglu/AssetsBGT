using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Assets.DataAccessLayer.Interface
{
    public interface IRepository<T> where T : class
    {
        void Add(T item,string sql);
        void Remove(T item, string sql);
        void Update(T item, string sql);
        IEnumerable<T> Find(Expression<Func<T, bool>> predicate);
        IEnumerable<T> FindAll(string tableName);
    }
}
