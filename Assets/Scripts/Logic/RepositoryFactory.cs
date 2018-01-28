using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.DataAccess.Repository;
using Assets.Scripts.DataAccess.Repository.JsonRepository;

namespace Assets.Scripts.Logic
{
    public class RepositoryFactory<T> : IRepositoryFactory<T>
    {
        public IDataAccess<T> CreateRepository(string connectionString, string type)
        {
            switch (type)
            {
                case "ItemRepository":
                    return (IDataAccess<T>) ItemRepositoryJson.CreateItemRepository("Items");
                    break;
                default:
                    throw new ArgumentException();
            }
        }
    }
}
