using System;

namespace InterruptedBubbleSort
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (string line in System.IO.File.ReadLines(args[0]))
            {
                int index = line.IndexOf('|');

                int count;
                int.TryParse(line.Substring(index + 1), out count);
                var numbers = Array.ConvertAll(line.Substring(0, index - 1).Split(' '), int.Parse);
                int limit = numbers.Length - 1;

                if (count == 0 || limit < count)
                {
                    Console.WriteLine(line.Substring(0, index - 1));
                    continue;
                }

                while (count > 0)
                {
                    for (int leftIndex = 0; leftIndex < limit; ++leftIndex)
                    {
                        int left = numbers[leftIndex];
                        int right = numbers[leftIndex + 1];

                        if (left > right)
                        {
                            numbers[leftIndex] = right;
                            numbers[leftIndex + 1] = left;
                        }
                    }

                    --count;
                }

                for (int number = 0; number <= limit; ++number)
                {
                    Console.Write(numbers[number] + " ");
                }

                Console.Write(Environment.NewLine);
            }
        }
    }
}