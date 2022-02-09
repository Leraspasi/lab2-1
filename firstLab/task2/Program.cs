using System;
using System.Collections;
using System.Collections.Generic;

namespace task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MyDictionary<int, string> myDictionary = new MyDictionary<int, string>();
            myDictionary.arg1 = new int[4] { 0, 1, 2, 3 };
            myDictionary.arg2 = new string[4] { "Zero", "One", "Two", "Three" };
            myDictionary.Add();

            foreach (KeyValuePair<int, string> keyValuePair in myDictionary)
            {
                Console.WriteLine(keyValuePair.Key + "-" + keyValuePair.Value);
            }
            Console.Write(Environment.NewLine);
            try
            {
                Console.WriteLine("Enter the element: ");
                int value = Convert.ToInt32(Console.ReadLine());
                myDictionary.Contains(value);
            }
            catch (Exception someexp)
            {
                Console.WriteLine(someexp.Message);
            }
            Console.ReadKey();
        }
    }
    interface IMyDictionary<TKey, TValue>
    {
        void Add();
        int Count { get; }
        void Contains(TKey value);
    }
    class MyDictionary<TKey, TValue> : IMyDictionary<TKey, TValue>, IEnumerable
    {
        Dictionary<TKey, TValue> somedict = new Dictionary<TKey, TValue>();
        public TKey[] arg1;
        public TValue[] arg2;

        public void Add()
        {
            Console.WriteLine("Adding the element...");
            for (int i = 0; i < arg1.Length; i++)
            {
                somedict.Add(arg1[i], arg2[i]);
            }
        }
        public int Count { get; }
        public void Contains(TKey value)
        {
            try
            {
                TValue per = somedict[value];
                Console.WriteLine("Value is found!");
                Console.WriteLine($"This is {per}");
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }

        ////////***** IEnumerable Realization ****\\\\\\\\\\\
        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            for (int i = 0; i < arg1.Length; i++)
                yield return new KeyValuePair<TKey, TValue>(arg1[i], arg2[i]);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
