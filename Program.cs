
// using KusinaKanto.Components;
// using KusinaKanto.Services;
// using KusinaKanto.Models;
// using Microsoft.AspNetCore.Identity;
// using Microsoft.EntityFrameworkCore;
// using KusinaKanto.Data;

// var builder = WebApplication.CreateBuilder(args);

// builder.Services.AddRazorComponents()
//     .AddInteractiveServerComponents();

// builder.Services.AddHttpContextAccessor();

// var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
//     ?? "Data Source=KusinaKanto.db";

// builder.Services.AddDbContext<KusinaKantoDbContext>(options =>
//     options.UseSqlite(connectionString));

// builder.Services.AddScoped<IMenuService, EfMenuService>();
// builder.Services.AddScoped<IOrderService, EfOrderService>();
// builder.Services.AddScoped<CartState>();

// var app = builder.Build();

// // Seed DB safely
// using (var scope = app.Services.CreateScope())
// {
//     var db = scope.ServiceProvider.GetRequiredService<KusinaKantoDbContext>();
//     await DbInitializer.SeedAsync(db);
// }

// if (!app.Environment.IsDevelopment())
// {
//     app.UseExceptionHandler("/Error", createScopeForErrors: true);
//     app.UseHsts();
// }

// app.UseStaticFiles();
// app.UseHttpsRedirection(); // ✅ put back

// app.UseAntiforgery();

// app.MapStaticAssets();
// app.MapRazorComponents<App>()
//     .AddInteractiveServerRenderMode();

// app.Run();
using System.Security.Claims;
using KusinaKanto.Components;
using KusinaKanto.Services;
using KusinaKanto.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using KusinaKanto.Data;

var builder = WebApplication.CreateBuilder(args);

#region Blazor
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddHttpContextAccessor();
#endregion


#region Database
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
    ?? "Data Source=KusinaKanto.db";

builder.Services.AddDbContext<KusinaKantoDbContext>(options =>
    options.UseSqlite(connectionString));
#endregion

#region Application Services
builder.Services.AddScoped<IMenuService, EfMenuService>();
builder.Services.AddScoped<IOrderService, EfOrderService>();
builder.Services.AddScoped<CartState>();
#endregion

var app = builder.Build();

#region Database Seed
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<KusinaKantoDbContext>();

    await DbInitializer.SeedAsync(db);
}
#endregion

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