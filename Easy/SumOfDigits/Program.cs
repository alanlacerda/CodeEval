using System;

namespace SumOfDigits
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (var line in System.IO.File.ReadLines(args[0]))
            {
                int sum = 0;

                for (int number = int.Parse(line); number > 0; sum += number % 10, number /= 10);

                Console.WriteLine(sum);
            }
        }
    }
}