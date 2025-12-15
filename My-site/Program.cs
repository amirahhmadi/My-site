using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using My_site.Core.Services.AboutServices.Commands;
using My_site.Core.Services.AboutServices.Queries;
using My_site.Core.Services.PortfolioServices.Commands;
using My_site.Core.Services.PortfolioServices.Queries;
using My_site.Core.Services.UserService.Commands;
using My_site.Core.Services.UserService.Queries;
using My_site.DataBase.Context;
using My_site.DataBase.Entities.Users;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<My_SiteContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddTransient<IUserServiceCommand, UserServiceCommand>();
builder.Services.AddTransient<IUserServiceQuery, UserServiceQuery>(); 
builder.Services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();
builder.Services.AddTransient<IAboutServicesQuery, AboutServicesQuery>();
builder.Services.AddTransient<IAboutServicesCommand, AboutServicesCommand>();
builder.Services.AddTransient<IPortfolioServiceCommand, PortfolioServiceCommand>();
builder.Services.AddTransient<IPortfolioServiceQuery, PortfolioServiceQuery>();

builder.Services.AddAuthentication("CookieAuth")
    .AddCookie("CookieAuth", options =>
    {
        options.LoginPath = "/Login";   // مسیر صفحه لاگین
        options.AccessDeniedPath = "/Account/AccessDenied";
    });

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
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "area",
    pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
