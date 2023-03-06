using System;

namespace PrimeFactor
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = GetUserInput("Please enter an integer greater than 1: ");
            int[] primeFactors = FindPrimeFactors(number);
            primeFactors = Merge(primeFactors);
            Console.WriteLine($"The prime factor(s) of {number} is/are: {string.Join(", ", primeFactors)}");
        }

        static int GetUserInput(string s)
        {
            int input;
            do
            {
                Console.Write(s);
            } while (!int.TryParse(Console.ReadLine(), out input) || input <= 1);
            return input;
        }

        static int[] FindPrimeFactors(int number)
        {
            int[] factors = new int[0];
            for (int i = 2; i <= number; i++)
            {
                if (number % i == 0 && IsPrime(i))
                {
                    Array.Resize(ref factors, factors.Length + 1);
                    factors[factors.Length - 1] = i;
                    number /= i;
                    i--;
                }
            }
            return factors;
        }

        static bool IsPrime(int number)
        {
            if (number < 2) return false;
            for (int i = 2; i <= Math.Sqrt(number); i++)
            {
                if (number % i == 0) return false;
            }
            return true;
        }

        static int[] Merge(int[] arr)
        {
            int[] factors = new int[1];
            factors[0] = arr[0];
            for (int i = 0; i < arr.Length - 1; i++)
            {
                if (arr[i] != arr[i + 1])
                {
                    Array.Resize(ref factors, factors.Length + 1);
                    factors[factors.Length - 1] = arr[i + 1];
                }
            }
            return factors;
        }
    }
}