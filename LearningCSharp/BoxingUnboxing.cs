using System;

namespace LearningCSharp
{
    /// <summary>
    /// Boxing is the process of converting a value type to the type object or to any interface type implemented by this value type. 
    /// When the common language runtime (CLR) boxes a value type, it wraps the value inside a System.Object instance and stores it 
    /// on the managed heap. Unboxing extracts the value type from the object. Boxing is implicit; unboxing is explicit. 
    /// </summary>
    class BoxingUnboxing
    {
        public BoxingUnboxing()
        {
            int i = 5;
            object o = i; // implicit boxing
            object o2 = (object)i; // explict boxing

            int j = (int)o;   // unboxing

            // string is reference type: so here we cannot say it is boxing
            var str = "abc";
            var x = new String(str);
        }        
    }
}
