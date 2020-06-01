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
        private readonly UsersDbContext _dbContext;

        public UsersController(IItemRepository DbUsersRepository, UsersDbContext usersDbContext)
        {
            ItemRepository = DbUsersRepository;
            _dbContext = usersDbContext;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<Users>> List()
        {
            return ItemRepository.GetAll().ToList();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Users> GetItem(int id)
        {
            try { 
            Users item = ItemRepository.Get(id);
                if (item == null)
                    return NotFound();
                return item;
            }
            catch (Exception)
            {
                return BadRequest("Error while getting item");
            }
            
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Users> Create([FromBody]Users item)
        {
            try
            {
                ItemRepository.Add(item);
            }
            catch (Exception)
            {
                return BadRequest("Error while adding item");
            }
            return NoContent();
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult Edit([FromBody] Users item)
        {
            try
            {
                ItemRepository.Update(item);
            }
            catch (Exception)
            {
                return BadRequest("Error while editing item");
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult Delete(int id)
        {
            try
            {
                ItemRepository.Remove(id);
            }
            catch (Exception)
            {
                return BadRequest("Error while removing item");
            }
            return NoContent();
        }
    }
}
