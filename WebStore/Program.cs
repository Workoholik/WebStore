var builder = WebApplication.CreateBuilder(args);

var configurations = builder.Configuration;
var services = builder.Services;


configurations.AddJsonFile("appsettings.Custom.json", true, true);
configurations.AddCommandLine(args);

services.AddControllersWithViews();


var app = builder.Build();

if (app.Environment.IsDevelopment()) 
{
    app.UseDeveloperExceptionPage();    
}


app.UseRouting();

// app.MapGet("/", () => configurations["CustomGreetings"]);
app.MapGet("/throw", () => {
    throw new ApplicationException(configurations["CustomException"]);
});

app.MapDefaultControllerRoute();

app.Run();
