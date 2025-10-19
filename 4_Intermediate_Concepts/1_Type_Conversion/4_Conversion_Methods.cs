class Conversion_Methods
{

    public static void Examples()
    {
        // Converting a string to a number (like Parse, but part of a larger system)
        string myText = "789";
        int convertedInt = Convert.ToInt32(myText);
        Console.WriteLine(convertedInt); // Output: 789

        // Converting a double to an int (notice it rounds, doesn't truncate!)
        double myDouble = 9.8;
        int convertedFromDouble = Convert.ToInt32(myDouble);
        Console.WriteLine(convertedFromDouble); // Output: 10 (rounded!)

        // Converting a boolean to a string
        bool isReady = true;
        string statusText = Convert.ToString(isReady);
        Console.WriteLine(statusText); // Output: "True"
    }
}