using Core.DTOs;
using Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using Swashbuckle.AspNetCore.Annotations;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalController : ControllerBase
    {
        private readonly IAnimalService _animalService;

        public AnimalController(IAnimalService animalService)
        {
            _animalService = animalService;
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Creates new animal entry")]
        public async Task<IActionResult> CreateAnimal([FromBody] AnimalDto animal)
        {
            await _animalService.CreateAsync(animal);
            return Ok("Animal record created");
        }

        [HttpPut("{id}")]
        [SwaggerOperation(Summary = "Updates an existing animal record")]
        public async Task<IActionResult> UpdateAnimal([FromRoute] ObjectId id, [FromBody] AnimalDto animalDto)
        {
            await _animalService.UpdateAsync(id, animalDto);
            return Ok("Animal record updated");
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "Deletes a animal record by Id")]
        public async Task<IActionResult> DeleteAnimalAsync([FromRoute] ObjectId id)
        {
            await _animalService.DeleteAsync(id);
            return NoContent();
        }

        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Gets a animal by its Id")]
        public async Task<IActionResult> GetAnimalById([FromRoute] ObjectId id)
        {
            var animal = await _animalService.GetById(id);
            if (animal == null)
            {
                return NotFound($"Animal with id {id} not found.");
            }
            return Ok(animal);
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Gets all animals")]
        public async Task<IActionResult> GetAllAnimals()
        {
            var animal = await _animalService.GetAllAsync();
            if (!animal.Any())
            {
                return NotFound("No animals found.");
            }
            return Ok(animal);
        }
    }
}
