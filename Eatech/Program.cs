using Microsoft.EntityFrameworkCore;
using Eatech.Models;
using Microsoft.AspNetCore.Authentication.Cookies;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ContextoBD>(
    lili => lili.UseSqlServer("Server=tcp:eatechpabd.database.windows.net,1433;Initial Catalog=BDEatechPA;Persist Security Info=False;User ID=SopadepapaLiliSimp;Password=312206Sopadepapa$;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"));


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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
