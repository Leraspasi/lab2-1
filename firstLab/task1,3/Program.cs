using System;
using System.Collections.Generic;
using System.Collections;

namespace task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] massive = new int[5];
            for (int i = 0; i < massive.Length; i++)
            {
                try
                {
                    Console.Write($"Enter the {i} element: ");
                    massive[i] = Convert.ToInt32(Console.ReadLine());
                    Console.Write(Environment.NewLine);
                }
                catch (Exception exp)
                {
                    Console.WriteLine(exp.Message);
                    break;
                }
            }

            MethFirstTask(massive);
            Console.ReadKey();
        }
        public static void MethFirstTask(int[] massive)
        {
            MyList<int> myList = new MyList<int>(massive);

            ////////***** Collection editing ****\\\\\\\\\\\
            Console.Write("Enter the element you want to add: ");
            int el = Convert.ToInt32(Console.ReadLine());
            myList.Add(el);

            Console.Write(Environment.NewLine);
            Console.WriteLine("Adding all elements...");
            Console.Write(Environment.NewLine);
            myList.Contains(5);

            Console.WriteLine($"All elements in collection = {myList.Count}");

            ////////***** Collection output  ****\\\\\\\\\\\
            myList.OUTPUT();

            ////////***** Extension method ****\\\\\\\\\\\
            Console.WriteLine("Extension method: ");
            for (int i = 0; i < myList.Count; i++)
            {
                Console.WriteLine(myList.GetArray()[i]);
                Console.Write(Environment.NewLine);
            }
        }
    }
    interface IMyList<T>
    {
        void Add(T a);
        int Count { get; }
        bool Contains(T item);
    }
    class MyList<T> : IMyList<T>, IEnumerable, IEnumerator
    {
        private T[] someArr;
        List<T> newList = new List<T>();
        public MyList(T[] _somearr)
        {
            this.someArr = _somearr;
        }
        public MyList()
        { }
        public void OUTPUT()
        {
            foreach (var item in newList)
            {
                Console.WriteLine(item);
                Console.Write(Environment.NewLine);
            }
        }
        public void Add(T a)
        {
            newList.Add(a);
            newList.AddRange(someArr);
        }
        public int Count { get => newList.Count; }
        public bool Contains(T item)
        {
            if (newList.Contains(item))
            {
                Console.WriteLine($"Item {item} is exist..");
                int index = newList.IndexOf(item);
                newList.RemoveAt(index);
                Console.WriteLine($"Deleting {item} ... ");
            }
            else
            {
                Console.WriteLine("Element is not contained in the collection ");
            }
            Console.Write(Environment.NewLine);
            return true;
        }

        ////////***** IEnumerator Realization ****\\\\\\\\\\\
        int position = -1;
        public object Current
        {
            get { return someArr[position]; }
        }
        public bool MoveNext()
        {
            if (position < someArr.Length - 1)
            {
                position++;
                return true;
            }
            else { Reset(); return false; }
        }
        public void Reset()
        {
            position = -1;
        }

        ////////***** IEnumerable Realization ****\\\\\\\\\\\
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this as IEnumerator;
        }
    }
    ////////***** Extension method ****\\\\\\\\\\\
    static class MyClass
    {
        public static T[] GetArray<T>(this MyList<T> list)
        {
            int i = 0; T[] array = new T[i];
            foreach (T item in list)
            {
                T[] array2 = new T[array.Length + 1];
                array.CopyTo(array2, 0);
                array2[array.Length] = item;
                array = array2;
            }
            return array;
        }
    }
}