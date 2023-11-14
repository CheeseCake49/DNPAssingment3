using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Blazor;
using Blazor.Auth;
using Blazor.Services.Http;
using HttpClients.ClientInterfaces;
using HttpClients.ClientInterfaces.Implementations;
using Microsoft.AspNetCore.Components.Authorization;
using Shared.Auth;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddScoped<IUserService, UserHttpClient>();
builder.Services.AddScoped<IPostService, PostHttpClient>();
builder.Services.AddScoped<IAuthService, JwtAuthService>();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthProvider>();
AuthorizationPolicies.AddPolicies(builder.Services);


builder.Services.AddScoped(
    sp => 
        new HttpClient { 
            BaseAddress = new Uri("https://localhost:5029") 
        }
);

await builder.Build().RunAsync();