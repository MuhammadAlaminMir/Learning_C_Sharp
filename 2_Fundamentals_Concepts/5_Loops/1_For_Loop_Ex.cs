using System;

namespace _5_Loops;

public class _1_For_Loop
{
    public static void Example_1()
    {
        // Simple counting from 1 to 100
        for (int i = 1; i <= 100; i++)
        {
            Console.WriteLine(i);
        }
    }

    public static void Example_2()
    {
        // Count even numbers only
        for (int i = 2; i <= 50; i += 2)
        {
            Console.WriteLine(i);
        }

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
        Console.WriteLine("Prime numbers between 1 and 100:");

        for (int num = 2; num <= 100; num++)
        {
            bool isPrime = true;

            for (int i = 2; i <= num / 2; i++)
            {
                if (num % i == 0)
                {
                    isPrime = false;
                    break;
                }
            }

            if (isPrime)
                Console.Write(num + " ");
        }

    }


}
