using System.Security.Claims;
using KusinaKanto.Components;
using KusinaKanto.Services;
using KusinaKanto.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using KusinaKanto.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddHttpContextAccessor();


//datase setup
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
    ?? "Data Source=KusinaKanto.db";

builder.Services.AddDbContext<KusinaKantoDbContext>(options =>
    options.UseSqlite(connectionString));

//Application services
builder.Services.AddScoped<IMenuService, EfMenuService>();
builder.Services.AddScoped<IOrderService, EfOrderService>();
builder.Services.AddScoped<CartState>();


var app = builder.Build();

// Seed the database with initial data if it's empty
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<KusinaKantoDbContext>();

    await DbInitializer.SeedAsync(db);
}

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseStaticFiles();
app.UseHttpsRedirection();
app.UseAntiforgery();

app.MapStaticAssets();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();