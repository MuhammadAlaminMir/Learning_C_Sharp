using System;

namespace _3_Operators;

public class _7_Conditional
{
    public static void Conditional()
    {
        // Syntax: condition ? value_if_true : value_if_false
        int age = 20;
        string status = age >= 18 ? "Adult" : "Minor";
        Console.WriteLine(status);  // "Adult"

        // Equivalent to:
        string status2;
        if (age >= 18)
            status2 = "Adult";
        else
            status2 = "Minor";
    }
}
