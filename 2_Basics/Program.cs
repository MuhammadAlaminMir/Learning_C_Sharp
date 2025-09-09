namespace _2_Basics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            sbyte a = 100;
            byte c = 120;
            c = byte.MaxValue;
            float b = 10.5f;
            double d = 20.5d;
            decimal e = 30.5m;

            int f = default(int);

            short s = 122;
            ushort us = 123;
            long l = 1234567890L;
            ulong ul = 1234567890UL;
            char n = 'A';
            bool isTrue = true;
            string str = "Hello, C#";

        }
    }
}
