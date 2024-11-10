namespace Infrastructure.Providers.Interfaces
{
    public interface IEnvironmentVariablesProvider
    {
         string MongoDb__ConnectionString { get; }
         string Mongo_Animal_Db { get; }
         string Mongo_Animal_Collection { get; }
    }
}
