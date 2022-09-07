using System;

namespace LearningCSharp
{
    class BaseClass
    {
        public BaseClass()
        {
            Console.WriteLine("Ctor b1 is called.");
        }

        public BaseClass(int p1)
        {
            Console.WriteLine("Ctor b2 is called.");
        }
    }

    class DerivedClass: BaseClass
    {
        public DerivedClass(): base(5)
        {
            Console.WriteLine("Ctor d1 is called.");
        }

        public DerivedClass(int p1): this()
        {
            Console.WriteLine("Ctor d2 is called.");
        }

        public DerivedClass(int p1, int p2): this(p1)
        {
            Console.WriteLine("Ctor d3 is called.");
        }
    }
}
