// Instead of just importing the namespace...
// using System;

// ...you import the static members of the class itself.
using static System.Console;
using static System.Math;

public class Program
{
    public static void Main()
    {
        // No need for 'Console.'
        WriteLine("Hello, static using!");

        // No need for 'Math.'
        double result = Sqrt(144);
        WriteLine($"The square root is {result}");
    }
}
