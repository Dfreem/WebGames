
using Microsoft.Extensions.DependencyInjection;

using WebGames.Shared.Components.Menu;
using WebGames.Shared.Components.Toast;

namespace WebGames.Shared.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection RegisterCommonServices(this IServiceCollection services)
    {
        services.AddScoped<IToastService, ToastService>();
        services.AddTransient<MenuJSInteropt>();
        return services;
    }
}
