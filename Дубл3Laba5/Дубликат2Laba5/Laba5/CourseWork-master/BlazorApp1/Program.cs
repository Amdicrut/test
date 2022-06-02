using BlazorApp1;
using BlazorApp1.Data.Services;
//using BlazorApp1.Sevices;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddScoped<ICustomerProvider, CustomersProvider>();
builder.Services.AddScoped<ICargoProvider, CargosProvider>();
builder.Services.AddScoped<ITransportProvider, TransportsProvider>();

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:44317") });

//builder.Services.AddScoped<ICargoProvider, CargoProvider>();

await builder.Build().RunAsync();
