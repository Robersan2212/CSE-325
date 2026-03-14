namespace BlazorApp.Models;

public class Order
{
    public int OrderId { get; set; }
    public DateTime CreatedTime { get; set; }
    public List<OrderPizza> Pizzas { get; set; } = new();

    public string GetFormattedTotalPrice()
    {
        var total = Pizzas.Sum(p => (p.Special?.BasePrice ?? 0) * p.Size / OrderPizza.DefaultSize);
        return total.ToString("0.00");
    }
}
