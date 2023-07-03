using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using FB_Tracker.Client;
using FB_Tracker.Client.Components.Home;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddHttpClient("FB_Tracker.ServerAPI", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress));


// Supply HttpClient instances that include access tokens when making requests to the server project
builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("FB_Tracker.ServerAPI"));
builder.Services.AddTransient<IHomePageService, HomePageService>();

await builder.Build().RunAsync();
