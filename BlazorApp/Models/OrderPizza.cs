namespace BlazorApp.Models;

/// <summary>
/// A configurable pizza in an order (special + size + toppings).
/// </summary>
public class OrderPizza
{
    public const int DefaultSize = 12;

    public int OrderPizzaId { get; set; }
    public int OrderId { get; set; }
    public PizzaSpecial? Special { get; set; }
    public int SpecialId { get; set; }
    public int Size { get; set; } = DefaultSize;
    public List<PizzaTopping> Toppings { get; set; } = new();

    public int MinimumSize => 8;
    public int MaximumSize => 16;

    public string GetFormattedTotalPrice()
    {
        var basePrice = (Special?.BasePrice ?? 0) * Size / DefaultSize;
        return basePrice.ToString("0.00");
    }
}
