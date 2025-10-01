using System;

namespace _3_Operators;

public class _4_Comparison
{
    public static void Comparison()
    {
        int a = 10, b = 5;

        // Equality
        bool equal = (a == b);        // false

        // Inequality
        bool notEqual = (a != b);     // true

        // Greater than
        bool greater = (a > b);       // true

        // Less than
        bool less = (a < b);          // false

        // Greater than or equal to
        bool greaterOrEqual = (a >= b); // true

        // Less than or equal to
        bool lessOrEqual = (a <= b);    // false

        Console.WriteLine($"a == b: {equal}, a != b: {notEqual}");
        Console.WriteLine($"a > b: {greater}, a < b: {less}");

        //floating-point comparison
        // ❌ Dangerous: Direct floating-point comparison
        double d1 = 0.1 + 0.2;
        double d2 = 0.3;
        bool directCompare = (d1 == d2);  // False! Due to precision issues

        // ✅ Safe: Compare with tolerance
        bool safeCompare = Math.Abs(d1 - d2) < 0.0001;  // True

        // ✅ Better: Use decimal for exact comparisons
        decimal m1 = 0.1m + 0.2m;
        decimal m2 = 0.3m;
        bool exactCompare = (m1 == m2);  // True
    }

}
