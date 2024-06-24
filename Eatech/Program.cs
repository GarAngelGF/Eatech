using Microsoft.EntityFrameworkCore;
using Eatech.Models;
using Microsoft.AspNetCore.Authentication.Cookies;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddHttpContextAccessor();



/*-todo esto es para conecctar a la base de datos. Nota: la parte comentada es para probar de manera locar la base de datos-*/
builder.Services.AddDbContext<ContextoBD>(
    lili =>
    /*-Base de datos Desde Azure-*/
    //lili.UseSqlServer("Server=tcp:eatech.database.windows.net,1433;Initial Catalog=eatech;Persist Security Info=False;User ID=EatechCC;Password=Sopadepapa6IV8$;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;")

    /*-Conexión de base de datos a la computadora de yael-*/
    lili.UseSqlServer("Data Source=YAYO\\SQLEXPRESS;Initial Catalog=Eatech;Integrated Security=True;Encrypt=False;Trust Server Certificate=False")

    /*-Conexion de base de datos desde "."-*/
    //lili.UseSqlServer("Data Source=.;Initial Catalog=eatech;Integrated Security=True")
    );

//cookies para el login 
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(
    lili =>
    {
        lili.LoginPath = "/Aplicacion/Login";
        lili.Cookie.Name = "Eatech";
        lili.ExpireTimeSpan = TimeSpan.FromMinutes(5);
        lili.LogoutPath = "/Aplicacion/Logout";
        lili.AccessDeniedPath = "/Home/AccesoRestringido";
        lili.Cookie.HttpOnly = true;
    }
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Aplicacion}/{action=Index}/{id?}");

app.Run();
