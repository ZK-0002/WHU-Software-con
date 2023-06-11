using System;

namespace Linklistaction
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            GenericList<Int32> intList = new GenericList<int>();
            for (int i = 0; i < 10; i++)
            {
                intList.Add(i);
            }
            //print
            GenericList<Int32>.ForEach(intList, node => Console.Write("Data:" + node.Data + " "));
            Console.WriteLine();
            // sum
            int a = 0;
            GenericList<Int32>.ForEach(intList, 
                (node) =>
                {
                    a += node.Data;
                });
            Console.WriteLine("The sum of list is " + a);
            //max
            int max = intList.Head.Data;
            GenericList<Int32>.ForEach(intList, node => {
                if (node.Data > max)
                {
                    max = node.Data;
                }
            });
            Console.WriteLine("The max data is " + max);
            //min
            int min = intList.Head.Data;
            GenericList<Int32>.ForEach(intList, node => {
                if (node.Data < min)
                {
                    min = node.Data;
                }
            });
            Console.WriteLine("The min data is " + min);
        }
    }
}