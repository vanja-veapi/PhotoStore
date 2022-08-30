using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PhotoAPI.DataAccess.Entities;
using PhotoStore.Application.UseCases.DTO;
using PhotoStore.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PhotoStore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        // GET: api/<UsersController>
        [HttpGet]
        public IActionResult Get([FromQuery] string keyword)
        {
            var context = new PhotoContext();

            var users = context.Users.AsQueryable();
            var errors = new List<string>();

            if (!string.IsNullOrEmpty(keyword))
            {
                users = users.Where(x => x.Username.Contains(keyword)
                || x.Name.Contains(keyword)
                || x.LastName.Contains(keyword));

                if(!users.Any())
                {
                    errors.Add("This user doesn't exist.");
                    return UnprocessableEntity(errors);
                }

                var dtos = users.Select(x => new User
                {
                    Name = x.Name,
                    LastName = x.LastName,
                    Username = x.Username,
                    Email = x.Email,
                    RoleId = x.RoleId,
                });

                return Ok(users);
            }

            return Ok(users.ToList());
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var context = new PhotoContext();
            var users = context.Users.AsQueryable();
            var errors = new List<string>();

            if(!context.Users.Any(x => x.Id == id))
            {
                errors.Add("There is no User with that ID.");
            }

            if (errors.Any())
            {
                return UnprocessableEntity(errors);
            }

            return Ok(users.Where(x => x.Id == id).FirstOrDefault());
        }


        // POST api/<UsersController>
        [HttpPost]
        public IActionResult Post([FromBody] InsertUserDto dto)
        {
            var context = new PhotoContext();

            var errors = new List<string>();

            //if(!dto.Id.HasValue)
            //{
            //    errors.Add("User ID is requried");
            //}

            if(string.IsNullOrEmpty(dto.Username))
            {
                errors.Add("Username is required");
            }

            if (string.IsNullOrEmpty(dto.Name))
            {
                errors.Add("Name is required");
            }

            if (string.IsNullOrEmpty(dto.LastName))
            {
                errors.Add("Last name is required");
            }

            if(string.IsNullOrEmpty(dto.Password))
            {
                errors.Add("Password is required");
            }

            if(errors.Any())
            {
                return UnprocessableEntity(errors);
            }

            //if(context.Users.Any(x => x.Id == dto.Id))
            //{
            //    errors.Add("User with that id doesn't exist");
            //}

            if(context.Users.Any(x => x.Username == dto.Username))
            {
                errors.Add("Username already exist!");
            }

            if (context.Users.Any(x => x.Email == dto.Email))
            {
                errors.Add("Email already exist!");
            }

            if (errors.Any())
            {
                return UnprocessableEntity(errors);
            }

            var user = new User
            {
                Username = dto.Username,
                Name = dto.Name,
                LastName = dto.LastName,
                Password = dto.Password,
                Email = dto.Email,
                RoleId = dto.RoleId,
                IsActive = true
            };

            context.Users.Add(user);
            context.SaveChanges();

            return new ContentResult() { Content = "You have successfully added, a new user", StatusCode = 201 };
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] InsertUserDto dto)
        {
            var context = new PhotoContext();
            dto.Id = id;
            dto.isActive = true;

            PropertyInfo[] properties = typeof(InsertUserDto).GetProperties();

            var currentUser = context.Users.Where(x => x.Id == dto.Id).FirstOrDefault();

            if(currentUser == null)
            {
                return NotFound();
            }

            if(dto.Name != null)
            {
                currentUser.Name = dto.Name;
            }

            if(dto.LastName != null)
            {
                currentUser.LastName = dto.LastName;
            }

            if(dto.Username != null)
            {
                currentUser.Username = dto.Username;
            }

            if(dto.Password != null)
            {
                currentUser.Password = dto.Password;
            }

            if(dto.ProfileImage != null)
            {
                currentUser.ProfileImage = dto.ProfileImage;
            }

            if(dto.RoleId != 0)
            { 
                currentUser.RoleId = dto.RoleId;
            }

            currentUser.IsActive = dto.isActive;

            context.SaveChanges();
            

            return StatusCode(204);
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var context = new PhotoContext();

            var user = context.Users.FirstOrDefault(x => x.Id == id);

            if(user == null)
            {
                return NotFound();
            }

            context.Users.Remove(user);
            context.SaveChanges();

            return NoContent();
        }
    }
}
