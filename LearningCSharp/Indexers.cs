using System;

namespace LearningCSharp
{
    /// <summary>
    /// Indexers allow instances of a class or struct to be indexed just like arrays.
    /// An indexer can be defined the same way as property with this keyword and square brackets [].
    /// </summary>
    /// <typeparam name="T"></typeparam>
    class SampleCollection<T>
    {
        // Declare an array to store the data elements.
        private T[] arr = new T[100];

        // Define the indexer to allow client code to use [] notation.
        public T this[int i]
        {
            get { return arr[i]; }
            set { arr[i] = value; }
        }

        static void IndexersExample()
        {
            var stringCollection = new SampleCollection<string>();
            stringCollection[0] = "Hello, World";
            Console.WriteLine(stringCollection[0]);
        }
    }

    class StringDataStore
    {
        private string[] strArr = new string[10]; // internal data storage

        public string this[int index]
        {
            get
            {
                if (index < 0 || index >= strArr.Length)
                    throw new IndexOutOfRangeException("Index out of range");

                return strArr[index];
            }

            set
            {
                if (index < 0 || index >= strArr.Length)
                    throw new IndexOutOfRangeException("Index out of range");

                strArr[index] = value;
            }
        }

        static void IndexersExample()
        {
            StringDataStore strStore = new StringDataStore();

            strStore[0] = "One";
            strStore[1] = "Two";
            strStore[2] = "Three";
            strStore[3] = "Four";

            for (int i = 0; i < 10; i++)
                Console.WriteLine(strStore[i]);
        }
    }
}
