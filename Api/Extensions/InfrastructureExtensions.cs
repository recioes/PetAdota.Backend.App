﻿using Infrastructure.Factories.Interfaces;
using Infrastructure.Factories;
using Infrastructure.Providers.Interfaces;
using Infrastructure.Providers;
using MongoDB.Driver;
using Core.Interfaces.Repositories;
using Infrastructure.Repositories;

namespace Api.Extensions
{
    public static class InfrastructureExtensions
    {
        public static IServiceCollection ConfigureInfrastructure(this IServiceCollection services)
        {
            return services
                .AddProviders()
                .AddRepositories()
                .AddDatabases()
                .AddFactories();
        }

        public static IServiceCollection AddProviders(this IServiceCollection services)
        {
            return services.AddSingleton<IEnvironmentVariablesProvider, EnvironmentVariablesProvider>();
        }

        public static IServiceCollection AddFactories(this IServiceCollection services)
        {
            return services.AddSingleton(typeof(IMongoCollectionFactory<>), typeof(MongoCollectionFactory<>));
        }


        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            return services.AddScoped<IAnimalRepository, AnimalRepository>();
        }

        public static IServiceCollection AddDatabases(this IServiceCollection services)
        {
            return services.AddSingleton<IMongoClient>(sp =>
            {
                var envProvider = sp.GetRequiredService<IEnvironmentVariablesProvider>();
                return new MongoClient(envProvider.MongoDb__ConnectionString);
            });
        }

    }
}
