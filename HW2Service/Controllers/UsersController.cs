using HW2Service.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HW2Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private static List<User> users = new List<User>();
        private static int currentUserID = 101;

        // GET: api/Users
        [HttpGet]
        public IEnumerable<User> Get()
        {
            //TODO: proper error message if users is null
            if (users != null)
                return users;
            else
                return null;
 
        }

        // GET api/Users/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            var user = users.FirstOrDefault(u => u.Id == id);

            if (user == null) {

                int statusCode = 404;               
                return NotFound(new ApiResponse(statusCode, id));
            }
            return Ok(user);
        }

        // POST api/Users
        [HttpPost]
        public IActionResult Post([FromBody] User value)
        {
            if (value == null || value.Email == null || value.Password == null)
            {
                int statusCode = 400;
                return BadRequest(new ApiResponse(statusCode, value));
            }

            value.Id = currentUserID++;
            value.CreatedDate = DateTime.Now;

            users.Add(value);

            var result = new { Id = value.Id };
            return CreatedAtAction(nameof(Get), new { id = value.Id }, result);

        }
        
        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] User value)
        {
            User user = users.Where(i => i.Id == id).FirstOrDefault();

            if (user == null)
            {
                int statusCode = 404;
                return NotFound(new ApiResponse(statusCode, id));
            }

            user.Email = value.Email;
            user.Password = value.Password;

            return Ok(user);
            
        }
    

        // DELETE api/users/5  not clear on this
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var usersDeleted = users.RemoveAll(u => u.Id == id);

            if (usersDeleted == 0)
            {
                int statusCode = 404;
                return NotFound(new ApiResponse(statusCode, id));
            }
            else
            {
                return Ok();
            }
        }


    }
}
