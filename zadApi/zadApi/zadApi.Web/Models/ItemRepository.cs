using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using zadApi.Models;

namespace CzysteAPI.Models
{
    public class ItemRepository : IItemRepository
    {
        private static ConcurrentDictionary<string, Student> items = new ConcurrentDictionary<string, Student>();

        public ItemRepository()
        {
            if (items.Count==0)
            {
                Add(new Student() { Id = Guid.NewGuid().ToString(), Imie = "Jan", Nazwisko = "Kowalski", NrAlbumu = "123", Plec = "Men" });
                Add(new Student() { Id = Guid.NewGuid().ToString(), Imie = "Sylwia", Nazwisko = "Kowalska", NrAlbumu = "321", Plec = "Kobieta" });
                Add(new Student() { Id = Guid.NewGuid().ToString(), Imie = "Adam", Nazwisko = "Kowalski", NrAlbumu = "34421", Plec = "Men" });
                Add(new Student() { Id = Guid.NewGuid().ToString(), Imie = "Marek", Nazwisko = "Kowalski", NrAlbumu = "32551", Plec = "Men" });
            }
            
        }

        public IEnumerable<Student> GetAll()
        {
            return items.Values;
        }

        public void Add(Student item)
        {
            item.Id = Guid.NewGuid().ToString();
            items[item.Id] = item;
        }

        public Student Get(string id)
        {
            items.TryGetValue(id, out Student item);
            return item;
        }

        public void Remove(string id)
        {
            items.TryRemove(id, out Student item);
            //return item;
        }

        public void Update(Student item)
        {
            items[item.Id] = item;
        }

        public void Add(Zdjęcia item)
        {
            throw new NotImplementedException();
        }

        public Zdjęcia GetZdjecie(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Zdjęcia> GetAllZdjecia()
        {
            throw new NotImplementedException();
        }
    }
}
