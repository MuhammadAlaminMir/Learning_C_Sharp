class TypeConverter
{
    public static void DemonstrateConversions()
    {
        // String to number
        string userAge = "25";
        int age = int.Parse(userAge);

        // Number to string
        string ageString = age.ToString();

        // Floating point conversions
        double preciseValue = 123.456789;
        float lessPrecise = (float)preciseValue;  // Explicit cast

        // Character operations
        char firstLetter = 'A';
        int asciiValue = firstLetter;  // Implicit conversion to ASCII
        char nextLetter = (char)(asciiValue + 1);  // 'B'

        // Boolean conversions
        string truthString = "True";
        bool isTrue = bool.Parse(truthString);

        Console.WriteLine($"Age: {age}, Ascii: {asciiValue}, Next: {nextLetter}");
    }
}