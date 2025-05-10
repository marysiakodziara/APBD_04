using Microsoft.AspNetCore.Mvc;
using ConsoleApp1.Models;

namespace ConsoleApp1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalsController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(Database.Animals);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var animal = Database.Animals.FirstOrDefault(a => a.Id == id);
            return animal is not null ? Ok(animal) : NotFound();
        }

        [HttpGet("search/{name}")]
        public IActionResult SearchByName(string name)
        {
            var result = Database.Animals
                .Where(a => a.Name.Equals(name, StringComparison.OrdinalIgnoreCase))
                .ToList();

            return result.Any() ? Ok(result) : NotFound();
        }

        [HttpPost]
        public IActionResult Add([FromBody] Animal animal)
        {
            Database.Animals.Add(animal);
            return CreatedAtAction(nameof(GetById), new { id = animal.Id }, animal);
        }

        [HttpPut("{id:int}")]
        public IActionResult Update(int id, [FromBody] Animal updatedAnimal)
        {
            var index = Database.Animals.FindIndex(a => a.Id == id);
            if (index == -1)
                return NotFound();

            Database.Animals[index] = updatedAnimal;
            return Ok(updatedAnimal);
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            var animal = Database.Animals.FirstOrDefault(a => a.Id == id);
            if (animal is null)
                return NotFound();

            Database.Animals.Remove(animal);
            return NoContent();
        }
    }
}