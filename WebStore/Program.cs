using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;
var configurations = builder.Configuration;


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
 
app.MapGet("/throw", () => {
    throw new ApplicationException(configurations.GetSection("Custom")["Exception"]);
});

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
);

// app.MapDefaultControllerRoute();

app.Run();
