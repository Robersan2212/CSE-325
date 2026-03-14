namespace BlazorApp.Data;

public class PizzaService
{
    public Task<Pizza[]> GetPizzasAsync()
    {
        // In a real app, call your data access technology here (e.g. Entity Framework, HTTP client).
        var pizzas = new Pizza[]
        {
            new Pizza { PizzaId = 1, Name = "Margherita", Description = "Tomatoes and basil", Price = 9.99M, Vegetarian = true, Vegan = false },
            new Pizza { PizzaId = 2, Name = "Pepperoni", Description = "Classic pepperoni", Price = 10.50M, Vegetarian = false, Vegan = false },
            new Pizza { PizzaId = 3, Name = "Veggie Delight", Description = "It's like salad, but on a pizza", Price = 11.50M, Vegetarian = true, Vegan = false },
            new Pizza { PizzaId = 4, Name = "Buffalo chicken", Description = "Spicy chicken, hot sauce, blue cheese", Price = 12.75M, Vegetarian = false, Vegan = false },
            new Pizza { PizzaId = 5, Name = "Basic Cheese", Description = "Cheesy and delicious", Price = 11.99M, Vegetarian = true, Vegan = false },
        };
        return Task.FromResult(pizzas);
    }
}
