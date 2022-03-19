using System.Collections.Generic;

namespace LearningCSharp
{
    class DynamicPolymorphism
    {
        // At run time we can take an object of base class and assign a child class object to it.
        public DynamicPolymorphism()
        {
            // Covariance
            BaseClassAnimal baseClassAnimal = new ChildClassDog();
            baseClassAnimal = new ChildClassCat();

            IEnumerable<BaseClassAnimal> baseClassAnimals = new List<ChildClassDog>();
            baseClassAnimals = new List<ChildClassCat>();

            // Contravariance
            // Contravariane is applied to parameters.Cotravariance allows a method
            // with the parameter of a base class to be assigned to a delegate that expects the parameter of a derived class.

        }
    }

    public class BaseClassAnimal
    {

    }

    public class ChildClassDog : BaseClassAnimal
    {

    }

    public class ChildClassCat : BaseClassAnimal
    {

    }
}
// Covariance allows interface methods to have more derived return types than that defined by the generic type parameters.
// Contravariance allows interface methods to have argument types that are less derived than that specified by the generic parameters. 



// An object of a more derived type is assigned to an object of a less derived type.
// object obj = str;

// Covariance.
/* IEnumerable<string> strings = new List<string>(); */
// An object that is instantiated with a more derived type argument
// is assigned to an object instantiated with a less derived type argument.
// Assignment compatibility is preserved.
/* IEnumerable<object> objects = strings; */

// Contravariance.
// Assume that the following method is in the class:
// static void SetObject(object o) { }
/* Action<object> actObject = SetObject; */
// An object that is instantiated with a less derived type argument
// is assigned to an object instantiated with a more derived type argument.
// Assignment compatibility is reversed.
/* Action<string> actString = actObject; */