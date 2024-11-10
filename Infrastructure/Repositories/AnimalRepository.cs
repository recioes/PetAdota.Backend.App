using Core.Entities;
using Core.Interfaces.Repositories;
using Infrastructure.Factories.Interfaces;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Infrastructure.Repositories
{
    public class AnimalRepository : IAnimalRepository
    {
        private readonly IMongoCollection<Animal> _animals;

        public AnimalRepository(IMongoCollectionFactory<Animal> collectionFactory)
        {
            _animals = collectionFactory.GetCollection();
        }
        public async Task AddAsync(Animal animal)
        {
            await _animals.InsertOneAsync(animal);
        }

        public async Task DeleteAsync(ObjectId id)
        {
            var filter = Builders<Animal>
                .Filter
                .Eq(s => s.Id, id);

            await _animals.DeleteOneAsync(filter);
        }

        public async Task<IEnumerable<Animal>> GetAsync()
        {
            return await _animals.Find(FilterDefinition<Animal>.Empty).ToListAsync();
        }

        public async Task<Animal> GetByIdAsync(ObjectId id)
        {
            var filter = Builders<Animal>.Filter.Eq(s => s.Id, id);
            return await _animals.Find(filter).FirstOrDefaultAsync();
        }

        public async Task UpdateAsync(Animal animal)
        {
            var filter = Builders<Animal>.Filter.Eq(s => s.Id, animal.Id);
            await _animals.ReplaceOneAsync(filter, animal);
        }
    }
}
