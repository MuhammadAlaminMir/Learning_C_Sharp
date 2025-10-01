using System;

namespace _5_Loops;

public class _4_ForEach_Loop
{
    // Traverse String array:
    public static void StringArray()
    {
        string[] fruits = { "apple", "banana", "orange", "grape" };

        foreach (string fruit in fruits)
        {
            Console.WriteLine(fruit);
        }
    }

    // Loop with index:
    public static void WithIndex()
    {
        string[] colors = { "red", "green", "blue", "yellow" };
        int index = 1;

        foreach (string color in colors)
        {
            Console.WriteLine($"{index}. {color}");
            index++;
        }
    }
}
