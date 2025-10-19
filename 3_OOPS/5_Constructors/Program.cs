public class Rectangle
{
    public double Width { get; set; }
    public double Height { get; set; }
    public string Color { get; set; }





    // Constructor 4: All parameters
    public Rectangle(double width, double height, string color)
    {
        Width = width;
        Height = height;
        Color = color;
        Console.WriteLine($"Rectangle {width}x{height} with color {color} created");
    }
    
    // Constructor 3: Width and Height only
    public Rectangle(double width, double height) : this(width, height, "red")
    {

        // Console.WriteLine($"Rectangle {width}x{height} created");
    }
    
    // Constructor 2: Square (single parameter)
    public Rectangle(double side) : this(side, 1)
    {

        // Console.WriteLine($"Square {side}x{side} created");
    }

    // Constructor 1: Parameterless
    public Rectangle() : this(0.0)
    {
        
        // Console.WriteLine("Default rectangle created");
    }
}

public class Program
{
    public static void Main()
    {

        // Usage - different constructors called based on arguments
        Rectangle rect1 = new Rectangle();                    // Parameterless
        Rectangle rect2 = new Rectangle(10, 5);              // Width/Height
        Rectangle rect3 = new Rectangle(10, 5, "Red");       // All parameters
        Rectangle rect4 = new Rectangle(8);                  // Square
    }

}