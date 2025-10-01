using System;

namespace _3_Operators;

public class _8_Null
{
    public static void Null()
    {
        string name = null;
        string displayName = name ?? "Guest"; // "Guest"

        int? count = null;
        int result = count ?? 0; // 0

        // Null-coalescing assignment
        List<string> items = null;
        items ??= new List<string>(); // Creates new list if null
    }

}
