using Projekt.Web.Models;
using System;
using System.Collections.Generic;

namespace Projekt.Models
{
    public interface IMessagesRepository
    {
        void Add(Messages item);
        void Update(Messages item);
      //  void Remove(int id);
      //  Messages Get(int id);
        IEnumerable<Messages> GetAll(int IdSender, int IdReceiver);
    }
}
