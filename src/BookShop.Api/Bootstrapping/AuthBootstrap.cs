using BookShop.Api.Settings;

namespace BookShop.Api.Bootstrapping
{
    public static class AuthBootstrap
    {
        public static IServiceCollection AddAuth(this IServiceCollection services, IConfiguration configuration)
        {
            var authenticationSettingsSection = configuration.GetSection(AuthenticationSettings.SectionName);

            services.Configure<AuthenticationSettings>(authenticationSettingsSection);
            var authenticationSettings = authenticationSettingsSection.Get<AuthenticationSettings>();

            services.AddAuthentication("Bearer")
                .AddIdentityServerAuthentication("Bearer", options =>
                {
                    options.ApiName = authenticationSettings.ApiName;
                    options.Authority = authenticationSettings.Authority;
                });


            return services;
        }
    }
}
