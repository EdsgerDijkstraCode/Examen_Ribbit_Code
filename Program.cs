using Examen_Ribbit.Datos;
using Microsoft.EntityFrameworkCore;
using Examen_Ribbit.Repositorios;
using Examen_Ribbit.Servicios;




var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();







builder.Services.AddScoped<IProductoRepositorio, ProductoRepositorio>();
builder.Services.AddScoped<IProductoServicio, ProductoServicio>();

builder.Services.AddControllers();
builder.Services.AddSwaggerGen(c => { c.EnableAnnotations(); });


var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "API Productos Version 1.0"));
}

app.UseRouting(); 
app.UseEndpoints(endpoints => { endpoints.MapControllers(); });

var scope = app.Services.CreateScope();



app.UseHttpsRedirection();

app.MapControllers();

app.Run();
var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
DataSeeder.SeedData(context);
