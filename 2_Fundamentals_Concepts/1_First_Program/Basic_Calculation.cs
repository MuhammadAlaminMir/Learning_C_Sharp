using System;

namespace _1_First_Program;

public class Basic_Calculation
{
    public static void StartCalculation()
    {
        Console.WriteLine("=== Simple Calculator ===");

        Console.Write("Enter first number: ");
        double? num1 = double.Parse(Console.ReadLine());

        Console.Write("Enter second number: ");
        double? num2 = double.Parse(Console.ReadLine());

        Console.WriteLine($"\nResults:");
        Console.WriteLine($"{num1} + {num2} = {num1 + num2}");
        Console.WriteLine($"{num1} - {num2} = {num1 - num2}");
        Console.WriteLine($"{num1} * {num2} = {num1 * num2}");
        Console.WriteLine($"{num1} / {num2} = {num1 / num2}");

        Console.WriteLine("\nThank You");


    }
}
