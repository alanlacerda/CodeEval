using System;
using System.Collections.Generic;

namespace PassTriangle
{
    static class Program
    {
        static void Main(string[] args)
        {
            var triangle = LoadTriangleFromFile(args[0]);

            for (int row = triangle.Count - 2; row >= 0; --row)
            {
                for (int col = 0; col <= row; ++col)
                {
                    int left = triangle[row + 1][col];
                    int right = triangle[row + 1][col + 1];

                    triangle[row][col] += left > right ? left : right;
                }
            }

            Console.Write(triangle[0][0]);
		}

        static List<List<int>> LoadTriangleFromFile(string path)
        {
            var output = new List<List<int>>();

            foreach (string line in System.IO.File.ReadLines(path))
            {
                var numbers = new List<int>();

                foreach (string number in line.TrimEnd().Split(' '))
                {
                    numbers.Add(int.Parse(number));
                }

                output.Add(numbers);
            }

            return output;
        }
    }
}
