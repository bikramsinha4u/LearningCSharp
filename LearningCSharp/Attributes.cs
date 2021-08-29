using System;

namespace LearningCSharp
{
    /// <summary>
    /// Attributes allow you to add declarative information to your programs. This information can then be queried at runtime using reflection.
    /// Two types of attributes: pre-defined attributes and custom built attributes.
    /// 
    /// Three pre-defined attributes: AttributeUsage, Conditional, Obsolete.
    /// [AttributeUsage (validon,AllowMultiple = allowmultiple,Inherited = inherited)]
    /// [Conditional(conditionalSymbol)]
    /// [Obsolete (message)]
    /// 
    /// By default, an attribute applies to the element that follows it. But you can also explicitly identify, 
    /// for example, whether an attribute is applied to a method, or to its parameter, or to its return value.
    /// </summary>
    [Serializable]
    [Author("Bikram Sinha", version = 1.1)]
    [Author("Bikram Sinha", version = 1.2)]
    class ClassUsingAttributes
    {
        public static void PrintAuthorAttributesInfo(System.Type t)
        {
            System.Console.WriteLine("Author information for {0}", t);

            // Using reflection.  
            System.Attribute[] attrs = System.Attribute.GetCustomAttributes(t);

            // Displaying output.  
            foreach (System.Attribute attr in attrs)
            {
                if (attr is AuthorAttribute)
                {
                    AuthorAttribute a = (AuthorAttribute)attr;
                    System.Console.WriteLine("   {0}, version {1:f}", a.GetName(), a.version);
                }
            }
        }
    }

    [System.AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class AuthorAttribute : System.Attribute
    {
        private readonly string name;
        public double version;

        /// <summary>
        /// The constructor's parameters are the custom attribute's positional parameters.
        /// Any public read-write fields or properties are named parameters.
        /// </summary>
        /// <param name="message"></param>
        public AuthorAttribute(string name)
        {
            this.name = name;
            this.version = 1.0;
        }

        public string GetName()
        {
            return this.name;
        }
    }
}
