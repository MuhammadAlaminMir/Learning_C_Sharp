class Explicit_Casting
{

    public static void Examples()
    {
        long bigNumber = 150;
        int smallNumber;

        // This is an EXPLICIT conversion.
        // We MUST use the (int) syntax to tell the compiler we accept the risk.
        smallNumber = (int)bigNumber;

        Console.WriteLine($"Long: {bigNumber}, Int: {smallNumber}");
        // Output: Long: 150, Int: 150 (This worked fine, 150 fits in an int)

        // --- Now let's see the risk of data loss ---
        double preciseValue = 99.98;
        int truncatedValue = (int)preciseValue; // The decimal part is chopped off!

        Console.WriteLine($"Double: {preciseValue}, Int: {truncatedValue}");
        // Output: Double: 99.98, Int: 99  <-- DATA LOSS!
    }
}