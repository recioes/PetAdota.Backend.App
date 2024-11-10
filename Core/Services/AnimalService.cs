using Core.DTOs;
using Core.Entities;
using Core.Extensions;
using Core.Interfaces.Repositories;
using Core.Interfaces.Services;
using FluentValidation;
using Microsoft.Extensions.Logging;
using MongoDB.Bson;

namespace Core.Services
{
    public class AnimalService : IAnimalService
    {
        private readonly IAnimalRepository _animalRepository;
        private readonly IValidator<Animal> _animalValidator;
        private readonly ILogger<AnimalService> _logger;

        public AnimalService(IAnimalRepository animalRepository, IValidator<Animal> animalValidator, ILogger<AnimalService> logger)
        {
            _animalRepository = animalRepository;
            _animalValidator = animalValidator;
            _logger = logger;
        }

        public async Task CreateAsync(AnimalDto animalDto)
        {
            var mappedAnimal = animalDto.Create();

            var validationResult = await _animalValidator.ValidateAsync(mappedAnimal);

            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            await _animalRepository.AddAsync(mappedAnimal);
            _logger.LogInformation("animal data named {Name} succesfully created.", animalDto.Name);
        }

        public async Task DeleteAsync(ObjectId id)
        {
            var animal = await _animalRepository.GetByIdAsync(id);

            if (animal == null)
            {
                throw new InvalidOperationException("Animal not found.");
            }

            await _animalRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<Animal>> GetAllAsync()
        {
            var existingAnimals = await _animalRepository.GetAsync();
            if (existingAnimals == null)
            {
                throw new InvalidOperationException("there are no animals created");
            }

            return existingAnimals;
        }

        public async Task<Animal> GetById(ObjectId id)
        {
            var animal = await _animalRepository.GetByIdAsync(id);

            if (animal == null)
            {
                throw new InvalidOperationException($"animal with id{id} not found");
            }

            return animal;
        }


        public async Task UpdateAsync(ObjectId id, AnimalDto animalDto)
        {
            var animal = await _animalRepository.GetByIdAsync(id);
            if (animal == null)
            {
                throw new InvalidOperationException("Animal not found.");
            }

            var mappedAnimal = animalDto.Create();

            var validationResult = await _animalValidator.ValidateAsync(animal);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            await _animalRepository.UpdateAsync(animal);
        }
    }
}
