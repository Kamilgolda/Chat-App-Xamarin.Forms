using Microsoft.EntityFrameworkCore;
using Projekt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt.Web.Data
{
    public class UsersDbContext: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=ProjektDB;Trusted_Connection=True;");
        }
        public DbSet<Users> Users { get; set; }
    }
}
