using System;

namespace _3_Operators;

public class _9_Type_Casting
{
    public static void Type_Casting()
    {
        object obj = "Hello World";

        // is operator - type checking
        bool isString = obj is string;        // true
        bool isInt = obj is int;              // false

        // is with pattern matching (C# 7.0+)
        if (obj is string str)
        {
            Console.WriteLine(str.Length);  // str is strongly typed as string
        }

        // as operator - safe type conversion
        string text = obj as string;  // text = "Hello World"
        int? number = obj as int?;    // number = null (conversion failed)

        // Traditional cast (throws exception if invalid)
        string text2 = (string)obj;   // Works
                                      // int number2 = (int)obj;    // Throws InvalidCastException
    }

}
