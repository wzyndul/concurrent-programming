using System;

namespace SimpleProgram
{
    public class Program
    {
        public static int add(int a, int b)
        {
            return a + b;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Enter 2 integers to add:");
            int a, b;
            Console.WriteLine("Enter 1st integer:");
            a = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter 2nd integer:");
            b = Convert.ToInt32(Console.ReadLine());



            Console.WriteLine("The result of adding {0} and {1} is {2}.", a, b, add(a, b));
        }
    }
}