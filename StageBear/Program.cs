using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using StageBear.Data;


var builder = WebApplication.CreateBuilder(args);
string username = builder.Configuration["username"];
string password = builder.Configuration["password"];

builder.Services.AddDbContext<StageBearContext>(
    options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("StageBearContext") ?? throw new InvalidOperationException("Connection string 'StageBearContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();

// add cookie authentication
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.ExpireTimeSpan = TimeSpan.FromMinutes(30); //if the page is inactive after 30 minutes, page will be logged out
        options.SlidingExpiration = true; // Reset the expiration time if the user is active
        options.LoginPath = "/Account/Login";
        options.LogoutPath = "/Account/Logout";
        options.AccessDeniedPath = "/Account/AccessDenied";
    });



var app = builder.Build();

if (builder.Environment.IsDevelopment())
{
    builder.Configuration.AddUserSecrets<Program>();
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthentication(); //THIS HAS TO GO ABOVE AUTHORIZATION!! THE ORDER MATTERS!!

app.UseAuthorization();


app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
