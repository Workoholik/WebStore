using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

#region Настройка builder
var services = builder.Services;
var configurations = builder.Configuration;


builder.Logging.AddFilter("Microsoft", LogLevel.Warning);

configurations
    .AddJsonFile("appsettings.Custom.json", true, true)
    .AddCommandLine(args); 

services.AddControllersWithViews();
#endregion


// Сборка
var app = builder.Build();


#region Конфигурирование конвеера обработки входящих соединений

// app.Urls.Add("http://+:80");

if (app.Environment.IsDevelopment()) 
{
    app.UseDeveloperExceptionPage();    
} 

app.UseStaticFiles(
/*
    // Загружать любые файлы,в том числе исполняемые    
    new StaticFileOptions {
        ServeUnknownFileTypes = true
    }
*/
);

app.UseRouting();
 
app.MapGet("/throw", () => {
    throw new ApplicationException(configurations.GetSection("Custom")["Exception"]);
});

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
);
#endregion


// Запуск
app.Run();
