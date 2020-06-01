using System;
using System.Collections.Generic;

namespace Projekt.Models
{
    public interface IItemRepository
    {
        void Add(Users item);
        void Update(Users item);
        void Remove(int id);
        Users Get(int id);
        IEnumerable<Users> GetAll();
    }
}
