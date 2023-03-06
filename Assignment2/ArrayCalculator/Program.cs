using System;

namespace ArrayCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] myArray = GetArray("Please choose:\n1.Default array\n2.Custom array\n");
            int maxValue = GetMax(myArray);
            Console.WriteLine("Max value: " + maxValue);
            int minValue = GetMin(myArray);
            Console.WriteLine("Min value: " + minValue);
            int sum = GetSum(myArray);
            Console.WriteLine("Sum of array elements: " + sum);
            double avg = GetAverage(myArray);
            Console.WriteLine("Average of array elements: " + avg);
        }

        static int[] GetArray(string s)
        {
            int op;
            int[] array = {32, 15, 7, 9, 21, 8, 17, 4, 81, 55};
            do
            {
                Console.Write(s);
            } while (!int.TryParse(Console.ReadLine(), out op) || (op != 1 && op !=2));;
            if (op == 1)
            {
                Console.WriteLine("The default array is: 32, 15, 7, 9, 21, 8, 17, 4, 81, 55");
            }
            if (op == 2)
            {
                Console.WriteLine("Please enter some integers (e.g. 1,2,3): ");
                string input = Console.ReadLine();
                string[] inputArray = input.Split(',');
                int[] intArray = new int[inputArray.Length];
                for (int i = 0; i < inputArray.Length; i++)
                {
                    intArray[i] = int.Parse(inputArray[i]);
                }
                Array.Resize(ref array, 0);
                array = intArray;
            }
            return array;
        }

        static int GetMax(int[] arr)
        {
            int max = arr[0];
            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i] > max)
                {
                    max = arr[i];
                }
            }
            return max;
        }

        static int GetMin(int[] arr)
        {
            int min = arr[0];
            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i] < min)
                {
                    min = arr[i];
                }
            }
            return min;
        }

        static int GetSum(int[] arr)
        {
            int sum = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                sum += arr[i];
            }
            return sum;
        }

        static double GetAverage(int[] arr)
        {
            double avg = 0;
            int sum = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                sum += arr[i];
            }
            if (arr.Length > 0)
            {
                avg = (double)sum / arr.Length;
            }
            return avg;
        }
    }
}
