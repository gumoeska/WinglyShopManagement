using WinglyShopAdmin.App.Helpers;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using WinglyShopAdmin.App.Abstractions.Services;
using WinglyShopAdmin.App.Abstractions.Services.Shop;
using WinglyShopAdmin.App.Services.Shop;
using WinglyShopAdmin.App.Services.Common;
using WinglyShopAdmin.App.Services.Users;
using WinglyShopAdmin.App.Services.Auth;
using WinglyShopAdmin.App.Abstractions.Services.Profile;
using WinglyShopAdmin.App.Services.Profile;

namespace WinglyShopAdmin.App
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            builder.Services
                .AddScoped<IAuthenticationService, AuthenticationService>()
                .AddScoped<IUserService, UserService>()
                .AddScoped<IHttpService, HttpService>()
                .AddScoped<ILocalStorageService, LocalStorageService>()
                .AddScoped<IProductService, ProductService>()
                .AddScoped<ICategoryService, CategoryService>()
                .AddScoped<IProfileService, ProfileService>();

            // configure http client
            builder.Services.AddScoped(x => {
                var apiUrl = new Uri(builder.Configuration["apiUrl"]);

                return new HttpClient() { BaseAddress = apiUrl };
            });

            // MudBlazor
            builder.Services.AddMudServices();

            var host = builder.Build();

            var authenticationService = host.Services.GetRequiredService<IAuthenticationService>();
            await authenticationService.Initialize();

            await host.RunAsync();
        }
    }
}
