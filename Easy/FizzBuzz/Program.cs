using System;
using System.IO;

namespace FizzBuzz
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            foreach (string line in File.ReadLines(args[0]))
            {
                string[] elements = line.Split(' ');
                int fizz = int.Parse(elements[0]);
                int buzz = int.Parse(elements[1]);
                int count = int.Parse(elements[2]);

                for (int i = 1; i <= count; ++i)
                {
                    bool foundFizz = i % fizz == 0;
                    bool foundBuzz = i % buzz == 0;

                    if (foundFizz)
                    {
                        Console.Write("F");
                    }

                    if (foundBuzz)
                    {
                        Console.Write("B");
                    }
                    
                    if (!(foundFizz || foundBuzz))
                    {
                        Console.Write(i);
                    }

                    Console.Write(" ");
                }

                Console.Write(Environment.NewLine);
            }
        }
    }
}