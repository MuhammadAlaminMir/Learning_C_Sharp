class Implicit_Casting
{
    
    public static void Examples()
    {
        int smallNumber = 123;

        // This is an IMPLICIT conversion.
        // It's safe because a 'long' can easily hold any 'int' value.
        // No special syntax is needed.
        long bigNumber = smallNumber;

        Console.WriteLine($"Int: {smallNumber}, Long: {bigNumber}");
        // Output: Int: 123, Long: 123

        // Another example: float to double
        float myFloat = 10.5f;
        double myDouble = myFloat; // Safe, automatic conversion
    }
}