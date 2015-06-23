using System;

namespace NumberPairs
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (var line in System.IO.File.ReadLines(args[0]))
            {
                if (line.Length == 0)
                    continue;

                var numbers = Array.ConvertAll(line.Substring(0, line.IndexOf(';')).Split(','), int.Parse);
                int sum = int.Parse(line.Substring(line.IndexOf(';') + 1));
                int limit = numbers.Length - 1;

                string pairs = "NULL";

                for (int current = 0; current < limit - 1; ++current)
                {
                    int left = numbers[current];

                    for (int last = limit; last > current; --last)
                    {
                        int right = numbers[last];

                        if (right > sum - left)
                            continue;

                        if (right < sum - left)
                            break;

                        if (pairs == "NULL")
                            pairs = left + "," + right;
                        else
                            pairs = pairs + ";" + left + "," + right;

                        --limit;

                        break;
                    }
                }

                Console.WriteLine(pairs);
            }
        }
    }
}