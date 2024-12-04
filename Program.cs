using AutoMapper;  // Asegúrate de importar AutoMapper
using TrabajoPracticoFinal.Mapping;  // Importa el espacio de nombres donde está AutoMapperProfile
using TrabajoPracticoFinal.Data;
using TrabajoPracticoFinal.Repositories;
using Microsoft.EntityFrameworkCore; // Asegúrate de importar Microsoft.EntityFrameworkCore

var builder = WebApplication.CreateBuilder(args);

// Configurar servicios
builder.Services.AddControllersWithViews();

// Configurar DbContext para SQLite
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// Registrar el repositorio de Artículo
builder.Services.AddScoped<IArticuloRepository, ArticuloRepository>();

// Configurar AutoMapper (usando el enfoque sin ambigüedad)
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());  // Esto resuelve la ambigüedad

var app = builder.Build();

// Configuración de la aplicación
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

// Cambiar el controlador predeterminado de "Home" a "Articulo"
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Articulo}/{action=Index}/{id?}");

app.Run();
