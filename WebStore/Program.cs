var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// Подтянем данные из конфига
app.MapGet("/", () => app.Configuration["CustomGreetings"]);

app.Run();
