using System;

namespace SieveOfEratosthenes
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> primes = FindPrimes(100);
            Console.WriteLine($"Prime numbers from 2 to 100 are: {string.Join(", ", primes)}");
        }

        static List<int> FindPrimes(int upperLimit)
        {
            List<int> primes = new List<int>();
            bool[] isComposite = new bool[upperLimit];
            for (int i = 2; i <= upperLimit; i++)
            {
                if (!isComposite[i - 1])
                {
                    primes.Add(i);
                    for (int j = 2; i * j <= upperLimit; j++)
                    {
                        isComposite[i * j - 1] = true;
                    }
                }
            }
            return primes;
        }
    }
}