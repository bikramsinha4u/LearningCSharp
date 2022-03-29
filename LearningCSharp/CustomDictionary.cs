using System;
using System.Collections.Generic;

namespace LearningCSharp
{
    class CustomDictionary
    {
        private class myDictionary
        {
            public string myKey { get; set; }
            public string myValue { get; set; }
        }

        private List<myDictionary> myDictionaryList = new List<myDictionary>();

        public string this[string inputKey]
        {
            get
            {
               return  myDictionaryList.Find(x => x.myKey == inputKey).myValue;
            }
            set
            {
                var obj = new myDictionary() { myKey = inputKey, myValue = value };
                myDictionaryList.Add(obj);
            }
        }

        public static void CutomeDictionayResult()
        {
            var myCustomDictionay = new CustomDictionary();

            myCustomDictionay["bikram"] = "sinha";
            Console.WriteLine("Dictionay is set as Key: bikram, Value: sinha.");
            
            var value = myCustomDictionay["bikram"];
            Console.WriteLine("Dictionay value for key: bikram is: {0}", value);
        }
    }
}
