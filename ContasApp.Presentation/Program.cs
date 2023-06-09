using ContasApp.Presentation.Filters;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//habilitar o projeto para utilizar Cookies
builder.Services.Configure<CookiePolicyOptions>(options => {
    options.MinimumSameSitePolicy = SameSiteMode.None;
});

//definir o tipo de autenticação do projeto
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseMiddleware<CacheFilter>();

app.UseCookiePolicy(); //cookie
app.UseAuthentication(); //cookie

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}/{id?}");

app.Run();



