using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.DataAccess.Repository;

namespace Assets.Scripts.Logic
{
    public interface IRepositoryFactory<T>
    {
        IDataAccess<T> CreateRepository(string connectionString, string type);
    }
}
