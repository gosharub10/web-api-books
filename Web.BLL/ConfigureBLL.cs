using Microsoft.Extensions.DependencyInjection;
using Web.BLL.Interfaces;
using Web.BLL.Mapping;
using Web.BLL.Services;
using Web.DAL;

namespace Web.BLL;

public static class ConfigureBLL
{
    public static void AddBLL(this IServiceCollection services)
    {
        services.AddDAL();

        services.AddAutoMapper(
            typeof(AuthorConfigMapper),
            typeof(BookConfigMapper)
        );

        services.AddTransient<IAuthorService, AuthorService>();
        services.AddTransient<IBookService, BookService>();
    }
}