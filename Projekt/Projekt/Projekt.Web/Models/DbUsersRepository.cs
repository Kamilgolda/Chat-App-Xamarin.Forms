using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using Projekt.Web.Data;
using System.Linq;

namespace Projekt.Models
{
    public class DbUsersRepository : IItemRepository
    {
        private UsersDbContext _usersDbContext;

        public DbUsersRepository(UsersDbContext UsersDbContext)
        {
            _usersDbContext = UsersDbContext;
        }

        public IEnumerable<Users> GetAll()
        {
            return _usersDbContext.Users.ToList();
        }

        public void Add(Users item)
        {
            _usersDbContext.Users.AddAsync(item);
            _usersDbContext.SaveChanges();
        }

        public Users Get(int id)
        {
            return _usersDbContext.Users.FirstOrDefault(x => x.IdUser == id);
        }

        public void Remove(int id)
        {
            var item = _usersDbContext.Users.FirstOrDefault(x => x.IdUser == id);
            _usersDbContext.Users.Remove(item);
            _usersDbContext.SaveChanges();
        }

        public void Update(Users item)
        {
            var itemupd = _usersDbContext.Users.FirstOrDefault(x => x.IdUser == item.IdUser);
            itemupd.Name = item.Name;
            itemupd.LastName = item.LastName;
            itemupd.Dateofbirth = item.Dateofbirth;
            itemupd.Email = item.Email;
            itemupd.Image = item.Image;
            itemupd.Password = item.Password;
            _usersDbContext.Users.Update(itemupd);
            _usersDbContext.SaveChanges();
        }
    }
}
