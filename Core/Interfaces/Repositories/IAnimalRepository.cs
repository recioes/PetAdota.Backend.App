using Core.Entities;
using MongoDB.Bson;

namespace Core.Interfaces.Repositories
{
    public interface IAnimalRepository
    {
        Task AddAsync(Animal animal);
        Task UpdateAsync(Animal animal);
        Task DeleteAsync(ObjectId id);
        Task<Animal> GetByIdAsync(ObjectId id);
        Task<IEnumerable<Animal>> GetAsync();
    }
}
