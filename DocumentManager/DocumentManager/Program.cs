using DocumentManager.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new()
    {
        Title = "Document Manager API",
        Version = "v1",
        Description = "API for managing documents with filtering and security"
    });
});

builder.Services.AddDbContext<AppDbContext>(opt =>
    opt.UseInMemoryDatabase("DocumentDb"));

var app = builder.Build();

app.UseStaticFiles();
app.UseHttpsRedirection();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Document Manager API v1");
    c.RoutePrefix = "swagger";
});

app.MapControllers();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=DocumentList}/{action=Index}/{id?}");

app.Run();
