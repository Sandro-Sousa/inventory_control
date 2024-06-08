using Microsoft.EntityFrameworkCore;
using Repository;
using Repository.Interfaces;
using Repository.Repositories;
using Service.Services;

namespace inventory_control_ZDZCode.WebAPI.Extensions
{
    public static class DependencyContainer
    {
        public static void ContainerInjection(this WebApplicationBuilder builder)
        {

            builder.Services.AddDbContextPool<Context>(options =>
                    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            // Services
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IProductService, ProductService>();

            // Repositories
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IProductRepository, ProductRepository>();
        }
    }
}
