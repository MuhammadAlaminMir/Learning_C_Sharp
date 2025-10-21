public partial class Product
{
    private decimal _price;
    public decimal Price
    {
        get { return _price; }
        set
        {
            _price = value;
            // This is the hook. If you don't implement it, this line disappears.
            OnPriceChanged();
        }
    }

    // Declaration of the partial method
    partial void OnPriceChanged();
}