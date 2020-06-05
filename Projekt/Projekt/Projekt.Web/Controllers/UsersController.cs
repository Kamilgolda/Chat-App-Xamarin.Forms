using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projekt.Models;
using Projekt.Web.Data;

namespace Projekt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IItemRepository ItemRepository;
        public UsersDbContext _dbContext;


        public UsersController(IItemRepository DbUsersRepository, UsersDbContext UsersDbContext)
        {
            ItemRepository = DbUsersRepository;
            _dbContext = UsersDbContext;
        }


        // GET: api/Students
        [HttpGet]
        public IEnumerable<Users> Get()
        {
            return ItemRepository.GetAll().ToList();

        }
        // GET: api/Students/5
        [HttpGet("{id}", Name = "Get")]
        public Users Get(int id)
        {
            return ItemRepository.Get(id);
        }
        // POST: api/Students
        [HttpPost]
        public void Post([FromBody] Users item)
        {
            ItemRepository.Add(item);
        }
        // PUT: api/Students/5
        [HttpPut]
        public void Put([FromBody] Users value)
        {
            ItemRepository.Update(value);
        }
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            ItemRepository.Remove(id);
        }




    }
}
