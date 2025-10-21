public partial class Product
{
    public string? Name { get; set; }

    // Optional implementation of the partial method

    partial void OnPriceChanged()
    {
        Console.WriteLine($"The price for '{Name}' has changed to ${_price}.");
    }
}