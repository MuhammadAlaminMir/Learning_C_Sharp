using System;

namespace _3_Operators;

public class _5_Logical
{
    public static void Logical()
    {
        bool a = true, b = false;

        // Logical AND - both must be true
        bool andResult = a && b;      // false

        // Logical OR - at least one true
        bool orResult = a || b;       // true

        // Logical NOT - inverts the value
        bool notResult = !a;          // false

        Console.WriteLine($"AND: {andResult}, OR: {orResult}, NOT: {notResult}");














        
    }
}
