using System;

namespace _3_Operators;

public class _6_Bitwise
{
    public static void Bitwise()
    {
        int a = 5;  // Binary: 0101
        int b = 3;  // Binary: 0011

        int c = a & b; // 0001 (1)
        int d = a | b; // 0111 (7)
        int e = a ^ b; // 0110 (6)
        int f = ~a;    // 1010 (in 2's complement: -6)

        int g = a << 1; // 1010 (10)
        int h = a >> 1; // 0010 (2)
    }
}
