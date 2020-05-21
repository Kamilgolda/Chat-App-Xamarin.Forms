using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using zadApi.Models;

namespace zadApi.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        public static List<Student> list = new List<Student>()
 {
 new Student() { Id = 1, Imie = "Jan", Nazwisko = "Kowalski", NrAlbumu = "123", Plec = "Men"},
 new Student() { Id = 2, Imie = "Sylwia", Nazwisko = "Kowalska", NrAlbumu = "321", Plec = "Kobieta"},
 new Student() { Id = 3, Imie = "Adam", Nazwisko = "Kowalski", NrAlbumu = "34421", Plec = "Men"},
 new Student() { Id = 4, Imie = "Marek", Nazwisko = "Kowalski", NrAlbumu = "32551", Plec = "Men"}
    };
        public static int licznikid=4;
    // GET: api/Students
    [HttpGet]
        public IEnumerable<Student> Get()
        {
            return list;
        }
        // GET: api/Students/5
        [HttpGet("{id}", Name = "Get")]
        public Student Get(int id)
        {
            return list.FirstOrDefault(x => x.Id == id);
        }
        // POST: api/Students
        [HttpPost]
        public void Post([FromBody] Student item)
        {
            item.Id = ++licznikid;
            list.Add(item);
        }
        // PUT: api/Students/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Student value)
        {
            var item = list.FirstOrDefault(x => x.Id == id);
            item.Imie = value.Imie;
            item.Nazwisko = value.Nazwisko;
            item.NrAlbumu = value.NrAlbumu;
            item.Plec = value.Plec;
        }
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var item = list.FirstOrDefault(x => x.Id == id);
            list.Remove(item);
        }
    }
}