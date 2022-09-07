namespace LearningCSharp
{
    using System;

    public class VirtulAndOverride
    {
        public static void Start()
        {
            BaseClass1 b1 = new DerivedClass1();
            BaseClass1 b2 = new DerivedClass2();
            BaseClass1 b3 = new DerivedClass3();

            b1.JustPrint(); 
            b2.JustPrint(); 
            b3.JustPrint();

            IInterface.Y();
            ABC.x = 5;
            ABC.Y();
            MyAbstractClass3.x = 6;
            MyAbstractClass3.Y();
        }
    }

    public class BaseClass1
    {
        public virtual void JustPrint()
        {
            Console.WriteLine("Response from base class");
        }
    }

    public class DerivedClass1 : BaseClass1
    {
        public override void JustPrint()
        {
            Console.WriteLine("Response from DerivedClass1");
        }
    }

    public class DerivedClass2 : DerivedClass1
    {
        public override void JustPrint()
        {
            Console.WriteLine("Response from DerivedClass2");
        }
    }

    public class DerivedClass3 : DerivedClass2, IInterface
    {
        public override void JustPrint()
        {
            Console.WriteLine("Response from DerivedClass3");
        }        
    }

    interface IInterface
    {
        private static int myX;

        public static void Y()
        { }

        static IInterface()
        {

        }        
    }

    public abstract class MyAbstractClass3
    {
        public static int x;
        public int z;

        static MyAbstractClass3()
        {

        }
        public static void Y()
        {

        }

        public void Y2()
        {

        }
    }

    public class ABC : MyAbstractClass3
    {
        public ABC()
        {
            base.z = 5;
            base.Y2();
        }
    }
}
