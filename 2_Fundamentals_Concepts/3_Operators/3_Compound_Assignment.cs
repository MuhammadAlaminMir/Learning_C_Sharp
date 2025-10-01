using System;

namespace _3_Operators;

public class _3_Compound_Assignment
{
    public static void Assignment()
    {
        int number = 10;

        // Addition assignment
        number += 5;       // number = number + 5 → 15

        // Subtraction assignment  
        number -= 3;       // number = number - 3 → 12

        // Multiplication assignment
        number *= 2;       // number = number * 2 → 24

        // Division assignment
        number /= 4;       // number = number / 4 → 6

        // Modulus assignment
        number %= 4;       // number = number % 4 → 2

        // String concatenation assignment
        string text = "Hello";
        text += " World";  // text = text + " World" → "Hello World"
    }

}
