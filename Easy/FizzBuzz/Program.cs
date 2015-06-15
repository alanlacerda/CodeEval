using System;

namespace FizzBuzz
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            foreach (var line in System.IO.File.ReadLines(args[0]))
            {
                var elements = line.Split(' ');

                int fizz = int.Parse(elements[0]);
                int buzz = int.Parse(elements[1]);
                int count = int.Parse(elements[2]);

                for (var i = 1; i <= count; ++i)
                {
                    bool isFizz = i % fizz == 0;
                    bool isBuzz = i % buzz == 0;

                    if (isFizz)
                        Console.Write('F');

                    if (isBuzz)
                        Console.Write('B');
                    
                    if (!(isFizz || isBuzz))
                        Console.Write(i);

                    Console.Write(' ');
                }

                Console.Write(Environment.NewLine);
            }
        }
    }
}