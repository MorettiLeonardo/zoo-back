using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Zoo.Application.Handlers.Animal;
using Zoo.Application.Handlers.Cuidado;
using Zoo.Data.Repositories;
using Zoo.Domain.Contexts.Interfaces;

namespace Zoo.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            //DbContext
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            //Repositórios
            services.AddScoped<IAnimalRepository, AnimalRepository>();
            services.AddScoped<ICuidadoRepository, CuidadoRepository>();

            //Handlers
            services.AddScoped<AnimalHandler>();
            services.AddScoped<CuidadoHandler>();

            return services;
        }
    }
}