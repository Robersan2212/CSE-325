namespace BlazorApp.Models;

public class OrderWithStatus
{
    public Order Order { get; set; } = null!;
    public string StatusText { get; set; } = "Preparing";

    public static OrderWithStatus FromOrder(Order order)
    {
        return new OrderWithStatus
        {
            Order = order,
            StatusText = "Preparing"
        };
    }
}
