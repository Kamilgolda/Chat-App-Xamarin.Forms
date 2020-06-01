using CzysteAPI.Models;
using Microsoft.AspNetCore.Http.Features;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using zadApi.Models;
using zadApi.Web.Data;

namespace zadApi.Web.Models
{
    public class DbItemRepository : IItemRepository
    {
        private readonly StudentsDbContext _studentsDbContext;

        public DbItemRepository(StudentsDbContext studentsDbContext)
        {
            _studentsDbContext = studentsDbContext;
        }

        public void Add(Student item)
        {
            item.Id = Guid.NewGuid().ToString();
            _studentsDbContext.Items.AddAsync(item);
            _studentsDbContext.SaveChanges();
        }


        public Student Get(string id)
        {
            return _studentsDbContext.Items.FirstOrDefault(x => x.Id == id);   
        }

        public IEnumerable<Student> GetAll()
        {
           return _studentsDbContext.Items.ToList();
        }

       

        public void Remove(string key)
        {
            var item = _studentsDbContext.Items.FirstOrDefault(x => x.Id == key);
            _studentsDbContext.Items.Remove(item);
            _studentsDbContext.SaveChanges();
        }

        public void Update(Student item)
        {
            var itemupd = _studentsDbContext.Items.FirstOrDefault(x => x.Id == item.Id);
            itemupd.Imie = item.Imie;
            itemupd.Nazwisko = item.Nazwisko;
            itemupd.NrAlbumu = item.NrAlbumu;
            itemupd.Plec = item.Plec;
            _studentsDbContext.Items.Update(itemupd);
            _studentsDbContext.SaveChanges();
        }

        public void Add(Zdjęcia item)
        {
            _studentsDbContext.Zdjecia.AddAsync(item);
            _studentsDbContext.SaveChanges();
        }

        public IEnumerable<Zdjęcia> GetAllZdjecia()
        {
            return _studentsDbContext.Zdjecia.ToList();
        }

        public Zdjęcia GetZdjecie(int id)
        {
            return _studentsDbContext.Zdjecia.FirstOrDefault(x => x.Id == id);
        }
    }
}
