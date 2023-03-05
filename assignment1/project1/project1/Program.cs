using System;

namespace project1
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            double n1, n2, result;
            string t, op;
            Console.WriteLine("Please input the 1st number:");
            t = Console.ReadLine();
            n1 = Double.Parse(t);
            Console.WriteLine("Please input the 2nd number:");
            t = Console.ReadLine();
            n2 = Double.Parse(t);
            Console.WriteLine("Please select an operation type:");
            op = Console.ReadLine();
            switch (op)
            {
                case "+":
                    result = n1 + n2;
                    Console.WriteLine("The result is:" + result);
                    break;
                case "-":
                    result = n1 - n2;
                    Console.WriteLine("The result is:" + result);
                    break;
                case "*":
                    result = n1 * n2;
                    Console.WriteLine("The result is:" + result);
                    break;
                case "/":
                    if (n2 == 0)
                        Console.WriteLine("Divide by zero error!");
                    else
                    {
                        result = n1 / n2;
                        Console.WriteLine("The result is:" + result);
                    }
                    break;
                default:
                    Console.WriteLine("Misinput!");
                    break;
            }
        }
    }
}