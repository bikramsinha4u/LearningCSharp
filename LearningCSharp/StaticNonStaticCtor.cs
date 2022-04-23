using System;

namespace LearningCSharp
{
    class StaticNonStaticCtor
    {
        public static int x;

        public StaticNonStaticCtor()
        {
            x = 9;

            Console.Write("ParameterLess Ctor is called.");
            Print();
        }

        // Cannot have access modifier
        static StaticNonStaticCtor()
        {
            x = 1;

            Console.Write("Static Ctor is called.");
            Print();
        }

        public static void Print()
        {
            Console.WriteLine("Value of x = {0}", x);
        }
    }
}
