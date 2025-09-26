namespace _1_First_Program;


class Simple_Conversation
{
    public static void StartConversation()
    {
        // Learning about Console class and its methods:

        Console.WriteLine(" Hello! Please share your info with me.");

        Console.Write(" What's your name? ");
        string? name = Console.ReadLine();

        Console.Write(" How old are you? ");
        int? age = int.Parse(Console.ReadLine());

        Console.Write(" What's your favorite color? ");
        string? color = Console.ReadLine();

        Console.WriteLine($"\n Hello {name}! Your age {age} years old and Your favorite color is {color}. ");

        Console.WriteLine();

        Console.WriteLine(" It's great to see you hare.");


    }

}