class ShoppingCart
{
    public static void CalculateTotal()
    {
        // Product information
        string productName = "Laptop";
        decimal unitPrice = 999.99m;
        int quantity = 2;
        decimal taxRate = 0.08m;  // 8%
        bool hasDiscount = true;

        // Calculations
        decimal subtotal = unitPrice * quantity;
        decimal discount = hasDiscount ? subtotal * 0.1m : 0;  // 10% discount if applicable
        decimal taxableAmount = subtotal - discount;
        decimal taxAmount = taxableAmount * taxRate;
        decimal total = taxableAmount + taxAmount;

        // Display results
        Console.WriteLine($"Product: {productName}");
        Console.WriteLine($"Quantity: {quantity}");
        Console.WriteLine($"Subtotal: {subtotal:C}");
        Console.WriteLine($"Discount: {discount:C}");
        Console.WriteLine($"Tax: {taxAmount:C}");
        Console.WriteLine($"Total: {total:C}");
    }
}