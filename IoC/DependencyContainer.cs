using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Repository.EFCore;
using Repository.EFCore.Repositories;

namespace IoC
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(
                opt => opt.UseSqlServer(configuration.GetConnectionString("RepositoryDB")));

            services.AddTransient<ProductRepository>();
            services.AddTransient<CategoryRepository>();

            return services;
        }
    }
}
