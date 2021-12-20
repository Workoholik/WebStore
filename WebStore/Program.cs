using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

var configurations = builder.Configuration;
var services = builder.Services;


configurations
    .AddJsonFile("appsettings.Custom.json", true, true)
    .AddCommandLine(args);

services.AddControllersWithViews();


var app = builder.Build();

if (app.Environment.IsDevelopment()) 
{
    app.UseDeveloperExceptionPage();    
}
 

app.UseRouting();

// app.MapGet("/", () => configurations["CustomGreetings"]);
app.MapGet("/throw", () => {
    throw new ApplicationException(configurations.GetSection("Custom")["Exception"]);
});

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
);

// app.MapDefaultControllerRoute();

app.Run();
