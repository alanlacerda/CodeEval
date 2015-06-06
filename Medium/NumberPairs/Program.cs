using System;
using System.IO;

namespace NumberPairs
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (string line in File.ReadLines(args[0]))
            {
                if (line.Length < 4)
                {
                    continue;
                }

                string[] splittedLine = line.Split(';');

                int[] numbers = Array.ConvertAll(splittedLine[0].Split(','), int.Parse);
                int expectedSum = int.Parse(splittedLine[1]);
                int limit = numbers.Length;

                string pairs = "NULL";

                for (int current = 0; current < limit - 1; ++current)
                {
                    int left = numbers[current];
                    int wanted = expectedSum - left;

                    for (int next = current + 1; next < limit; ++next)
                    {
                        int right = numbers[next];

                        if (right == wanted)
                        {
                            if (pairs == "NULL")
                            {
                                pairs = left + "," + right;
                            }
                            else
                            {
                                pairs = pairs + ";" + left + "," + right;
                            }
                        }
                    }
                }

                Console.WriteLine(pairs);
            }
        }
    }
}