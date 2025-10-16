using Microsoft.Extensions.DependencyInjection;
using Web.DAL.Interfaces;
using Web.DAL.Repositories;

namespace Web.DAL;

public static class ConfigureDAL
{
    public static void AddDAL(this IServiceCollection services)
    {
        services.AddScoped<IBookRepository, BookRepository>();
        services.AddScoped<IAuthorRepository, IAuthorRepository>();
    }
}
