using Infrastructure.Providers.Interfaces;

namespace Infrastructure.Providers
{
    public class EnvironmentVariablesProvider : IEnvironmentVariablesProvider
    {
        public string MongoDb__ConnectionString { get; }
        public string Mongo_Animal_Db { get; }
        public string Mongo_Animal_Collection { get; }

        public EnvironmentVariablesProvider()
        {
            MongoDb__ConnectionString = GetRequiredStringVariable(VariableKeys.MONGO_DB_CONNECTION_STRING);
            Mongo_Animal_Db = GetRequiredStringVariable(VariableKeys.MONGO_ANIMAL_DB);
            Mongo_Animal_Collection = GetRequiredStringVariable(VariableKeys.MONGO_ANIMAL_COLLECTION_NAME);
        }

        public static string GetRequiredStringVariable(string environmentVariable)
        {
            return Environment.GetEnvironmentVariable(environmentVariable)
                ?? throw new InvalidOperationException($"Environment variable '{environmentVariable}' is not set.");
        }
    }
}
