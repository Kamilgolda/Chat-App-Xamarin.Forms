using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using zadApi.Models;
using zadApi.Web.Data;

namespace zadApi.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ZdjeciaController : ControllerBase
    {
        private readonly IItemRepository ItemRepository;
        private readonly StudentsDbContext _dbContext;


        public ZdjeciaController(IItemRepository DbitemRepository, StudentsDbContext studentsDbContext)
        {
            ItemRepository = DbitemRepository;
            _dbContext = studentsDbContext;
        }
        // GET: api/Zdjecia
        [HttpGet]
        public IEnumerable<Zdjęcia> Get()
        {
            return ItemRepository.GetAllZdjecia().ToList();
        }

        // GET: api/Zdjecia/5
        [HttpGet("{id}", Name = "GetZdjecie")]
        public Zdjęcia Get(int id)
        {
            return ItemRepository.GetZdjecie(id);
        }


        // POST: api/Zdjecia
        [HttpPost]
        public void Post([FromBody] Zdjęcia item)
        {
            ItemRepository.Add(item);
        }

        // PUT: api/Zdjecia/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
