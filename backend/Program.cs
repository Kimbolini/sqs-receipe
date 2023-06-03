var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContextFactory<MealContext>(opt)

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
