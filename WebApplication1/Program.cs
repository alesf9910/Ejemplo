using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Shared;
using WebApplication1.Data;
using WebApplication1.Middlewares;
using static WebApplication1.ServiceInjectionExtension;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<AdministratorOperationsToBlock>(builder.Configuration.GetSection("AdministratorOperationsToBlock"));

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDb>(
    options => options.UseSqlite(builder.Configuration.GetConnectionString("Default")));

builder.Services.AddIdentityApiEndpoints<User>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<AppDb>();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.ExpireTimeSpan = TimeSpan.FromMinutes(20);
        options.SlidingExpiration = true;
        options.AccessDeniedPath = "/Forbidden/";
    });

builder.Services.AddRazorPages();

builder.Services.AddServiceInjection();

builder.Services.AddCoreAdmin("Admin");

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<RedireccionMiddleware>();

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.MapIdentityApi<User>();

app.MapRazorPages();

app.MapDefaultControllerRoute();

app.UseCookiePolicy();

app.Run();
