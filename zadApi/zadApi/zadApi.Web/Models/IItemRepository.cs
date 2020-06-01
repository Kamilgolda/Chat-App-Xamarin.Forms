using System;
using System.Collections.Generic;
using zadApi.Models;

namespace zadApi.Models
{
    public interface IItemRepository
    {
        void Add(Student item);
        void Update(Student item);
        void Remove(string key);
        Student Get(string id);
        IEnumerable<Student> GetAll();

        void Add(Zdjęcia item);
        Zdjęcia GetZdjecie(int id);
        IEnumerable<Zdjęcia> GetAllZdjecia();
    }
}
