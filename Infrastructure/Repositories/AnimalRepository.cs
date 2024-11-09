using Core.Entities;
using Core.Interfaces.Repositories;
using Infrastructure.Factories.Interfaces;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Infrastructure.Repositories
{
    public class AnimalRepository : IAnimalRepository
    {
        private readonly IMongoCollection<Animal> _schedules;

        public AnimalRepository(IMongoCollectionFactory<Animal> collectionFactory)
        {
            _schedules = collectionFactory.GetCollection();
        }
        public async Task AddAsync(Animal schedule)
        {
            await _schedules.InsertOneAsync(schedule);
        }

        public async Task DeleteAsync(ObjectId id)
        {
            var filter = Builders<Animal>
                .Filter
                .Eq(s => s.Id, id);

            await _schedules.DeleteOneAsync(filter);
        }

        public async Task<IEnumerable<Animal>> GetAsync()
        {
            return await _schedules.Find(FilterDefinition<Animal>.Empty).ToListAsync();
        }

        public async Task<Animal> GetByIdAsync(ObjectId id)
        {
            var filter = Builders<Animal>.Filter.Eq(s => s.Id, id);
            return await _schedules.Find(filter).FirstOrDefaultAsync();
        }

        public async Task UpdateAsync(Animal schedule)
        {
            var filter = Builders<Animal>.Filter.Eq(s => s.Id, schedule.Id);
            await _schedules.ReplaceOneAsync(filter, schedule);
        }
    }
}
