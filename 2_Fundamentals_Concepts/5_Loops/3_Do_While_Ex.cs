using System;

namespace _5_Loops;

public class _3_Do_While_Ex
{

    public static void Calculator()
    {
        char choice;
        do
        {
            Console.WriteLine("\nSimple Calculator");
            Console.WriteLine("+ : Add");
            Console.WriteLine("- : Subtract");
            Console.WriteLine("q : Quit");
            Console.Write("Choose operation: ");

            choice = Console.ReadKey().KeyChar;
            Console.WriteLine();

            if (choice == '+' || choice == '-')
            {
                Console.Write("Enter two numbers: ");
                int a = int.Parse(Console.ReadLine());
                int b = int.Parse(Console.ReadLine());

                if (choice == '+')
                    Console.WriteLine($"Result: {a + b}");
                else
                    Console.WriteLine($"Result: {a - b}");
            }

        } while (choice != 'q');
    }
}
