using backend;
using backend.Application;
using backend.Models;
using backend.Presentation.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Net.Http.Headers;
using Microsoft.OpenApi.Models;
using System.Net.Mime;
using System.Reflection;
using Microsoft.EntityFrameworkCore.SqlServer;
using MySqlConnector;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;

#region former startup.ConfigureServices

builder.Services.AddScoped<IMealService, MealService>();

builder.Services.AddControllers(options => {
    options.Filters.Add(new HttpResponseExceptionFilter());
}).ConfigureApiBehaviorOptions(options =>
{
    options.InvalidModelStateResponseFactory = context =>
    {
        var result = new BadRequestObjectResult(context.ModelState);

        // TODO: add `using System.Net.Mime;` to resolve MediaTypeNames
        result.ContentTypes.Add(MediaTypeNames.Application.Json);
        result.ContentTypes.Add(MediaTypeNames.Application.Xml);

        return result;
    };
}); ;

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
builder.Services.AddDbContextPool<DatabaseContext>(
    options => options.UseMySql(mySqlConnectionStr, ServerVersion.AutoDetect(mySqlConnectionStr))
    .EnableDetailedErrors()
);

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


using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<DatabaseContext>();
    dbContext.Database.Migrate();
}

// Enable middleware to serve generated Swagger as a JSON endpoint.
app.UseSwagger();

// Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
// specifying the Swagger JSON endpoint.
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "MealBackendSwaggerEndpoint");
});

//configures the HTTP request pipeline
app.UseHttpsRedirection();
app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

#endregion

//app.MapGet("/", () => "Hello World!");

app.Run();
