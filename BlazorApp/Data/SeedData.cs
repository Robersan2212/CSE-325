using BlazorApp.Models;

namespace BlazorApp.Data;

public static class SeedData
{
    public static void Initialize(PizzaStoreContext db)
    {
        // Use placeholder images (picsum.photos) - no local files needed
        var specials = new PizzaSpecial[]
        {
            new PizzaSpecial
            {
                Name = "Basic Cheese Pizza",
                Description = "It's cheesy and delicious. Why wouldn't you want one?",
                BasePrice = 9.99m,
                ImageUrl = "https://picsum.photos/seed/cheese/400/300",
            },
            new PizzaSpecial
            {
                Id = 2,
                Name = "The Baconatorizor",
                Description = "It has EVERY kind of bacon",
                BasePrice = 11.99m,
                ImageUrl = "https://picsum.photos/seed/bacon/400/300",
            },
            new PizzaSpecial
            {
                Id = 3,
                Name = "Classic pepperoni",
                Description = "It's the pizza you grew up with, but Blazing hot!",
                BasePrice = 10.50m,
                ImageUrl = "https://picsum.photos/seed/pepperoni/400/300",
            },
            new PizzaSpecial
            {
                Id = 4,
                Name = "Buffalo chicken",
                Description = "Spicy chicken, hot sauce and bleu cheese, guaranteed to warm you up",
                BasePrice = 12.75m,
                ImageUrl = "https://picsum.photos/seed/meaty/400/300",
            },
            new PizzaSpecial
            {
                Id = 5,
                Name = "Mushroom Lovers",
                Description = "It has mushrooms. Isn't that obvious?",
                BasePrice = 11.00m,
                ImageUrl = "https://picsum.photos/seed/mushroom/400/300",
            },
            new PizzaSpecial
            {
                Id = 7,
                Name = "Veggie Delight",
                Description = "It's like salad, but on a pizza",
                BasePrice = 11.50m,
                ImageUrl = "https://picsum.photos/seed/salad/400/300",
            },
            new PizzaSpecial
            {
                Id = 8,
                Name = "Margherita",
                Description = "Traditional Italian pizza with tomatoes and basil",
                BasePrice = 9.99m,
                ImageUrl = "https://picsum.photos/seed/margherita/400/300",
            },
        };
        db.Specials.AddRange(specials);
        db.SaveChanges();
    }
}
