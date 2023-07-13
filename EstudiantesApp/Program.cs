using EstudiantesApp.Dominio.IRepositories;
using EstudiantesApp.Dominio.IServices;
using EstudiantesApp.Persistencia.Context;
using EstudiantesApp.Persistencia.Repositories;
using EstudiantesApp.Servicios.Services;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<AplicationDbContext>
    (option => option.UseSqlServer(builder.Configuration.GetConnectionString("Conexion")));

builder.Services.AddScoped<IEstudianteRepository, EstudiantesRepository>();
builder.Services.AddScoped<IEstudianteServices, EstudianteServices>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
