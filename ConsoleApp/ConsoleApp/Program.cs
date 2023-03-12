using System;

namespace SimpleProgram
{
    public class Program
    {
        public static int add(int a, int b)
        {
            return a + b;
        }

        public static int multiply(int a, int b)
        {
            return a * b;
        }

        static void Main(string[] args)
        {
            int choice;
            Console.WriteLine("choose what you want to do with 2 integers: [1] - add [2] - multiply:");
            choice = Convert.ToInt32(Console.ReadLine());
            int a, b;
            Console.WriteLine("Enter 1st integer:");
            a = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter 2nd integer:");
            b = Convert.ToInt32(Console.ReadLine());

            if (choice == 1) {
                Console.WriteLine("The result of adding {0} and {1} is {2}.", a, b, add(a, b));
            } 
            else if (choice == 2) {
                Console.WriteLine("The result of multiplying {0} from {1} is {2}.", a, b, multiply(a, b));
            }





            
        }

     
    }
}