using API.Movies.CAPA_DE_ACCESSO_DATOS;
using API.Movies.MOVIESMAPPER;
using API.Movies.RESPOSITORY;
using API.Movies.RESPOSITORY.iREPOSITORY;
using API.Movies.Services;
using API.Movies.Services.IServices;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<ApplicationDbcontext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection")));
builder.Services.AddAutoMapper(cfg=>cfg.AddProfile<Mappers>());

builder.Services.AddScoped<IMOVIEREPOSITORY, MovieRepository>();
builder.Services.AddScoped<IMovieService, MovieService>();
builder.Services.AddScoped<ICategoryservice, CategoryService>();
builder.Services.AddScoped<iCATEGORYREPOSITORY, CategoryRepository>();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
