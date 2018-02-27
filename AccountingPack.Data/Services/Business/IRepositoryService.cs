using System;
using System.Collections.Generic;
using System.Text;

namespace AccountingPack.Data
{
    /// <summary>
    /// T business model
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepositoryService<T> where T : class
    {
        void Create(T model);
        T Detail(int? id);
        void Edit(T model);
        void Delete(T model);
        List<T> List(Func<T, bool> predicate = null);
        void SaveChanges();
    }
}
