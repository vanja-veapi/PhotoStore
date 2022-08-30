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
    public class BrandsController : ControllerBase
    {
        // GET: api/<BrandsController>
        [HttpGet]
        public IActionResult Get()
        {
            var context = new PhotoContext();

            var brands = context.Brands.AsQueryable();
            return Ok(brands.ToList());
        }

        // GET api/<BrandsController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var context = new PhotoContext();
            var errors = new List<string>();
            var brand = context.Brands.Where(x => x.Id == id).FirstOrDefault();

            if (!context.Brands.Any(x => x.Id == id))
            {
                errors.Add("There is no Brand with that ID.");
            }

            if (errors.Any())
            {
                return UnprocessableEntity(errors);
            }

            return Ok(brand);
        }

        // POST api/<BrandsController>
        [HttpPost]
        public IActionResult Post([FromBody] InsertBrandDto dto)
        {
            var context = new PhotoContext();

            var errors = new List<string>();

            if (string.IsNullOrEmpty(dto.Name))
            {
                errors.Add("Brand name is required");
            }

            if (errors.Any())
            {
                return UnprocessableEntity(errors);
            }

            if(context.Brands.Any(x => x.Name == dto.Name))
            {
                errors.Add("Brand already exist!");
            }

            if (errors.Any())
            {
                return UnprocessableEntity(errors);
            }

            var brand = new Brand
            {
                Name = dto.Name
            };

            context.Brands.Add(brand);
            context.SaveChanges();

            return new ContentResult() { Content = "You have successfully added a new brand", StatusCode = 201 };
        }

        // PUT api/<BrandsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<BrandsController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var context = new PhotoContext();
            var brand = context.Brands.FirstOrDefault(x => x.Id == id);

            context.Brands.Remove(brand);
            context.SaveChanges();

            return NoContent();
        }
    }
}
