using Microsoft.AspNetCore.Mvc;
using ConsoleApp1.Models;

namespace ConsoleApp1.Controllers
{
    [Route("api/animals/{animalId:int}/[controller]")]
    [ApiController]
    public class VisitsController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetVisits(int animalId)
        {
            var visits = Database.Visits.Where(v => v.AnimalId == animalId).ToList();
            return Ok(visits);
        }

        [HttpPost]
        public IActionResult AddVisit(int animalId, [FromBody] Visit newVisit)
        {
            if (!Database.Animals.Any(a => a.Id == animalId))
                return NotFound($"Zwierzę o ID {animalId} nie istnieje.");

            Database.Visits.Add(newVisit);
            return CreatedAtAction(nameof(GetVisits), new { animalId = animalId }, newVisit);
        }
    }
}