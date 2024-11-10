using Core.DTOs;
using Core.Entities;

namespace Core.Extensions
{
    public static class AnimalMappingExtensions
    {
        public static Animal Create(this AnimalDto animalDto)
        {
            return new Animal
            {
                Name = animalDto.Name,
                Type = animalDto.Type,
                Age = animalDto.Age,
                Breed = animalDto.Breed,
                Status = animalDto.Status,
                ImageUrl = animalDto.ImageUrl,
                Description = animalDto.Description
            };
        }
    }
}
