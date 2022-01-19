using Microsoft.Extensions.Configuration;
using WebStore.Infrastructure.Conventions;
using WebStore.Infrastructure.Middleware;

using WebStore.Services;
using WebStore.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

#region Настройка builder
var services = builder.Services;
var configurations = builder.Configuration;


builder.Logging.AddFilter("Microsoft", LogLevel.Warning);

configurations
    .AddJsonFile("appsettings.Custom.json", true, true)
    .AddCommandLine(args); 


services.AddControllersWithViews(opt => {
    opt.Conventions.Add(new TestConvention());
});

services.AddSingleton<IEmployeesData, InMemoryEmployeesData>();
services.AddSingleton<IDepartmentsData, InMemoryDepartmentsData>();

services.AddSingleton<IProductData, InMemoryProductData>();

//services.AddMvc();
//services.AddControllers();  //For WebAPI

#endregion

// Сборка
var app = builder.Build();

#region Конфигурирование конвеера обработки входящих соединений

// app.Urls.Add("http://+:80");

if (app.Environment.IsDevelopment()) 
{
    app.UseDeveloperExceptionPage();    
}

// простое промежуточное ПО
app.Map("/testpath", async context => await context.Response.WriteAsync("Test Middleware"));

app.UseStaticFiles(
/*
    // Загружать любые файлы,в том числе исполняемые    
    new StaticFileOptions {
        ServeUnknownFileTypes = true
    }
*/
);

app.UseRouting();

app.UseMiddleware<TestMiddleware>();

 
app.MapGet("/throw", () => {
    throw new ApplicationException(configurations.GetSection("Custom")["Exception"]);
});

app.UseWelcomePage("/welcom");


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
);
#endregion

// Запуск
app.Run();
