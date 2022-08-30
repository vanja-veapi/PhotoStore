using Microsoft.AspNetCore.Mvc;
using PhotoAPI.DataAccess.Entities;
using PhotoStore.Application.UseCases.DTO;
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
    public class CameraController : ControllerBase
    {
        // GET: api/<CameraController>
        [HttpGet]
        public IActionResult Get([FromQuery] string keyword)
        {
            var context = new PhotoContext();
            var cameras = context.Cameras.AsQueryable();
            var errors = new List<string>();

            if (!string.IsNullOrEmpty(keyword))
            {
                cameras = cameras.Where(x => x.Name.Contains(keyword));

                if (!cameras.Any())
                {
                    errors.Add("This Camera doesn't exist.");
                    return UnprocessableEntity(errors);
                }

            }

            return Ok(cameras.ToList());
        }

        // GET api/<CameraController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var context = new PhotoContext();
            var camera = context.Cameras.AsQueryable();

            var errors = new List<string>();

            if (!context.Cameras.Any(x => x.Id == id))
            {
                errors.Add("There is no User with that ID.");
            }

            if (errors.Any())
            {
                return UnprocessableEntity(errors);
            }

            return Ok(camera.Where(x => x.Id == id).FirstOrDefault());
        }

        // POST api/<CameraController>
        [HttpPost]
        public IActionResult Post([FromBody] InsertCameraDto dto)
        {
            var context = new PhotoContext();

            var errors = new List<string>();

            if(dto.Price.Equals(null))
            {
                errors.Add("Price is required");
            }

            if(string.IsNullOrEmpty(dto.Name))
            {
                errors.Add("Name is required");
            }

           if(!context.Brands.Any(x => x.Id == dto.BrandId))
           {
                errors.Add("Brand is required");
           }

            if(context.Cameras.Any(x => x.Name == dto.Name))
            {
                errors.Add("Model is already in DB");
            }

            if (errors.Any())
            {
                return UnprocessableEntity(errors);
            }

            var camera = new Camera
            {
                BrandId = dto.BrandId.Value,
                Name = dto.Name,
                Image = dto.Image,
                Price = dto.Price,
                OldPrice = dto.OldPrice,
                IsActive = true
            };

            context.Cameras.Add(camera);
            context.SaveChanges();

            return new ContentResult() { Content = "You have successfully added a new camera", StatusCode = 201 };
        }

        // PUT api/<CameraController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] InsertCameraDto dto)
        {
            var context = new PhotoContext();

            var currentCamera = context.Cameras.Where(x => x.Id == id).FirstOrDefault();

            if(dto.Name != null)
            {
                currentCamera.Name = dto.Name;
            }

            if(dto.Price > 0)
            {
                currentCamera.Price = dto.Price;
            }

            if(dto.OldPrice >= 0)
            {
                currentCamera.OldPrice = dto.Price;
            }

            if(dto.Image != null || dto.Image != "string")
            {
                currentCamera.Image = dto.Image;
            }

            currentCamera.IsActive = true;
            context.SaveChanges();

            return StatusCode(204);
        }

        // DELETE api/<CameraController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var context = new PhotoContext();

            var camera = context.Cameras.FirstOrDefault(x => x.Id == id);

            if(camera == null)
            {
                return NotFound();
            }

            context.Cameras.Remove(camera);
            context.SaveChanges();

            return NoContent();
        }
    }
}
