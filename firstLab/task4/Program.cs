using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var x = MyClass<bool>.FactoryMethod();
            var y = MyClass<decimal>.FactoryMethod();

            Console.WriteLine(x.GetType().Name);
            Console.WriteLine(y.GetType().Name);
            Console.ReadKey();
        }
    }
    class MyClass<T>
    where T : new()
    {
        public static T FactoryMethod()
        {
            return new T();
        }
    }
}
