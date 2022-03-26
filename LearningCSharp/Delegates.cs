using System;

namespace LearningCSharp
{
    delegate string SinglecastDelegate(string firstName, string lastName);

    delegate void MulticastDelegate(double Width, double Height);

    class MyClass
    {
        public string GetUserName(string firstName, string lastName)
        {
            return firstName + " " + lastName;
        }

        public void GetArea(double width, double height)
        {
            Console.WriteLine(@"Area is {0}", (width * height));
        }

        public void GetPerimeter(double width, double height)
        {
            Console.WriteLine(@"Perimeter is {0}", (2 * (width + height)));
        }

        public bool IsTrue(string isTrue)
        {
            if (isTrue == "true")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static void DelegateExamples()
        {
            // Single Cast Delegate
            MyClass myClassObj = new MyClass();
            SinglecastDelegate singlecastDelegate = new SinglecastDelegate(myClassObj.GetUserName);
            singlecastDelegate("Manikandan", "M");

            // Multicast delegate
            MulticastDelegate multicastDelegate = new MulticastDelegate(myClassObj.GetArea);
            multicastDelegate += myClassObj.GetPerimeter;
            multicastDelegate(2, 3);

            // Func
            Func<string, string, string/*return type*/> funcDelgate = new Func<string, string, string>(myClassObj.GetUserName);
            string funcResult = funcDelgate.Invoke("Bikram", "Sinha");
            Console.WriteLine(@"Func Delegate Output: " + funcResult);

            // Action
            Action<double, double> actionDelegate = new Action<double, double>(myClassObj.GetArea);
            Console.Write(@"Action Delegate Output: ");
            actionDelegate.Invoke(2, 3);

            // Predicate
            Predicate<string> predicateDelegate = new Predicate<string>(myClassObj.IsTrue);
            bool predicateDelegateResult = predicateDelegate("true");
            Console.WriteLine(@"Predicate Delegate Output: " + predicateDelegateResult);
        }
    }
}
