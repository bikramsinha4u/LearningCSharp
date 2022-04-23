using System;

namespace LearningCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            //ClassUsingAttributes.PrintAuthorAttributesInfo(typeof(ClassUsingAttributes));

            //MyClass.DelegateExamples();

            //YieldReturn.Consumer();

            //CustomDictionary.CutomeDictionayResult();

            //var drivedClassObj = new DerivedClass(5);


            StaticNonStaticCtor.x = 7;
            StaticNonStaticCtor.Print();
            var obj = new StaticNonStaticCtor();
            StaticNonStaticCtor.Print();

            Console.ReadLine();
        }
    }
}
