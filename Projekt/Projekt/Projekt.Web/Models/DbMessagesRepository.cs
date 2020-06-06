using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using Projekt.Web.Data;
using System.Linq;
using Projekt.Web.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace Projekt.Models
{
    public class DbMessagesRepository : IMessagesRepository
    {
        private readonly UsersDbContext _usersDbContext;

        public DbMessagesRepository(UsersDbContext usersDbContext)
        {
            _usersDbContext = usersDbContext;
        }

        public IEnumerable<Messages> GetAll(int IdSender,int IdReceiver)
        {
            List<Messages> lista = new List<Messages>();
            foreach (Messages x in _usersDbContext.Messages)
            {
                if (x.IdSender == IdSender && x.IdReceiver == IdReceiver) lista.Add(x);
                if (x.IdSender == IdReceiver && x.IdReceiver == IdSender) lista.Add(x);
            }
            return lista;
            

        }

        public void Add(Messages item)
        {
            _usersDbContext.Messages.Add(item);
            _usersDbContext.SaveChanges();
        }


        public void Update(Messages item)
        {
            var itemupd = _usersDbContext.Messages.Where(x => x.IdSender == item.IdSender && x.IdReceiver == item.IdReceiver);
            

            
            foreach (var x in itemupd)
            {
                x.Received = item.Received;
                x.Blocked = item.Blocked;
                _usersDbContext.Messages.Update(x);
            }
            

            _usersDbContext.SaveChanges();
                
        }
    }
}
