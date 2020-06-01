using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using zadApi.Models;

namespace zadApi.Web.Data
{
    public class StudentsDbContext :DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=StudentsDB;Trusted_Connection=True;");
        }


        public DbSet<Student> Items { get; set; }
        public DbSet<Zdjęcia> Zdjecia { get; set; }
    }
}
