using System;

namespace LearningCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            ClassUsingAttributes.PrintAuthorAttributesInfo(typeof(ClassUsingAttributes));

            MyClass.DelegateExamples();

            Console.ReadLine();
        }
    }
}
