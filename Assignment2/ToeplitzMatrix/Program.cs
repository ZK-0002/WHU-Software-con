using System;

namespace ToeplitzMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] matrix = ReadMatrix();
            bool upperTriangle = UpperTriangle(matrix);
            bool lowerTriangle = LowerTriangle(matrix);
            bool isToeplitz = upperTriangle & lowerTriangle;
            Console.WriteLine(isToeplitz ? "True" : "False");
        }
        
        static int[,] ReadMatrix()
        {
            Console.WriteLine("Please enter a matrix:");
            Console.WriteLine("e.g.\n2 3\n1 2 3\n1 1 2\n");
            string[] firstLine = Console.ReadLine().Split();
            int rows = int.Parse(firstLine[0]);
            int cols = int.Parse(firstLine[1]);
            int[,] matrix = new int[rows, cols];
            for (int i = 0; i < rows; i++)
            {
                string[] rowLine = Console.ReadLine().Split();
                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = int.Parse(rowLine[j]);
                }
            }
            return matrix;
        }

        static bool UpperTriangle(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            for (int i = 0; i < cols; i++)
            {
                int val = matrix[0, i];
                int row = 1;
                int col = i + 1;
                while (row < rows && col < cols)
                {
                    if (matrix[row, col] != val)
                        return false;
                    row++;
                    col++;
                }
            }
            return true;
        }

        static bool LowerTriangle(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            for (int i = 1; i < rows; i++)
            {
                int val = matrix[i, 0];
                int row = i + 1;
                int col = 1;
                while (row < rows && col < cols)
                {
                    if (matrix[row, col] != val)
                        return false;
                    row++;
                    col++;
                }
            }
            return true;
        }
    }
}