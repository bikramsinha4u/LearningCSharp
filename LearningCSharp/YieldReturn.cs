using System;
using System.Collections.Generic;

namespace LearningCSharp
{
    class YieldReturn
    {
        public static void Consumer()
        {
            foreach (int i in Integers())
            {
                Console.WriteLine(i.ToString());
            }
        }

        // When you step through the example, you'll find the first call to Integers() returns 1.
        // The second call returns 2 and the line yield return 1 is not executed again.
        public static IEnumerable<int> Integers()
        {
            yield return 1;
            yield return 2;
            yield return 4;
            yield return 8;
            yield return 16;
            yield return 16777216;
        }
    }
}
