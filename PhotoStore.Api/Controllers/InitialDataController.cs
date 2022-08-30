using Microsoft.AspNetCore.Mvc;
using PhotoAPI.DataAccess.Entities;
using PhotoStore.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PhotoStore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InitialDataController : ControllerBase
    {
      
        

        // POST api/<InitialDataController>
        [HttpPost]
        public IActionResult Post()
        {
            var context = new PhotoContext();

            if(context.Users.Any())
            {
                return Conflict();
            }

            var roles = new List<Role>
            {
                new Role {Name = "User"},
                new Role {Name = "Admin"},
            };

            var users = new List<User>
            {
                new User {Name = Faker.Name.First(), LastName = Faker.Name.Last(), Username = "pera01", Email = Faker.Internet.Email(), Password = "Qwe123", Role = roles.Last(), ProfileImage = null},
                new User {Name = Faker.Name.First(), LastName = Faker.Name.Last(), Username = "pera02", Email = Faker.Internet.Email(), Password = "Qwe123", Role = roles.First(), ProfileImage = null},
                new User {Name = Faker.Name.First(), LastName = Faker.Name.Last(), Username = "pera03", Email = Faker.Internet.Email(), Password = "Qwe123", Role = roles.First(), ProfileImage = null},
                new User {Name = Faker.Name.First(), LastName = Faker.Name.Last(), Username = "pera04", Email = Faker.Internet.Email(), Password = "Qwe123", Role = roles.First(), ProfileImage = null},
            };


            var brands = new List<Brand>
            {
                new Brand {Name = "Canon"},
                new Brand {Name = "Nikon"},
                new Brand {Name = "Fuji"},
                new Brand {Name = "Sony"},
                new Brand {Name = "Sigma"},
            };

            // Imao sam neki problem sa fakerom za deskripciju, verovatno je bilo previse karaktera pa nije hteo da radi...
            var cameras = new List<Camera>
            {
                new Camera {Name = "Camera 1", Brand = brands.First(), Price = 300, OldPrice = null, Description = "desc 1", Image = "imagepath"},
                new Camera {Name = "Camera 2", Brand = brands.ElementAt(1), Price = 300, OldPrice = 600, Description = "desc 2", Image = "imagepath"},
                new Camera {Name = "Camera 3", Brand = brands.ElementAt(1), Price = 100, OldPrice = null, Description = "desc 3", Image = "imagepath"},
                new Camera {Name = "Camera 4", Brand = brands.ElementAt(2), Price = 100, OldPrice = null, Description = "desc 4", Image = "imagepath"},
                new Camera {Name = "Camera 5", Brand = brands.ElementAt(2), Price = 1000, OldPrice = 6000, Description = "desc 5", Image = "imagepath"},
                new Camera {Name = "Camera 6", Brand = brands.First(), Price = 900, OldPrice = 3000, Description = "desc 6", Image = "imagepath"},
                new Camera {Name = "Camera 7", Brand = brands.ElementAt(3), Price = 900, OldPrice = null, Description = "desc 7", Image = "imagepath"},
            };

            context.AddRange(roles);
            context.AddRange(brands);
            context.AddRange(cameras);
            context.AddRange(users);

            context.SaveChanges();
            return StatusCode(201);
        }

      
    }
}
