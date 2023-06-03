using backend;
using backend.Application;
using backend.Models;
using backend.Presentation.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Net.Http.Headers;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
var startup = new Startup(builder.Configuration);
var config = builder.Configuration;

//startup.ConfigureServices(builder.Services); //replaced with 

#region former startup.ConfigureServices

//builder.Services.AddScoped<IMealService, MealService>();

// Add Cors-Policy to avoid issues with security protocols of the browser
builder.Services.AddCors(options => {
    options.AddPolicy(name: "http://localhost:4200",
        builder => {
            builder.WithOrigins("http://localhost:4200")
                    .WithHeaders(HeaderNames.ContentType, "application/json")
                    .AllowAnyMethod()
                    .AllowAnyHeader();
        });
});

// Add Cors-Policy to avoid issues with security protocols of the browser
builder.Services.AddCors(options => {
    options.AddPolicy(name: "http://localhost:80",
        builder => {
            builder.WithOrigins("http://localhost:80")
                    .WithHeaders(HeaderNames.ContentType, "application/json")
                    .AllowAnyMethod()
                    .AllowAnyHeader();
        });
});

var mySqlConnectionStr = config.GetConnectionString("DefaultConnection");
//builder.Services.AddDbContextPool<DatabaseContext>(options => options.UseMySql(mySqlConnectionStr, ServerVersion.AutoDetect(mySqlConnectionStr)));

//needed from swashbuckle swagger
builder.Services.AddMvcCore().AddApiExplorer();

builder.Services.AddSwaggerGen(
    c =>
    {
        //Generate the UI of the Swagger Documentation
        c.SwaggerDoc("v1", new OpenApiInfo
        {
            Version = "v1",
            Title = "meal - backend",
            Description = "This is the backend of the sqs project"
        });

        // Set the comments path for the Swagger JSON and UI.
        var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
        var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
        if (File.Exists(xmlPath))
            c.IncludeXmlComments(xmlPath);
    }
);

builder.Services.TryAddSingleton<HttpContextAccessor, HttpContextAccessor>();

#endregion

var app = builder.Build();

#region former startup.Configure

/*
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<DatabaseContext>();
    dbContext.Database.Migrate();
}*/

// Enable middleware to serve generated Swagger as a JSON endpoint.
app.UseSwagger();

// Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
// specifying the Swagger JSON endpoint.
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    options.RoutePrefix = string.Empty;
});

app.UseHttpsRedirection();

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

#endregion

//app.MapGet("/", () => "Hello World!");

app.Run();
