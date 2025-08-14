using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using ThisNotesForYou.Blazor.Services;
using ThisNotesForYou.Blazor;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");

// Dit dient overeen te komen met het hosting adres van de backend
const string ApiBase = "http://localhost:5088";

builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = new Uri(ApiBase)
});

builder.Services.AddScoped<NotesClient>();

await builder.Build().RunAsync();