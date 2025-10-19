class Parse_TryParse
{

    public static void Examples()
    {


        /// Examples for the Parse method

        string textNumber = "456";
        int number = int.Parse(textNumber); // Works fine
        Console.WriteLine(number); // Output: 456

        string badText = "hello";
        // int badNumber = int.Parse(badText); // <-- This would CRASH the program!

        /// Example for the tryParse Method
        string userInput = "123";
        int result;

        // The classic TryParse pattern
        if (int.TryParse(userInput, out result))
        {
            // If we get here, the conversion worked!
            Console.WriteLine($"Conversion successful! The number is {result}.");
        }
        else
        {
            // If we get here, the string was not a valid integer.
            Console.WriteLine("Conversion failed. That was not a valid number.");
        }

        string badInput = "abc";
        if (int.TryParse(badInput, out result))
        {
            Console.WriteLine($"Conversion successful! The number is {result}.");
        }
        else
        {
            Console.WriteLine($"'{badInput}' is not a valid number."); // This line will run
        }

    }
}