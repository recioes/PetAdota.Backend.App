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

        public static Animal Update(this AnimalDto animalDto, Animal animal)
        {
            animal.Name = UpdateIfDifferent(animal.Name, animalDto.Name);
            animal.Type = UpdateIfDifferent(animal.Type, animalDto.Type);
            animal.Age = UpdateIfDifferent(animal.Age, animalDto.Age);
            animal.Breed = UpdateIfDifferent(animal.Breed, animalDto.Breed);
            animal.Status = UpdateIfDifferent(animal.Status, animalDto.Status);
            animal.ImageUrl = UpdateIfDifferent(animal.ImageUrl, animalDto.ImageUrl);
            animal.Description = UpdateIfDifferent(animal.Description, animalDto.Description);

            return animal;
        }

        private static T UpdateIfDifferent<T>(T originalValue, T newValue)
        {
            if (!EqualityComparer<T>.Default.Equals(originalValue, newValue))
            {
                return newValue;
            }
            return originalValue;
        }
    }
}
