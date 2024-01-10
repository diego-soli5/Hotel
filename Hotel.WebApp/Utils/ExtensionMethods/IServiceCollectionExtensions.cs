using Hotel.WebApp.Services;
using Hotel.WebApp.Services.Abstractions;
using Hotel.WebApp.Utils.ApiRoutes;
using Hotel.WebApp.Utils.Options;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace Hotel.WebApp.Utils.ExtensionMethods
{
    public static class IServiceCollectionExtensions
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IHttpClientService), typeof(HttpClientService));
            services.AddScoped(typeof(IUsuarioService), typeof(UsuarioService));
            services.AddScoped(typeof(ITipoHabitacionService), typeof(TipoHabitacionService));
            services.AddScoped(typeof(IHabitacionService), typeof(HabitacionService));
            services.AddScoped(typeof(IClienteService), typeof(ClienteService));
            services.AddScoped(typeof(IReservacionService), typeof(ReservacionService));
        }

        public static void AddAthentication(this IServiceCollection services)
        {
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                    .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, config =>
                    {
                        config.Cookie.Name = "App.Auth.Hotel";
                        config.LoginPath = "/Acceso/Login";
                        config.AccessDeniedPath = "/Error/Unauthorized";
                        config.ExpireTimeSpan = TimeSpan.FromMinutes(30);
                    });
        }

        public static void AddOptions(this IServiceCollection services, IConfiguration configuration)
        {
            string domain = configuration.GetSection("Options:Api:Domain").Value;

            services.Configure<ApiOptions>(x =>
            {
                x.Domain = domain;
            });
        }

        public static void AddRoutes(this IServiceCollection services)
        {
            services.AddSingleton(typeof(ApiRoutesProvider));
            services.AddSingleton(typeof(UsuarioRoutes));
            services.AddSingleton(typeof(TipoHabitacionRoutes));
            services.AddSingleton(typeof(HabitacionRoutes));
            services.AddSingleton(typeof(ReservacionRoutes));
            services.AddSingleton(typeof(ClienteRoutes));
        }
    }
}
