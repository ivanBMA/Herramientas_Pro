using Herramientas_Pro.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Agrega esta línea para configurar el servicio de DbContext con SQL Server
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}



app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "productos",
    pattern: "productos/{action=Index}/{id?}",
    defaults: new { controller = "Productos" }
);

app.MapControllerRoute(
    name: "pedidos",
    pattern: "pedidos/{action=Index}/{id?}",
    defaults: new { controller = "Pedidos" }
);

app.MapControllerRoute(
    name: "inventario",
    pattern: "inventario/{action=Index}/{id?}",
    defaults: new { controller = "Inventarios" }
);

app.MapControllerRoute(
    name: "fabricacions",
    pattern: "fabricacions/{action=Index}/{id?}",
    defaults: new { controller = "Fabricacions" }
);

app.MapControllerRoute(
    name: "entradas_Salidas",
    pattern: "entradas_Salidas/{action=Index}/{id?}",
    defaults: new { controller = "Entradas_Salidas" }
);
app.MapControllerRoute(
    name: "arreglos",
    pattern: "arreglos/{action=Index}/{id?}",
    defaults: new { controller = "Arreglos" }
);


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
);

app.Run();
