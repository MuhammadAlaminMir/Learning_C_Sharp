using System;

namespace _3_Operators;

public class _2_Arithmetic
{
    public static void Arithmetic()
    {
        int a = 10, b = 3;

        // Addition
        int sum = a + b;        // 13

        // Subtraction  
        int difference = a - b; // 7

        // Multiplication
        int product = a * b;    // 30

        // Division
        int quotient = a / b;   // 3 (integer division)
        double preciseQuotient = (double)a / b; // 3.333... (floating-point division)

        // Modulus (Remainder)
        int remainder = a % b;  // 1 (10 ÷ 3 = 3 with remainder 1)

        Console.WriteLine($"Sum: {sum}, Difference: {difference}");
        Console.WriteLine($"Product: {product}, Quotient: {quotient}, Remainder: {remainder}");
    }
}
