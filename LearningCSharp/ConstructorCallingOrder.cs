using System;

namespace LearningCSharp
{
    class ConstructorCallingOrder
    {
    }

    public class MyBase
    {
        public MyBase()
        {
            Console.WriteLine("MyBase");
        }
    }

    public class MyDerived : MyBase
    {
        public MyDerived() : base()
        {
            Console.WriteLine("MyDerived");
        }
    }
}

// constructors are executed from the base to derived
// destructors are executed in the opposite way - first the derived destructors and then base destructors.
// First, field initializers will be called in order of most-derived to least-derived classes.
// So first field initializers of C, then B, then A.
