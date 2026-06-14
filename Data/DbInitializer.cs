using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using KusinaKanto.Models;

namespace KusinaKanto.Data;

public static class DbInitializer
{
    public static async Task SeedAsync(KusinaKantoDbContext db)
    {
        db.Database.EnsureCreated();


        if (db.MenuCategories.Any() || db.MenuItems.Any())
            return;

        // -----------------------
        // CATEGORIES
        // -----------------------
        var categories = new List<MenuCategory>
        {
            new() { Id = "breads", Name = "Breads", Description = "Freshly baked breads and rolls", DisplayOrder = 1 },
            new() { Id = "cakes", Name = "Cakes", Description = "Delicious Filipino cakes", DisplayOrder = 2 },
            new() { Id = "pastries", Name = "Pastries", Description = "Flaky and sweet pastries", DisplayOrder = 3 },
            new() { Id = "halo-halo", Name = "Halo-Halo", Description = "Sweet Filipino treats", DisplayOrder = 4 },
            new() { Id = "drinks", Name = "Drinks", Description = "Refreshing beverages", DisplayOrder = 5 }
        };

        db.MenuCategories.AddRange(categories);

        // -----------------------
        // MENU ITEMS 
        // -----------------------
        db.MenuItems.AddRange(

            // Breads
            new MenuItem { Id="i1", CategoryId="breads", Name="Cinnamon Roll", Description="Soft, fluffy roll swirled with cinnamon and topped with sweet glaze.", Price=650, ImageUrl=Img("cinnamon-roll.jpg"), IsAvailable=true, IsBestseller=true },
            new MenuItem { Id="i2", CategoryId="breads", Name="Pandesal", Description="Classic Filipino bread roll with a light, soft texture and golden crust.", Price=500, ImageUrl=Img("pandesal.jpg"), IsAvailable=true, IsBestseller=true },
            new MenuItem { Id="i3", CategoryId="breads", Name="Spanish Bread", Description="Soft bread filled with a sweet buttery breadcrumb filling.", Price=600, ImageUrl=Img("spanish-bread.jpg"), IsAvailable=true },

            // Cakes
            new MenuItem { Id="i4", CategoryId="cakes", Name="Cassava Cake", Description="Rich and creamy baked cassava topped with a sweet coconut custard.", Price=650, ImageUrl=Img("cassava-cake.jpg"), IsAvailable=true, IsBestseller=true },
            new MenuItem { Id="i5", CategoryId="cakes", Name="Yema Cake", Description="Soft chiffon cake layered and topped with creamy yema frosting.", Price=500, ImageUrl=Img("yema-cake.jpg"), IsAvailable=true, IsBestseller=true },
            new MenuItem { Id="i6", CategoryId="cakes", Name="Choco Moist Cake", Description="Rich and moist chocolate cake with a decadent chocolate ganache.", Price=600, ImageUrl=Img("choco-moist-cake.jpg"), IsAvailable=true },

            // Halo-Halo
            new MenuItem { Id="i7", CategoryId="halo-halo", Name="Classic Ube", Description="Refreshing halo-halo with creamy ube, milk, and assorted sweet toppings.", Price=650, ImageUrl=Img("halo-halo.png"), IsAvailable=true, IsBestseller=true },
            
            new MenuItem { Id="i8", CategoryId="halo-halo", Name="Mango Overload", Description="A refreshing mango treat packed with fresh mangoes and creamy goodness.", Price=500, ImageUrl=Img("mango-overload.jpg"), IsAvailable=true },
            

            // Drinks
            new MenuItem { Id="i9", CategoryId="drinks", Name="Calamansi Juice", Description="Fresh citrus juice.", Price=450, ImageUrl=Img("calamansi-juice.jpg"), IsAvailable=true },
            new MenuItem { Id="i10", CategoryId="drinks", Name="Sago't Gulaman", Description="Sweet drink with tapioca and jelly.", Price=550, ImageUrl=Img("sagotgulaman.webp"), IsAvailable=true, IsBestseller=true },
            new MenuItem { Id="i11", CategoryId="drinks", Name="Buko Juice", Description="Fresh coconut water.", Price=500, ImageUrl=Img("buko-juice.jpg"), IsAvailable=true },
            new MenuItem { Id="i12", CategoryId="drinks", Name="Iced Coffee", Description="Filipino-style iced coffee with milk.", Price=300, ImageUrl=Img("iced-coffee.jpg"), IsAvailable=true }
        );

        await db.SaveChangesAsync();
        Console.WriteLine($"Categories: {db.MenuCategories.Count()}");
        Console.WriteLine($"Items: {db.MenuItems.Count()}");
    }

   private static string Img(string fileName)
    => $"/images/menu/{fileName}";
}