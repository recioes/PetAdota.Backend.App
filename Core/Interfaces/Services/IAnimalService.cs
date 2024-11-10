using Core.DTOs;
using Core.Entities;
using MongoDB.Bson;

namespace Core.Interfaces.Services
{
    public interface IAnimalService
    {
        Task CreateAsync(AnimalDto animalDto);
        Task UpdateAsync(ObjectId id, AnimalDto animalDto);
        Task DeleteAsync(ObjectId id);
        Task<Animal> GetById(ObjectId id);
        Task<IEnumerable<Animal>> GetAllAsync();
    }
}
