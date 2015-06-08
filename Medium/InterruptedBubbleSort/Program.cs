using System;
using System.IO;

namespace InterruptedBubbleSort
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (string line in File.ReadLines(args[0]))
            {
                int count;
                int[] numbers;

                {
                    string[] splittedLine = line.Split('|');
                    
                    numbers = Array.ConvertAll(splittedLine[0].Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries), int.Parse);

                    int.TryParse(splittedLine[1], out count);
                }

                if (count == 0 || count > numbers.Length)
                {
                    WriteNumbersInline(numbers);

                    continue;
                }

                int limit = numbers.Length - 1;

                while (count > 0)
                {
                    for (int leftIndex = 0; leftIndex < limit; leftIndex++)
                    {
                        int left = numbers[leftIndex];
                        int right = numbers[leftIndex + 1];

                        if (left > right)
                        {
                            numbers[leftIndex] = right;
                            numbers[leftIndex + 1] = left;
                        }
                    }

                    count--;
                }

                WriteNumbersInline(numbers);
            }
        }

        static void WriteNumbersInline(int[] numbers)
        {
            foreach (int number in numbers)
            {
                Console.Write(number + " ");
            }
            
            Console.Write(Environment.NewLine);
        }
    }
}
