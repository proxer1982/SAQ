using SAQ.Api.Extensions;
using SAQ.Application.Extensions;
using SAQ.Application.Interfaces;
using SAQ.Infrastructure.Extensions;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;
//builder.Services.AddDbContext<SAQContext>(options => options.UseInMemoryDatabase("TareasDB"));
// Add services to the container.

builder.Services.AddControllers();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
var Cors = "Cors";
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: Cors,
        builder =>
        {
            builder.WithOrigins("*");
            builder.AllowAnyMethod();
            builder.AllowAnyHeader();
        });
});

builder.Services.AddInjectionInfrastructure(config);
builder.Services.AddInjectionApplication(config);
builder.Services.AddAuthentication(config);
builder.Services.AddSwagger();

var app = builder.Build();

app.UseCors(Cors);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();
app.MapGet("/dbconexion", async (IDbApplication dbApplication) =>
{
    var result = dbApplication.CreatedDB();

    return Results.Ok("Baase de datos en memoria: " + result);
});

app.Run();

public partial class Program { }
