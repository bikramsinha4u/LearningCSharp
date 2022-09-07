using System;
using System.Collections.Generic;
using System.Text;

namespace LearningCSharp
{
    #region Inheritance from multiple interfaces with the same method name.
    public class FindOutput: A, B
    {
        /* When using explicit interface implementations, 
         * the functions are not public on the class. 
         * Therefore in order to access these functions, 
         * you have to first cast the object to the interface type, 
         * or assign it to a variable declared of the interface type. */
    int B.Get()
        {
            return 0;
        }

        public int Get()
        {
            return 0;
        }

        string A.Get()
        {
            return null;
        }
    }

    interface A
    {
        public string Get();
    }

    interface B
    {
        public int Get();
    }
    #endregion Inheritance from multiple interfaces with the same method name.

    #region static variable, field variable and ctor execution sequence.
    public class BaseClassA
    {
        public static int x;
        public int y;
        static BaseClassA()
        {
            x = 5;
        }
        public BaseClassA()
        {
            y = 6;
        }
    }

    
    public class DerivedClassB: BaseClassA
    {
        public static int m;
        public int n = x + 3;
        static DerivedClassB()
        {
            m = 25;
        }
        public DerivedClassB()
        {
            n = 26;
        }
    }
    #endregion static variable, field variable and ctor execution sequence.
}
