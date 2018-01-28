using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.DataAccess.Repository
{
    public interface IDataAccess<T>
    {
        string CollectionName { set; get; }
        void Add(T entity);
        void Remove(T entity);
        void Modify(T entity);

        T Fetch(T property);
    }
}
