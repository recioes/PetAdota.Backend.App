using Core.Interfaces.Services;
using Core.Services;
using Core.Validators;
using FluentValidation;

namespace Api.Extensions
{
    public static class CoreExtensions
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services)
        {
            return services
           .AddServices()
           .AddValidators();
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            return services.AddScoped<IAnimalService, AnimalService>();
        }

        public static IServiceCollection AddValidators(this IServiceCollection services)
        {
            return services.AddValidatorsFromAssemblyContaining<AnimalValidator>();
        }
    }
}
