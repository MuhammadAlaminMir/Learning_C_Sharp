using System;

namespace _5_Loops;

public class _2_While_Loop_Ex
{


    public static void Example_1()
    {
        // Print number until user stops
        int number = 1;
        string response;

        while (true)
        {
            Console.WriteLine(number);
            number++;

            Console.Write("Continue? (y/n): ");
            response = Console.ReadLine();

            if (response?.ToLower() != "y")
                break;
        }
    }

    public static void Example_2()
    {
        // Sum Numbers Until Negative:
        int sum = 0;
        int input;

        Console.WriteLine("Enter numbers to sum (negative to stop):");

        while (true)
        {
            input = int.Parse(Console.ReadLine());

            if (input < 0)
                break;

            sum += input;
            Console.WriteLine($"Current sum: {sum}");
        }

        Console.WriteLine($"Final sum: {sum}");

    }

    public static void Example_3()
    {
        // Counting backwards
        for (int i = 100; i >= 1; i--)
        {
            Console.WriteLine(i);
        }
        Console.WriteLine("Blast off! 🚀");
    }

    public static void Example_4()
    {
        int count = 0;
        int number = 2;

        Console.WriteLine("First 20 prime numbers:");

        while (count < 20)
        {
            bool isPrime = true;

            for (int i = 2; i <= Math.Sqrt(number); i++)
            {
                if (number % i == 0)
                {
                    isPrime = false;
                    break;
                }
            }

            if (isPrime)
            {
                Console.WriteLine(number);
                count++;
            }

            number++;
        }

    }




}
