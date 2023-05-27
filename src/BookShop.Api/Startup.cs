using BookShop.Api.Bootstrapping;

namespace BookShop.Api
{
    public static class Startup
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuth(configuration);

            services.AddSingleton<IBooksStore, BooksStore>();

            return services;
        }
    }
}
