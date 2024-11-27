using Herramientas_Pro.Models;
using Herramientas_Pro.Services;
using Herramientas_Pro.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.UI.Services;
using Herramientas_Pro.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Configuración para enviar logs a la depuración y consola
builder.Logging.ClearProviders(); // Limpia configuraciones previas
builder.Logging.AddConsole(); // Muestra logs en la consola
builder.Logging.AddDebug();   // Muestra logs en la ventana de depuración (Visual Studio)

builder.Services.AddScoped<ProductosService>(); // Registra el servicio como Scoped
builder.Services.AddScoped<FabricacionsService>(); // Registra el servicio como Scoped
builder.Services.AddScoped<InventarioService>(); // Registra el servicio como Scoped
builder.Services.AddScoped<Entradas_SalidasService>(); // Registra el servicio como Scoped

builder.Services.AddTransient<IEmailSender, EmailSender>();



// Agrega esta línea para configurar el servicio de DbContext con SQL Server
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders(); // Esto es opcional si usas tokens de restablecimiento de contraseña

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

using (var scope = app.Services.CreateScope())
{
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    await StartupRoles.SeedRolesAsync(roleManager);
}


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication(); // Necesario para manejar autenticación
app.UseAuthorization();  // Necesario para manejar autorización

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
    name: "excels",
    pattern: "excels/{action=Index}/{id?}",
    defaults: new { controller = "Excels" }
);


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
);

app.Run();
